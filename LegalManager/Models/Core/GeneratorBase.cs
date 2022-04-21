// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="GeneratorBase.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace LegalManager.Models.Core
{
    /// <summary>
    /// Class that provides the base string to be used as Id for various entities.
    /// <param name="author">Jeferson G.D. Schneider</param>
    /// </summary>
    public static class GeneratorBase {

        /// <summary>
        /// Returns a string with yyyyMMdd for new Ids
        /// Generally used to compose the Invoice Id.
        /// </summary>
        /// <returns>string with yyyyMMdd</returns>
        public static string GetBase()
        {
            return "-" + DateTime.Now.ToString("yyyyMMdd");
        }

        //Methods
        /// <summary>
        /// Method that returns the new case id based on the composition of
        /// clientId + caseType +  -MMddHH
        /// <returns>String CaseID formed with clientId + caseType +  MMddHH</returns>
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="caseType">Type of the case.</param>
        /// <returns>System.String.</returns>
        public static string GetCaseStampID(string clientId, string caseType)
        {

            return clientId + "-" + caseType + GetBase() + DateTime.Now.Hour.ToString();
        }

        /// <summary>
        /// Method that returns an Id for a document based on the CaseID + date identifier(yyyyMMdd-hhmm).
        /// </summary>
        /// <param name="caseId">The CaseId for this document</param>
        /// <returns>String Unique ID for the document</returns>
        public static string GetDocumentStampID(int caseId)
        {
            string nowtime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            
            return caseId + GetBase() +  nowtime;
        }
    }
}