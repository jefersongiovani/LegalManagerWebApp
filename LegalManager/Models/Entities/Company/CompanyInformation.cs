// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="CompanyInformation.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using AssertLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Company
{
    /// <summary>
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class CompanyInformation {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyInformation"/> class.
        /// </summary>
        public CompanyInformation() {
        }

        //Attributes
        /// <summary>
        /// Gets or sets the information identifier.
        /// </summary>
        /// <value>The information identifier.</value>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int infoID { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>The company identifier.</value>
        [ForeignKey("Company")]
        public String CompanyID { get; set; }


        /// <summary>
        /// Gets or sets the name of the information.
        /// </summary>
        /// <value>The name of the information.</value>
        public String InformationName { get; set; }


        /// <summary>
        /// Gets or sets the information details.
        /// </summary>
        /// <value>The information details.</value>
        public String InformationDetails { get; set; }

        //Methods

        /// <summary>
        /// Adds the company information.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <param name="infoName">Name of the information.</param>
        /// <param name="InfoDetails">The information details.</param>
        public void addCompanyInfo(Company company, String infoName, String InfoDetails)
        {
            Assert.IsNotNull(company);
            Assert.IsOfType<Company>(company);
            Assert.IsNotNull(infoName);
            Assert.IsNotNull(InfoDetails);

            CompanyID = company.CompanyID;
            InformationName = infoName;
            InformationDetails = InfoDetails;
        }

    }
}