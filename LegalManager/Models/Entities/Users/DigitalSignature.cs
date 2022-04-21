// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="DigitalSignature.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Entities.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Users
{
    /// <summary>
    /// This class that stores a simple signature used to validate the user inside the system.
    /// </summary>
    public class DigitalSignature
    {
        //Empty constructor for EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalSignature"/> class.
        /// </summary>
        public DigitalSignature() { }

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalSignature"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="s">The s.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public DigitalSignature(string id, string s)
        {
            if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(s))
            {
               try
                {
                    this.UserId = id;
                    this.Signature = s;
                }
                catch (ArgumentNullException)
                {
                    throw new ArgumentNullException();
                }
            }
            
             else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// Attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>The signature.</value>
        [Required]
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [Required]
        public ApplicationUser user { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        
    }
}
