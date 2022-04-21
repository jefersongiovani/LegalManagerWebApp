// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="CaseStatus.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace LegalManager.Models.Entities.Cases{
    /// <summary>
    /// Enum class that provides the status' names used by the Case class.
    /// </summary>
    public enum CaseStatus {
        /// <summary>
        /// The case created
        /// </summary>
        CASE_CREATED,
        /// <summary>
        /// The initiating case
        /// </summary>
        INITIATING_CASE,
        /// <summary>
        /// The creating documentation
        /// </summary>
        CREATING_DOCUMENTATION,
        /// <summary>
        /// The waiting documentation
        /// </summary>
        WAITING_DOCUMENTATION,
        /// <summary>
        /// The preparing bundle
        /// </summary>
        PREPARING_BUNDLE,
        /// <summary>
        /// The submitting case
        /// </summary>
        SUBMITTING_CASE,
        /// <summary>
        /// The case submitted
        /// </summary>
        CASE_SUBMITTED,
        /// <summary>
        /// The waiting decision
        /// </summary>
        WAITING_DECISION,
        /// <summary>
        /// The appealing case
        /// </summary>
        APPEALING_CASE,
        /// <summary>
        /// The case closed
        /// </summary>
        CASE_CLOSED
    }
}