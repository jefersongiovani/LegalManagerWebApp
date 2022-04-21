// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-05-2022
// ***********************************************************************
// <copyright file="TimeAndUnitsCalculator.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace LegalManager.Models.Core
{
    /// <summary>
    /// Static class that centralises the operations with time for those objects that need to count time.
    /// </summary>
    public static class TimeAndUnitsCalculator
    {
        private static readonly int UNIT_TIME = 6; //Fixed parameter for unit time of work
        /// <summary>
        /// This method receives two dates (first the later, later the first),
        /// and returns the total minutos as a double.
        /// </summary>
        /// <param name="b">DateTime - The latest date.</param>
        /// <param name="a">DateTime - The oldest date.</param>
        /// <returns>System.Double.</returns>
        public static double calculateTimeInMinutesFromDate(DateTime b, DateTime a)
        {
            TimeSpan timeSpan = b - a;
            return timeSpan.TotalMinutes;
        }

        /// <summary>
        /// Calculate total as TimeSpan
        /// </summary>
        /// <param name="b">DateTime - The newest date.</param>
        /// <param name="a">DateTime - The oldest date.</param>
        /// <returns>TimeSpan.</returns>
        public static TimeSpan calculateTimeTimeSpanFromDate(DateTime b, DateTime a)
        {
            TimeSpan timeSpan = b - a;
            return timeSpan;
        }

        /// <summary>
        /// Receives the total time as a TimeSpan type and calculates its value as double.
        /// </summary>
        /// <param name="t">TimeSpan</param>
        /// <returns>Double - total minutes as double.</returns>
        public static double calculateTimeInMinutesFromTimeSpan(TimeSpan t)
        {
            double timeInMinutes = t.TotalMinutes;
            return timeInMinutes;
        }

        /// <summary>
        /// Returns the total units for a given double.
        /// The units of time are fixed as One Unit for every Six Minutes. This function gets the total time in double,
        /// then round up until the next integer, then divide by 6 to get the total units number.
        /// </summary>
        /// <param name="x">Double - the total time to calculate</param>
        /// <returns>Integer - The total units of time.</returns>
        public static int timeUnitsCalculator(double x)
        {
            //Initial value of units
            int result = 0;

            //Rounding up the given time in double to the nearest integer
            int timeInMin = (int)Math.Ceiling(x);

            //Dividing the time in minutes for 6 to get the total units
            double timeDivision = (double)timeInMin / UNIT_TIME;

            //Rounding up again in case the integer division had generated a double value
            result = (int)Math.Ceiling(timeDivision);

            return result;
        }
        /// <summary>
        /// Gets the month from date.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns>System.Int32.</returns>
        public static int getMonthFromDate(DateTime d)
        {
            return d.Month;
        }

    }
}
