// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-04-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-04-2022
// ***********************************************************************
// <copyright file="DocumentLable.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace LegalManager.Models.Entities.Documents
{
    /// <summary>
    /// This class represent labels to be used with documents
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class DocumentLable {

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentLable"/> class.
        /// </summary>
        public DocumentLable() {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name {
            get; set;
        }


    }
}