// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-01-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-01-2022
// ***********************************************************************
// <copyright file="UserContactInformation.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AssertLibrary;
using LegalManager.Models.Entities.Users;

namespace LegalManager.Models.Common
{
    /// <summary>
    /// This class stores contact information for users.
    /// It stores Name as name of the type of information (Mobile, pager, alternate email, etc.)
    /// It stores the description as information.
    /// It needs the User as a parameter to be constructed.
    /// </summary>
    public class UserContactInformation {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContactInformation"/> class.
        /// </summary>
        /// <param name="usr">The usr.</param>
        /// <param name="name">The name.</param>
        /// <param name="information">The information.</param>
        public UserContactInformation(ApplicationUser usr, string name, string information)
        {
            if(usr == null || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(information))
            {
                throw new ArgumentNullException();
            }
            else
            {
                try
                {
                    this.user = usr;
                    this.Name = name;
                    this.Information = information;
                    this.isDeprecated = false;
                }
                catch(ArgumentNullException e)
                {
                    throw new ArgumentException(nameof(e));
                }
            }

            

        }

        //Empty constructor for EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContactInformation"/> class.
        /// </summary>
        public UserContactInformation() { }

        //Attributes
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user fk.
        /// </summary>
        /// <value>The user fk.</value>
        [ForeignKey("ApplicationUser")]
        public string UserFK { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public ApplicationUser user { get; set; }

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
            return this.user.FirstName + " - "
                + this.Name + ": "
                + this.Information + " - "
                + "Is active: " + this.isDeprecated;
        }
    }
}