// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="Document.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using LegalManager.Models.Entities.Cases;
using System;

namespace LegalManager.Models.Entities.Documents
{
    /// <summary>
    /// Interface with the common behavior for all documents.
    /// </summary>
    public interface Document {

        /// <summary>
        /// Creates a new Document with basic information
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="lable">The lable.</param>
        /// <param name="doctype">The doctype.</param>
        /// <param name="docname">The docname.</param>
        /// <param name="docDesc">The document desc.</param>
        /// <param name="location">The location.</param>
        /// <returns>True if successful, and false otherwise.</returns>
        public void CreateDocument(Case c, string lable, string doctype, string docname, string docDesc, Location location);

        /// <summary>
        /// Renames the document.
        /// </summary>
        /// <param name="name">The name.</param>
        public void renameDocument(string name);

        /// <summary>
        /// Gets the document path.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getDocPath();


    }
}