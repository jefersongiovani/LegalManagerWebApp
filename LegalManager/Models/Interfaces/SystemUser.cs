// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="SystemUser.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManager.Models.Interfaces
{
    /// <summary>
    /// Interface that defines the system's user basic operations.
    /// </summary>
    public interface SystemUser {

        /// <summary>
        /// Returns the Access Level for a given user.
        /// </summary>
        /// <returns>String access</returns>
        public string getAccessLevels();

    }
}