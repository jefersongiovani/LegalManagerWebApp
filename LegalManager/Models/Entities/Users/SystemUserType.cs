// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="SystemUserType.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Models.Entities.Users {

    /// <summary>
    /// The UserType is the qualifier for the system user (office user, legal user, bookkeeper, etc..)
    /// An user can have multiple types.
    /// </summary>
    public class SystemUserType {

        //Empty constructor for EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemUserType"/> class.
        /// </summary>
        public SystemUserType() { }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [Required]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime dateCreated { get; set; }

        /// <summary>
        /// Gets the type of the system user.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getSystemUserType()
        {
            return this.TypeName;
        }
    }
}

