// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="Payable.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManager.Models.Interfaces {
    /// <summary>
    /// Interface to be used
    /// with all objects that
    /// are accountable into the
    /// bookkeeping.
    /// </summary>
    public interface Payable {

        /// <summary>
        /// The description of the object that is
        /// being paid.
        /// </summary>
        /// <returns>String description of the object.</returns>
        string getDescription();

        /// <summary>
        /// The cost of the object.
        /// </summary>
        /// <returns>Double the cost of the given object.</returns>
        double getCost();

        /// <summary>
        /// The reference of the object that is being paid.
        /// </summary>
        /// <returns>String the reference code.</returns>
        string getReference();
    }
}
