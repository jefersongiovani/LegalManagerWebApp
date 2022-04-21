// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-07-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-07-2022
// ***********************************************************************
// <copyright file="Event.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using AssertLibrary;
using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Calendar
{
    /// <summary>
    /// Events for the web calendar
    /// </summary>
    public class Event {


        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// Empty constructor for EF Core
        public Event() { }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// Attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        /// <summary>
        /// The starting date and time of the event
        /// </summary>
        /// <value>The start.</value>
        public DateTime Start { get; set; }

        /// <summary>
        /// The ending date and time of the event
        /// </summary>
        /// <value>The end.</value>
        public DateTime End { get; set; }

        /// <summary>
        /// The description of the event
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
        

    
    }
}