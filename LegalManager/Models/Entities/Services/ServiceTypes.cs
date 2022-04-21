// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="ServiceTypes.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManager.Models.Entities.Services {
    /// <summary>
    /// Enum ServiceTypes
    /// </summary>
    public enum ServiceTypes {
        /// <summary>
        /// The legalise document
        /// </summary>
        LEGALISE_DOCUMENT,
        /// <summary>
        /// The oisc service
        /// </summary>
        OISC_SERVICE,
        /// <summary>
        /// The paralegal service
        /// </summary>
        PARALEGAL_SERVICE,
        /// <summary>
        /// The solicitor service
        /// </summary>
        SOLICITOR_SERVICE,
        /// <summary>
        /// The mediator service
        /// </summary>
        MEDIATOR_SERVICE,
        /// <summary>
        /// The translation service
        /// </summary>
        TRANSLATION_SERVICE
    }
}
