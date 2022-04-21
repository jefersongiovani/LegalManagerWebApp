// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ApplicationUser.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Common;
using LegalManager.Models.Entities.Cases;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Users
{
    /// <summary>
    /// Class that define the users of the system.
    /// This class inherits from IdentitUser class for using the Identity mechanism
    /// <author>Jeferson G.D. Schneider</author>
    /// </summary>
    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
        /// </summary>
        /// Empty constructor for EF Core
        /// <remarks>The Id property is initialized to form a new GUID string value.</remarks>
        public ApplicationUser()
        {
        }

        //Attributes

        /// <inheritdoc />
        [Key]
        [MaxLength(255)]
        [Display(Name = "ID")]
        public override string Id { get; set; }

        /// <summary>
        /// The user first names.
        /// </summary>
        /// <value>The first name.</value>
        [ProtectedPersonalData]
        [Display(Name = "First Name(s)")]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The user last names.
        /// </summary>
        /// <value>The last name.</value>
        [ProtectedPersonalData]
        [Required]
        [Display(Name = "Last Name(s)")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        /// The registered date
        /// </summary>
        /// <value>The start date.</value>
        [DataType(DataType.Date)]
        [Display(Name = "Register Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The user status (active/inactive)
        /// </summary>
        /// <value><c>true</c> if [user status]; otherwise, <c>false</c>.</value>
        [Display(Name = "User' Status")]
        public bool UserStatus { get; set; } = true; //Statos for Active/Inactive

        /// <summary>
        /// User personal e-mail address.
        /// </summary>
        /// <value>The personal email.</value>
        [ProtectedPersonalData]
        [Display(Name = "Personal Email Address")]
        public string PersonalEmail { get; set; } //Not used for login. Only for urgent contact

        /// <summary>
        /// Contains a list of personal address about the user.
        /// </summary>
        /// <value>The addresses.</value>
        [ProtectedPersonalData]
        [Display(Name = "Addresses' List")]
        public List<Address> addresses { get; set; }

        /// <summary>
        /// Used as an internal password for sensitive information access.
        /// </summary>
        /// <value>The digital sign identifier.</value>
        [Display(Name = "Internal Password(six numbers)")]
        [MaxLength(6)]
        public int DigitalSignId { get; set; } //Used as a internal password for sensitive information access

        /// <summary>
        /// The profile picture of the user.
        /// </summary>
        /// <value>The photo.</value>
        [ProtectedPersonalData]
        [Display(Name = "Profile Photo")]
        [Column(TypeName = "mediumblob")]
        public byte[] Photo { get; set; }

        /// <summary>
        /// The legal titles the user has (Solicitor, Master in Law, Fellow Paralegal, Paralegal, etc.
        /// </summary>
        /// <value>The user titles.</value>
        public List<UserTitle> userTitles { get; set; } = new List<UserTitle>();

        /// <summary>
        /// Collection of adresses for an user.
        /// </summary>
        /// <value>The addresses.</value>
        public virtual ICollection<UserAddress> Addresses { get; set; }

        /// <summary>
        /// Collection of contact informations about an user
        /// </summary>
        /// <value>The contact information.</value>
        [ForeignKey("UserFK")]
        public virtual ICollection<UserContactInformation> ContactInformation { get; set; }

        /// <summary>
        /// Collection of cases owned by an user (in case of a legal user)
        /// </summary>
        /// <value>The cases.</value>
        [ForeignKey("OwnerIDFK")]
        public virtual ICollection<Case> cases { get; set; }

        /// <summary>
        /// Access to the personal internal pass
        /// </summary>
        /// <returns>Integer</returns>
        public int GetUserInternalPass()
        {
            return this.DigitalSignId;
        }

        /// <summary>
        /// Adds a new user Title
        /// </summary>
        /// <param name="t">The t.</param>
        public void addUserTitle(UserTitle t)
        {
            this.userTitles.Add(t);
        }

        /// <summary>
        /// Return the User Complete Name (First + Last names)
        /// </summary>
        /// <returns>String</returns>
        public string GetUserCompleteName()
        {
            return this.FirstName + " " + this.LastName;
        }


    }
}
