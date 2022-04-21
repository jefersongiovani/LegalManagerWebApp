// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="ClientAddress.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Common
{
    /// <summary>
    /// Class ClientAddress.
    /// Implements the <see cref="Address" />
    /// </summary>
    /// <seealso cref="Address" />
    public class ClientAddress : Address
    {


        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientAddress"/> class.
        /// </summary>
        /// <param name="clientID">The client identifier.</param>
        /// <param name="addressName">Name of the address.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="buildOrNumber">The build or number.</param>
        /// <param name="addressLine">The address line.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="borough">The borough.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        public ClientAddress(int clientID, string addressName, string postCode,
            string buildOrNumber, string addressLine, string addressLine2,
            string borough, string city, string country)
            : base(addressName, postCode,
                buildOrNumber, addressLine,
                addressLine2, borough, city, country)
        {
            this.ClientIDFK = clientID;
        }

        //Empty constructor for EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientAddress"/> class.
        /// </summary>
        public ClientAddress() { }

        //Attributes
        /// <summary>
        /// The identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;

        /// <summary>
        /// Gets or sets the client idfk.
        /// </summary>
        /// <value>The client idfk.</value>
        [ForeignKey("Client")]
        public int ClientIDFK { get; set; }

        /// <summary>
        /// Gets or sets the start living date.
        /// </summary>
        /// <value>The start living date.</value>
        [DisplayName("Start Living Date")]
        public DateTime StartLivingDate { get; set; }


        /// <summary>
        /// Gets or sets the end living date.
        /// </summary>
        /// <value>The end living date.</value>
        public DateTime EndLivingDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool isActive { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is preffered.
        /// </summary>
        /// <value><c>true</c> if this instance is preffered; otherwise, <c>false</c>.</value>
        public bool isPreffered { get; set; } = false;


        //Methods

        /// <summary>
        /// Gets the postal address.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getPostalAddress()
        {
            return (base.ToString());
        }
        /// <summary>
        /// Gets the actual address.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string getActualAddress()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the inactive.
        /// </summary>
        public void setInactive()
        {
            this.isActive = false;
        }
        /// <summary>
        /// Sets the preferred.
        /// </summary>
        public void setPreferred()
        {
            this.isPreffered = true;
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime getStartDate()
        {
            return this.StartLivingDate;
        }
    }
}
