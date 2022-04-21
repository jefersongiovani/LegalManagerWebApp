// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-07-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-07-2022
// ***********************************************************************
// <copyright file="UserRolesController.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models;
using LegalManager.Models.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Api
{
    /// <summary>
    /// This class controller manages the User Roles and its changes.
    /// This class is an adaptation of a custom user management from Mukesh Murugan at codewithmukesh.com
    /// </summary>
    public class UserRolesController : Controller
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The role manager
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Constructor that injects the UserManager and the RoleManager instances
        /// </summary>
        /// <param name="userManager">UserManager object</param>
        /// <param name="roleManager">RoleManager objct</param>
        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Builds a list with the users and their roles
        /// </summary>
        /// <returns>List of users and roles</returns>
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }
        /// <summary>
        /// Private method that gets the user's roles.
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <returns>List of strings - the user's roles</returns>
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        /// <summary>
        /// Controller action that receives a user ID and shows the Roles it user has.
        /// </summary>
        /// <param name="userId">String</param>
        /// <returns>View object</returns>
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View();
            }
            ViewBag.UserName = user.UserName;
            ViewBag.Name = user.FirstName;
            var model = new List<ManageUserRolesViewModel>();

            ///To fix the MySql problem of multiple readers
            ///the list of roles is created below to be used into the foreach.
            var myRoles = _roleManager.Roles.ToList();

            foreach (var role in myRoles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }

        /// <summary>
        /// Method to manage and add/exclud roles for users
        /// </summary>
        /// <param name="model">UserRoles view model</param>
        /// <param name="userId">String</param>
        /// <returns>Redirect to action</returns>
        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
