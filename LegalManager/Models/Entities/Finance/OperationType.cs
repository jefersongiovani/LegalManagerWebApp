// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-20-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-20-2022
// ***********************************************************************
// <copyright file="OperationType.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// Enum OperationType
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// The credit
        /// </summary>
        CREDIT,
        /// <summary>
        /// The debit
        /// </summary>
        DEBIT,
        /// <summary>
        /// The reversion
        /// </summary>
        REVERSION,
        /// <summary>
        /// The adjustment
        /// </summary>
        ADJUSTMENT
    }
}
