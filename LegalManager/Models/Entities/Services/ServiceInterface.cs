// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="ServiceInterface.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegalManager.Models.Entities.Services
{
    /// <summary>
    /// Interface ServiceInterface
    /// </summary>
    public interface ServiceInterface {

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <returns>System.String.</returns>
        public abstract string getTitle();

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <returns>System.String.</returns>
        public abstract string getDescription();

        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <returns>System.Double.</returns>
        public abstract double getCost();

    }
}