// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="TimetabledInterface.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace LegalManager.Models.Interfaces {
    /// <summary>
    /// Interface for the classes that count working time
    /// @author Jeferson Giovani D. Schneider
    /// </summary>
    public interface TimetabledInterface {

        /// <summary>
        /// Set the starting time
        /// everytime the object is opened/instantiated.
        /// </summary>
        public void setStartTime();

        /// <summary>
        /// Set the ending time
        /// each time the object/instance
        /// is closed.
        /// </summary>
        public void setEndTime();

        /// <summary>
        /// Return the total time calculated
        /// after the object is closed.
        /// </summary>
        /// <returns>DateTime in minutes</returns>
        public TimeSpan getTotalTime();

        /// <summary>
        /// Returns the total units of time
        /// based on the total time.
        /// </summary>
        /// <returns>int total units</returns>
        public int getTotalUnits();

        /// <summary>
        /// Add units of time to the total.
        /// </summary>
        /// <param name="u">Integer</param>
        public void addTimeUnits(int u);

        /// <summary>
        /// Discounts units of time of the total.
        /// </summary>
        /// <param name="u">Integer</param>
        public void discountTimeUnits(int u);


    }
}
