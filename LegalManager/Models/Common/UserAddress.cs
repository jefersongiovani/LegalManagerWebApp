// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="UserAddress.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations.Schema;
using LegalManager.Models.Entities.Users;
namespace LegalManager.Models.Common {
    /// <summary>
    /// Class for the Address object of
    /// a system user.
    /// The system user needs only one active
    /// address, opposing to the client that needs
    /// more than one.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class UserAddress : Address {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAddress"/> class.
        /// </summary>
        public UserAddress()
        {
        }

        //Attributes

        /// <summary>
        /// The date for the last update.
        /// </summary>
        public DateTime DateUpdated;

        /// <summary>
        /// The UserID of the owner of this address. Must not be null.
        /// </summary>
        /// <value>The user idfk.</value>
        [ForeignKey("ApplicationUser")]
        public string UserIDFK { get; set; }

    }
}
