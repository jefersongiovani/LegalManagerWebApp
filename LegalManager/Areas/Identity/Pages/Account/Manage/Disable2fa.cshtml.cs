// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-21-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="Disable2fa.cshtml.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using LegalManager.Models.Entities.Users;

namespace LegalManager.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Class Disable2faModel.
    /// Implements the <see cref="PageModel" />
    /// </summary>
    /// <seealso cref="PageModel" />
    public class Disable2faModel : PageModel
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Disable2faModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Disable2faModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="logger">The logger.</param>
        public Disable2faModel(
            UserManager<ApplicationUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Called when [get].
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// <exception cref="System.InvalidOperationException">Cannot disable 2FA for user with ID '{_userManager.GetUserId(User)}' as it's not currently enabled.</exception>
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"Cannot disable 2FA for user with ID '{_userManager.GetUserId(User)}' as it's not currently enabled.");
            }

            return Page();
        }

        /// <summary>
        /// On post as an asynchronous operation.
        /// </summary>
        /// <returns>A Task&lt;IActionResult&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.InvalidOperationException">Unexpected error occurred disabling 2FA for user with ID '{_userManager.GetUserId(User)}'.</exception>
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred disabling 2FA for user with ID '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("User with ID '{UserId}' has disabled 2fa.", _userManager.GetUserId(User));
            StatusMessage = "2fa has been disabled. You can reenable 2fa when you setup an authenticator app";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}