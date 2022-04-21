// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="CaseIdGenerator.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Models.Core
{
    /// <summary>
    /// Class CaseIdGenerator.
    /// </summary>
    public static class CaseIdGenerator
    {
        /// <summary>
        /// method that provides the base string to build case Ids.
        /// The string it provides is composed by MMddhh.
        /// </summary>
        /// <returns>string representation of MMddhh</returns>
        private static string getCaseBase()
        {
            return  DateTime.Now.ToString();
        }

        //Methods
        /// <summary>
        /// Method that returns the new case id based on the composition of
        /// clientId + caseType +  -MMddhh
        /// <returns>String</returns>
        /// </summary>
        /// <returns>System.String.</returns>
        public static string getNewCaseId()
        {
            return "-" + getCaseBase();
        }
    }
}
