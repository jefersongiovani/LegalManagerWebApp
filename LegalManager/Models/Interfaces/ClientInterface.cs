// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="ClientInterface.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Common;
using LegalManager.Models.Entities.Clients;
using System;

namespace LegalManager.Models.Interfaces
{
    /// <summary>
    /// Interface that fulfils the operations needed for the Client entity class.
    /// @author Jeferson G. D. Schneider
    /// </summary>
    public interface ClientInterface {

        /// <summary>
        /// Gets the client identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getClientID();

        /// <summary>
        /// Gets the name of the client.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientName();

        /// <summary>
        /// Gets the client email.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientEmail();

        /// <summary>
        /// Gets the client do b.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime getClientDoB();

        /// <summary>
        /// Gets the client reg date.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime getClientRegDate();

        /// <summary>
        /// Gets the client mob number.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientMobNumber();

        /// <summary>
        /// To the string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string toString();

        /// <summary>
        /// Adds the new client.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="doB">The do b.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns>Client.</returns>
        public Client addNewClient(string firstName, string lastName, string email, DateTime doB, string mobileNumber);

        /// <summary>
        /// Gets the client address.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientAddress();

    }
}