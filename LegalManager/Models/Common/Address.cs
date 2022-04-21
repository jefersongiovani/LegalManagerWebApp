// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="Address.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Common
{
    /// <summary>
    /// Class for adresses
    /// It creates new objects from the constructor
    /// <author> Jeferson G.D. Schneider</author>
    /// </summary>
    public abstract class Address
    {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="addressName">Name of the address.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="buildOrNumber">The build or number.</param>
        /// <param name="addressLine">The address line.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="borough">The borough.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        public Address(string addressName, string postCode,
            string buildOrNumber, string addressLine, string addressLine2,
            string borough, string city, string country)
        {

            this.AddressName = addressName;
            this.PostCode = postCode;
            this.BuildOrNumber = buildOrNumber;
            this.AddressLine = addressLine;
            this.AddressLine2 = addressLine2;
            this.Borough = borough;
            this.City = city;
            this.Country = country;
        }

        //Attributes
        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>The address identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        /// <summary>
        /// Gets or sets the name of the address.
        /// </summary>
        /// <value>The name of the address.</value>
        public string AddressName { get;  set; }
        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        /// <value>The post code.</value>
        public string PostCode { get;  set; }
        /// <summary>
        /// Gets or sets the build or number.
        /// </summary>
        /// <value>The build or number.</value>
        public string BuildOrNumber { get;  set; }
        /// <summary>
        /// Gets or sets the address line.
        /// </summary>
        /// <value>The address line.</value>
        public string AddressLine { get;  set; }
        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        public string AddressLine2 { get;  set; }
        /// <summary>
        /// Gets or sets the borough.
        /// </summary>
        /// <value>The borough.</value>
        public string Borough { get;  set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get;  set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get;  set; }

        //Methods
        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns>Address.</returns>
        public Address updateAddress(Address b)
        {
            //Updating this address according to the object received.
            this.AddressName = b.AddressName;
            this.PostCode = b.PostCode;
            this.BuildOrNumber = b.BuildOrNumber;
            this.AddressLine = b.AddressLine;
            this.AddressLine2 = b.AddressLine2;
            this.Borough = b.Borough;
            this.City = b.City;
            this.Country = b.Country;

            return this;//returning this object
        }

        //Overriden methods
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return (BuildOrNumber + "<br/>" +
                AddressLine + "<br/>" +
                AddressLine2 + "<br/>" +
                PostCode + "<br/>" +
                Borough + " - " + City + "<br/>" +
                Country + "<br/>");
        }



    }
}