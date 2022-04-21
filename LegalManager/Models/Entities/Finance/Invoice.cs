// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="Invoice.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Data;
using LegalManager.Models.Core;
using LegalManager.Models.Entities.Services;
using LegalManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// Entity class that  builds the main invoice and is the bases to compound items and invoice installments.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class Invoice : Payable {

        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Invoice(ApplicationDbContext context) {
            this._context = context;
        }

        /// Empty Constructor for EF
        public Invoice() { }

        //Attributes

        /// <summary>
        /// ID that identifies the invoice
        /// </summary>
        /// <value>The invoice identifier.</value>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }

        /// <summary>
        /// Given CaseID for the Invoice. Can be null if
        /// there is at least one ServiceID.
        /// </summary>
        /// <value>The case identifier.</value>
        public int CaseID { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        /// Service identifier
        public int ServiceID { get; set; }

        /// <summary>
        /// Date the invoice was created
        /// </summary>
        /// <value>The date generated.</value>
        public DateTime DateGenerated { get; set; }

        /// <summary>
        /// First date due for instalment 1.
        /// </summary>
        /// <value>The date due.</value>
        public DateTime DateDue { get; set; }

        /// <summary>
        /// The TotalCost is the final value for this Invoice.
        /// </summary>
        /// <value>Double - The total cost.</value>
        public double TotalCost { get; set; }

        /// <summary>
        /// The TotalDiscount is the total discount given before the TotalCost
        /// </summary>
        /// <value>Double - The total discount.</value>
        public double TotalDiscount { get; set; }

        /// <summary>
        /// The value of the agreed first payment.
        /// </summary>
        /// <value>Double - The first payment.</value>
        public double FirstPayment { get; set; }

        /// <summary>
        /// The bank account for the payment(s)
        /// </summary>
        /// <value>The payment details.</value>
        public string PaymentDetails { get; set; }

        /// <summary>
        /// The overdue fee in case of instalment overdue
        /// </summary>
        /// <value>Double - The overdue fee as percentage (8.5).</value>
        public double OverdueFee { get; set; }

        /// <summary>
        /// Total number of instalments for this invoice.
        /// </summary>
        /// <value>Int The total instalments.</value>
        public int TotalInstalments { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>The services Object.</value>
        public List<ChosenService> Services { get; set; } = new List<ChosenService>();

        /// <summary>
        /// Gets or sets the case level.
        /// </summary>
        /// <value>The case level.</value>
        public string CaseLevel { get; set; }

        /// <summary>
        /// Gets or sets the instalments.
        /// </summary>
        /// <value>The instalments.</value>
        public List<InvoiceInstalments> Instalments { get; set; } = new List<InvoiceInstalments>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }


        //Methods
        /// <summary>
        /// Sets the bank account.
        /// </summary>
        /// <param name="details">The details.</param>
        public void setBankAccount(string details)
        {
            if (string.IsNullOrWhiteSpace(details))
            {
                throw new ArgumentNullException(nameof(details));
            }
            this.PaymentDetails = details;
        }
        /// <summary>
        /// Sets the case level.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void setCaseLevel(string level)
        {
            if (string.IsNullOrWhiteSpace(level))
            {
                throw new ArgumentNullException(nameof(level));
            }
            this.CaseLevel = level;
        }

        /// <summary>
        /// This method sets the number of instalments to be created.
        /// </summary>
        /// <param name="parcels">The parcels.</param>
        public void setNumberOfInstallments(int parcels)
        {
            if (parcels <= 0)
            {
                throw new ArgumentNullException(nameof(parcels));
            }
            this.TotalInstalments = parcels;
        }
        /// <summary>
        /// Adds the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public bool addServices(ChosenService services)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            this.Services.Add(services);
            return true;
        }

        /// <summary>
        /// This method generates the instalments.
        /// This method uses the GenerateInstalments from the class Core.InstalmentGenerator
        /// to create the instalments.
        /// If activated twice it excludes the made instalments and generates new ones.
        /// </summary>
        public bool generateInstalments()
        {
            try
            {
                ExcludeInstalments();

                List<InvoiceInstalments> returnedList = InstalmentGenerator.GenerateInstalments(this);
                foreach (InvoiceInstalments instalment in returnedList)
                {
                    Instalments.Add(instalment);
                }
                return true;
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("There are already created instalments. Cannot generate duplicated instalments.");
            }
          
        }

        /// <summary>
        /// Excludes the instalments in this invoice.
        /// </summary>
        private void ExcludeInstalments()
        {
            this.Instalments.Clear();
        }


        /// <summary>
        /// Gets the total cost.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double getTotalCost()
        {
            return this.TotalCost;
        }
        /// <summary>
        /// Gets the total discount.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double getTotalDiscount()
        {
            return this.TotalDiscount;
        }
        /// <summary>
        /// Lists the of instalments.
        /// </summary>
        /// <returns>List&lt;InvoiceInstalments&gt;.</returns>
        public List<InvoiceInstalments> listOfInstalments()
        {
            return this.Instalments;
        }

        //Payable methods
        /// <inheritdoc />
        public string getDescription()
        {
            return this.Description;
        }
        /// <inheritdoc />
        public double getCost()
        {
            return this.TotalCost;
        }
        /// <inheritdoc />
        public string getReference()
        {
            return this.ToString();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "Invoice Date: " + DateGenerated
                + " - Invoice Number: " + InvoiceID + "</br>"
                + "Total value: £ " + TotalCost + "</br>"
                + "Total discount £ " + TotalDiscount + "</br>"
                + "Initial due date: " + DateDue;
        }
    }
}