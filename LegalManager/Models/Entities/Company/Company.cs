// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="Company.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using LegalManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;

namespace LegalManager.Models.Entities.Company
{
    /// <summary>
    /// class that identifies the company.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class Company
    {

        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        //Empty Constructor for EF
        /// <summary>
        /// Prevents a default instance of the <see cref="Company"/> class from being created.
        /// </summary>
        public Company()
        { 
           
        }


        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>The company identifier.</value>
        /// Attributes
        /// Unique ID for the company
        public string CompanyID { get; set; } = Guid.NewGuid().ToString();


        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        /// Company Name
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company registration.
        /// </summary>
        /// <value>The company registration.</value>
        /// Company registration
        public string CompanyRegistration { get; set; }

        /// <summary>
        /// Gets or sets the company URL.
        /// </summary>
        /// <value>The company URL.</value>
        /// Company URL
        public string CompanyURL { get; set; }

        /// <summary>
        /// Gets or sets the company default email.
        /// </summary>
        /// <value>The company default email.</value>
        /// Company default e-mail address
        public string CompanyDefaultEmail { get; set; }

        /// <summary>
        /// Gets the company identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        /// Methods
        /// Returns the company ID as string
        public string getCompanyID()
        {

            return CompanyID;
        }

        /// <summary>
        /// Returns the company name
        /// </summary>
        /// <returns>String</returns>
        public string getCompanyName()
        {
            return this.CompanyName;
        }

        /// <summary>
        /// Returns the company URL
        /// </summary>
        /// <returns>String</returns>
        public string getCompanyURL()
        {
            return this.CompanyURL;
        }

        /// <summary>
        /// Returns the main e-mail address
        /// </summary>
        /// <returns>String</returns>
        public string getCompanyEmail()
        {
            return this.CompanyDefaultEmail;
        }


    }

}
