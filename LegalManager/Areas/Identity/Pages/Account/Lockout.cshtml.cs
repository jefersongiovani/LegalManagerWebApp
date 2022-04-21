// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-21-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-21-2022
// ***********************************************************************
// <copyright file="Lockout.cshtml.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LegalManager.Areas.Identity.Pages.Account
{
    /// <summary>
    /// Class LockoutModel.
    /// Implements the <see cref="PageModel" />
    /// </summary>
    /// <seealso cref="PageModel" />
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {
        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {

        }
    }
}
