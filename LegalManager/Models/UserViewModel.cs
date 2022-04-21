// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-07-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-07-2022
// ***********************************************************************
// <copyright file="UserViewModel.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace LegalManager.Models
{
    /// <summary>
    /// Class UserViewModel.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public IEnumerable<string> Roles { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [user status].
        /// </summary>
        /// <value><c>true</c> if [user status]; otherwise, <c>false</c>.</value>
        public bool UserStatus { get; set; }   



    }
}
