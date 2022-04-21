// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="InvoiceInstalments.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using AssertLibrary;
using LegalManager.Data;
using LegalManager.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// The entity class that generates/stores the installments for a given invoice.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class InvoiceInstalments : Payable {

        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        //Constructor (empty) for EF
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceInstalments"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public InvoiceInstalments(ApplicationDbContext context) {
            this._context = context; 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceInstalments"/> class for EF.
        /// </summary>
        public InvoiceInstalments() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceInstalments"/> class.
        /// </summary>
        /// <param name="i">The Invoice object which this instalment is for.</param>
        public InvoiceInstalments(Invoice i)
        {
            if (IsNullOrEmptyInvoice(i))
            {
                throw new ArgumentNullException();
            }
            this.InvoiceID = i.InvoiceID;
            this.isPaid = false;
            this.InstalmentNumber = i.TotalInstalments;
            this.Value = i.TotalCost;
            this.DueDate = i.DateDue;
            this.Fee = i.OverdueFee;
            this.Total = i.TotalCost;
            this.Invoice = i;
            this.PaymentDetails = i.PaymentDetails;
        }

        //Attributes
        /// <summary>
        /// Gets or sets the instalment identifier.
        /// </summary>
        /// <value>The instalment identifier.</value>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InstalmentID { get; set; }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>The invoice identifier.</value>
        /// ForeignKey from the Invoice Class
        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }

        /// <summary>
        /// Number generated for the instalment number
        /// </summary>
        /// <value>The instalment order number.</value>
        public int InstalmentNumber { get; set; }

        /// <summary>
        /// Initial value of the instalment from the invoice
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; set; }

        /// <summary>
        /// If an instalment get overdue then a fee is applied to it.
        /// This attribute receives a percentual value(8.5).
        /// </summary>
        /// <value>The fee.</value>
        public double Fee { get; set; }

        /// <summary>
        /// Total to be applied from calculations.
        /// It is calculated with the percentual value of Fee
        /// and the value is applied to Total
        /// </summary>
        /// <value>The excess fee.</value>
        public double ExcessFee { get; set; }

        /// <summary>
        /// The total to be paid. If it has a excess charge to be applied
        /// it is added here.
        /// </summary>
        /// <value>The total.</value>
        public double Total { get; set; }

        /// <summary>
        /// Defines if an instalment is paid or not.
        /// Default value is false.
        /// </summary>
        /// <value><c>true</c> if this instance is paid; otherwise, <c>false</c>.</value>
        public bool isPaid { get; set; } = false;

        /// <summary>
        /// Date to pay the invoice.
        /// </summary>
        /// <value>The due date.</value>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The Invoice object that owns this instalment.
        /// </summary>
        /// <value>The invoice.</value>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// The string
        /// </summary>
        /// <value>The payment details.</value>
        public string PaymentDetails { get; set; }


        //methods


        /// <summary>
        /// This method applies a fee for overdue payment and update the value for this instalment.
        /// </summary>
        /// <param name="fee">Double - the percentage fee to be applied(e.g. 8.5, 9.2, etc.)</param>
        public void applyFee(double fee) {
            double total = Value * (fee / 100);
            this.Fee = fee;
            this.Total += total;
        }

        /// <summary>
        /// Changes the due date for this instalment
        /// </summary>
        /// <param name="d">DateTime</param>
        public void changeDueDate(DateTime d) {
            this.DueDate=d;
        }

        //Payable methods from Payable Interface

        /// <summary>
        /// Gets the description of this instalment.
        /// </summary>
        /// <returns>String</returns>
        public string getDescription()
        {
            return this.ToString();
        }

        /// <summary>
        /// Gets the value of this instalment.
        /// </summary>
        /// <returns>Double the cost of the given object.</returns>
        public double getCost()
        {
            return this.Total;
        }

        /// <summary>
        /// Gets the reverece description of this instalment.
        /// </summary>
        /// <returns>String the reference code.</returns>
        public string getReference()
        {
            return this.InvoiceID + this.InstalmentNumber 
                + " - Instalment serial#: " + this.InstalmentID;
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "Invoice: " + this.InvoiceID
                + " - Instalment:" + this.InstalmentNumber
                + " - " + this.Invoice.getDescription();
        }

        /// <summary>
        /// Determines whether an Invoice has empty fields [the specified object].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if [is null or empty invoice] [the specified object]; otherwise, <c>false</c>.</returns>
        private bool IsNullOrEmptyInvoice(Invoice obj)
        {

            if (Invoice.ReferenceEquals(obj, null))
                return true;

            return obj.GetType().GetProperties()
                .All(x => IsNullOrEmptyField(x.GetValue(obj)));
            
            
        }

        /// <summary>
        /// Determines whether int and bool fields are empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is null or empty field] [the specified value]; otherwise, <c>false</c>.</returns>
        private bool IsNullOrEmptyField(object value)
        {
            if (object.ReferenceEquals(value, null))
                return true;

            if (value is int)
            {
                return (int)value <= 0;
            }

            else if (value is double)
            {
                return (double)value <= 0;
            }


            return false;
        }

    }
}