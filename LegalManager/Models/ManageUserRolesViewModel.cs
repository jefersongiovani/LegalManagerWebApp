// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-22-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="ManageUserRolesViewModel.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManager.Models
{
    /// <summary>
    /// Class ManageUserRolesViewModel.
    /// </summary>
    public class ManageUserRolesViewModel
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        public string RoleId { get; set; }
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        public string RoleName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ManageUserRolesViewModel"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected { get; set; }
    }
}
