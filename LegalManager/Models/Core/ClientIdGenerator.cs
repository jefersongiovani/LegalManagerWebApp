// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="ClientIdGenerator.cs" company="LegalManager">
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
    /// Static class that creates a new ClientId according
    /// to the following defined pattern: yyyyMMdd-hhmm
    /// </summary>
    public class ClientIdGenerator
    {
        //Static method

        /// <summary>
        /// Gets the new client identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <font color="red">Badly formed XML comment.</font>
        public static string getNewClientId()
        {
            return DateTime.Now.Year
                + DateTime.Now.Month
                + DateTime.Now.Day
                + "-"
                + DateTime.Now.Hour
                + DateTime.Now.Minute;
        }
    }
}
