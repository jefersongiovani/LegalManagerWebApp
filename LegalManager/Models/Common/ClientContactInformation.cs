// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ClientContactInformation.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AssertLibrary;
using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Entities.Users;

namespace LegalManager.Models.Common
{
    /// <summary>
    /// This class stores contact information for users.
    /// It stores Name as name of the type of information (Mobile, pager, alternate email, etc.)
    /// It stores the description as information.
    /// It needs the User as a parameter to be constructed.
    /// </summary>
    public class ClientContactInformation {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientContactInformation"/> class.
        /// </summary>
        /// <param name="usr">The usr.</param>
        /// <param name="name">The name.</param>
        /// <param name="information">The information.</param>
        public ClientContactInformation(Client usr, string name, string information)
        {
            Assert.IsOfType<Client>(usr);
            Assert.IsNotNull(name);
            Assert.IsNotNull(information);
            
            this.client = usr;
            this.Name = name;
            this.Information = information;
            this.isDeprecated = false;
            this.clientIdFK = usr.ClientID;
        }

        //Empty constructor for EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientContactInformation"/> class.
        /// </summary>
        public ClientContactInformation() { }

        //Attributes
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the client identifier fk.
        /// </summary>
        /// <value>The client identifier fk.</value>
        [ForeignKey("Client")]
        public int clientIdFK { get; set; }
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public Client client { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        public string Information { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deprecated.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated; otherwise, <c>false</c>.</value>
        public bool isDeprecated { get; set; } = false;


        //Methods

        /// <summary>
        /// Set the information as deprecated/Not valid anymore.
        /// </summary>
        public void setDeprecated()
        {
            this.isDeprecated = true;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.client.FirstName + " - Document Type: "
                + this.Name + " : "
                + this.Information + " - "
                + "Is active: " + this.isDeprecated;
        }
    }
}