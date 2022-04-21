// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-07-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-07-2022
// ***********************************************************************
// <copyright file="RoleManagerController.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LegalManager.Api
{
    /// <summary>
    /// This class controller manages the Roles.
    /// This class is an adaptation of a custom user management from Mukesh Murugan at codewithmukesh.com
    /// </summary>
    public class RoleManagerController : Controller
    {
        /// <summary>
        /// The role manager
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Constructor that injects the RoleManager instance.
        /// </summary>
        /// <param name="roleManager">RoleManager object</param>
        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// Sends to the View the list of roles into the system.
        /// </summary>
        /// <returns>List</returns>
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }


        /// <summary>
        /// Adds a new role
        /// </summary>
        /// <param name="roleName">String - the role's name</param>
        /// <returns>Returns to the page</returns>
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
    }
}
