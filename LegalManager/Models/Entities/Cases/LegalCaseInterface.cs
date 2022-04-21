// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="LegalCaseInterface.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace LegalManager.Models.Entities.Cases
{
    /// <summary>
    /// Interface LegalCaseInterface
    /// </summary>
    public interface LegalCaseInterface {

        /// <summary>
        /// @return
        /// </summary>
        public void caseNotification();

        /// <summary>
        /// Generate a new document with all documents given from the client.
        /// </summary>
        /// <param name="c">Case</param>
        public void generateBundle(Case c);


        /// <summary>
        /// Changes the case' status
        /// </summary>
        /// <param name="e">Enum</param>
        public void changeStatus(Enum e);

    }
}