// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="Location.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;

namespace LegalManager.Models.Entities.Documents
{
    /// <summary>
    /// This class represents the physical location
    /// of documents if it is needed.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class Location {

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location() {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        //Defines the name of the location
        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>The name of the location.</value>
        [DisplayName("Location's Name")]
        public string LocationName {
            get; set;
        }

        //Defines the position into the location
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [DisplayName("Location's position")]
        public string Position {
            get; set;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "[ Location name: " + LocationName
                + " - at position: " + Position
                + " ]";
        }
    }
}