// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ChosenService.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using LegalManager.Models.Interfaces;
using System;

namespace LegalManager.Models.Entities.Services {
    /// <summary>
    /// Class ChosenService.
    /// Implements the <see cref="LegalManager.Models.Entities.Services.ServiceDecorator" />
    /// Implements the <see cref="Payable" />
    /// </summary>
    /// <seealso cref="LegalManager.Models.Entities.Services.ServiceDecorator" />
    /// <seealso cref="Payable" />
    public class ChosenService : ServiceDecorator, Payable {

        /// <summary>
        /// Initializes a new instance of the <see cref="ChosenService"/> class.
        /// </summary>
        /// <param name="cost">The cost.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentException">e</exception>
        public ChosenService(double cost, string title, string description, string type)
        {
            try
            {
                this.Cost = cost;
                this.Title = title;
                this.Description = description;
                this.ServiceType = type;

            } 
            catch(ArgumentException)
            {
                throw new ArgumentException("Invalid or null arguments provided while constructing the service.");
            }
        }

        //Empty constructor for EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="ChosenService"/> class.
        /// </summary>
        public ChosenService() { }


        //Methods
        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <returns>System.Double.</returns>
        public override double getCost()
        {
            return this.Cost;
        }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string getDescription()
        {
            return this.Description;
        }
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string getTitle()
        {
            return this.Title;
        }
        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string getServiceType()
        {
            return this.ServiceType;
        }
        /// <summary>
        /// Gets the reference.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string getReference()
        {
            return this.ServiceID.ToString();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ("Service: ServiceID" + this.ServiceID + " - " + this.Title +
                " - Description: " + this.Description + " - Value: " + this.Cost);
        }

    }
}
