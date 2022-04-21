// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-20-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-20-2022
// ***********************************************************************
// <copyright file="DocumentType.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManager.Models.Entities.Documents
{
    /// <summary>
    /// Enum DocumentType
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// The proof address
        /// </summary>
        PROOF_ADDRESS,
        /// <summary>
        /// The proof identity
        /// </summary>
        PROOF_IDENTITY,
        /// <summary>
        /// The proof residency
        /// </summary>
        PROOF_RESIDENCY,
        /// <summary>
        /// The proof relationship
        /// </summary>
        PROOF_RELATIONSHIP,
        /// <summary>
        /// The proof other
        /// </summary>
        PROOF_OTHER,
        /// <summary>
        /// The legal document
        /// </summary>
        LEGAL_DOCUMENT,
        /// <summary>
        /// Generic Document
        /// </summary>
        OTHER
    }
}
