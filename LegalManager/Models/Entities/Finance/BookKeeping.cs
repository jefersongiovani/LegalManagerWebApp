// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="BookKeeping.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using AssertLibrary;
using LegalManager.Models.Entities.Finance;
using LegalManager.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// Entity class that stores the credit/debit information.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class BookKeeping {


        //Empty onstructor for EF
        /// <summary>
        /// Initializes a new instance of the <see cref="BookKeeping"/> class.
        /// </summary>
        public BookKeeping() {
        }

        //Attributes
        /// <summary>
        /// Gets or sets the bid.
        /// </summary>
        /// <value>The bid.</value>
        [Key]
        public int Bid { get; set; }

        /// <summary>
        /// The date the operation is registered. Cannot be null.
        /// </summary>
        /// <value>The operation date.</value>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// Description of the operation. Cannot be null.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// The value of the operation. Can be positive or negative
        /// double/decimal. Here the value represents the money of the transaction.
        /// Cannot be null.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; set; }

        /// <summary>
        /// Types of operations
        /// supported for the system. Cannot be null
        /// to assign an operation.
        /// </summary>
        /// <value>The operation.</value>
        public string Operation { get; set; }

        /// <summary>
        /// @param InvoiceInstallments parcel
        /// </summary>
        /// <param name="p">The p.</param>
        /// <exception cref="System.ArgumentNullException">p</exception>
        /// Methods
        public void addCredit(Payable p) {
            try
            {
                if(p.getCost() == null || p.getDescription() == null)
                {
                    throw new ArgumentNullException(nameof(p));
                }
                else if (p.getCost() <= 0)
                {
                    throw new ArgumentNullException(nameof(p));
                }
                else
                {
                    this.OperationDate = DateTime.Now.Date;
                    this.Description = p.getDescription();
                    this.Operation = OperationType.CREDIT.ToString();
                    this.Value += p.getCost();
                }
            }
            catch(ArgumentException e) {

                throw new ArgumentNullException(nameof(p));
            }
            
        }

        /// <summary>
        /// @param Expenses debit
        /// </summary>
        /// <param name="p">The p.</param>
        /// <exception cref="System.ArgumentException">p</exception>
        /// <exception cref="System.ArgumentNullException">p</exception>
        public void addDebit(Payable p) {

            try
            {
                if (p == null || p.getDescription() == null)
                {
                    throw new ArgumentException(nameof(p));
                }
                else if (p.getCost() >= 0)
                {
                    throw new ArgumentException(nameof(p));
                }
                else
                {
                    this.OperationDate = DateTime.Now.Date;
                    this.Description = p.getDescription();
                    this.Operation = OperationType.DEBIT.ToString();
                    this.Value += p.getCost();
                }
            }
            catch (ArgumentException e)
            {

                throw new ArgumentNullException(nameof(p));
            }
        }


    }
}