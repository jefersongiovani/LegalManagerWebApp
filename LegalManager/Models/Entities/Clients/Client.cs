// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="Client.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Identity;
using LegalManager.Models.Common;
using LegalManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LegalManager.Models.Core;

namespace LegalManager.Models.Entities.Clients
{
    /// <summary>
    /// Class Client.
    /// Implements the <see cref="ClientInterface" />
    /// </summary>
    /// <seealso cref="ClientInterface" />
    public class Client : ClientInterface {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="doB">The do b.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        private Client(string firstName, string lastName, string email, DateTime doB, string mobileNumber)
        {
            //Create from the passed parameters
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = email;
            this.DateOfBirth = doB;
            this.MobileNumber = mobileNumber;
            this.RegisteredDate = DateTime.Today;

            
        }

        //Empty constructor for EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client() { }

        //Attributes
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }

        /// <summary>
        /// The stamp identifier
        /// </summary>
        public string StampId = ClientIdGenerator.getNewClientId();

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required]
        [ProtectedPersonalData]
        [DisplayName("Client's First Name(s)")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [ProtectedPersonalData]
        [DisplayName("Client's Last Name(s)")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get { 
            return FirstName + " " + LastName; } }


        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        [Required]
        [ProtectedPersonalData]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>The mobile number.</value>
        [Required]
        [ProtectedPersonalData]
        [DisplayName("Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [ProtectedPersonalData]
        [DisplayName("Registration Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime RegisteredDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        [Required]
        [ProtectedPersonalData]
        [DisplayName("Client's Birthday")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the name of the identification.
        /// </summary>
        /// <value>The name of the identification.</value>
        [ProtectedPersonalData]
        [DisplayName("Identification Document Name")]
        public string IdentificationName { get; set; }

        /// <summary>
        /// Gets or sets the identification.
        /// </summary>
        /// <value>The identification.</value>
        [ProtectedPersonalData]
        [DisplayName("Document Number")]
        public string Identification { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>The nationality.</value>
        [Required]
        [ProtectedPersonalData]
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the client address.
        /// </summary>
        /// <value>The client address.</value>
        public ClientAddress clientAddress { get; set; }

        /// <summary>
        /// Gets or sets the client addresses.
        /// </summary>
        /// <value>The client addresses.</value>
        [ForeignKey("ClientIDFK")]
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }

        //Methods
        /// <summary>
        /// Gets the client identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getClientID()
        {
            return this.ClientID;
        }
        /// <summary>
        /// Gets the name of the client.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientName()
        {
            return this.FirstName + " " + this.LastName;
        }
        /// <summary>
        /// Gets the client email.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientEmail()
        {
            return this.EmailAddress;
        }
        /// <summary>
        /// Gets the client do b.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime getClientDoB()
        {
            return this.DateOfBirth;
        }
        /// <summary>
        /// Gets the client reg date.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime getClientRegDate()
        {
            return this.RegisteredDate;
        }
        /// <summary>
        /// Gets the client mob number.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientMobNumber()
        {
            return MobileNumber;
        }
        /// <summary>
        /// To the string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string toString()
        {
            return ("ID: " + getClientID() + "- Client full name: " + getClientName() + "<br/>" +
                "Nationality: " + this.Nationality + "<br/>" +
                "E-mail: " + getClientEmail() + "<br/>" +
                "Mobile Number: " + getClientMobNumber() + "<br/>" +
                "Date of Birth: " + getClientDoB() + "<br/>" +
                "Address: " + getClientAddress());
        }

        /// <summary>
        /// Adds the new client.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="doB">The do b.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns>Client.</returns>
        /// <exception cref="System.ArgumentException">Error:</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public Client addNewClient(string firstName, string lastName, string email, DateTime doB, string mobileNumber)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(email)
                && !string.IsNullOrWhiteSpace(mobileNumber)){
                try
                {
                    Client client = new Client(firstName, lastName, email, doB, mobileNumber);
                    return client;
                }
                catch(ArgumentException ex)
                {
                    throw new ArgumentException("Error: ", ex);
                }
            }
            else
            {
                throw new ArgumentException();
            }
            
        }
        /// <summary>
        /// Gets the client address.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getClientAddress()
        {
            return this.clientAddress.ToString();
        }




    }
}