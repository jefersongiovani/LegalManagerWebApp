// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="Service.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Services
{
    /// <summary>
    /// The abstract Service class acts as a component for the types of services that will be provided.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public abstract class Service : ServiceInterface {
        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service() {
        }

        //Attributes
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public double Cost { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>The type of the service.</value>
        public string ServiceType { get; set; }



        //Methods
        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <returns>System.Double.</returns>
        public abstract double getCost();
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <returns>System.String.</returns>
        public abstract string getDescription();
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <returns>System.String.</returns>
        public abstract string getTitle();
        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <returns>System.String.</returns>
        public abstract string getServiceType();

        /// <summary>
        /// Gets the reference.
        /// </summary>
        /// <returns>System.String.</returns>
        public abstract string getReference();


    }
}