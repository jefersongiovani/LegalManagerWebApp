// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-07-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-07-2022
// ***********************************************************************
// <copyright file="CalendarController.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;

namespace LegalManager.Controllers
{
    /// <summary>
    /// Class CalendarController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    public class CalendarController : Controller
    {
        /// <summary>
        /// Homes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Home()
        {
            return View();
        }
    }
}
