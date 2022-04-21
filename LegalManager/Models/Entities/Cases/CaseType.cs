// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="CaseType.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Models.Entities.Cases
{
    /// <summary>
    /// Enum CaseType
    /// </summary>
    public enum CaseType
    {
        /// <summary>
        /// The oisc
        /// </summary>
        OISC,
        /// <summary>
        /// The paralegal
        /// </summary>
        PARALEGAL,
        /// <summary>
        /// The sra
        /// </summary>
        SRA,
        /// <summary>
        /// The mediation
        /// </summary>
        MEDIATION,
        /// <summary>
        /// The legalisation
        /// </summary>
        LEGALISATION,
        /// <summary>
        /// The non legal
        /// </summary>
        NON_LEGAL
    }
}
