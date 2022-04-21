// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="UserTitle.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Models.Entities.Users
{
    /// <summary>
    /// Class UserTitle.
    /// </summary>
    public class UserTitle
    {
        //Constructor (empty) for the EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="UserTitle"/> class.
        /// </summary>
        public UserTitle() { }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [Display(Name = "Title Name")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation.
        /// </summary>
        /// <value>The abbreviation.</value>
        [Required]
        [Display(Name = "Title Abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the registered number.
        /// </summary>
        /// <value>The registered number.</value>
        [Display(Name = "Registered number")]
        public string RegisteredNumber { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [Required]
        public ApplicationUser user { get; set; }

        
    }
}
