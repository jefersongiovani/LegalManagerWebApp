// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="LegalUser.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegalManager.Models.Interfaces
{
    /// <summary>
    /// Default interface for LegalAdvisers.
    /// </summary>
    public interface LegalUser {

        /// <summary>
        /// Gets the legal reg.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getLegalReg();

        /// <summary>
        /// Gets the qualification signs.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getQualificationSigns();

        /// <summary>
        /// Gets the legal title.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getLegalTitle();

    }
}