// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="Operation.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// Class Operation.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Operation"/> class from being created.
        /// </summary>
        private Operation() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        /// <param name="petitCash">The petit cash.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="from">From.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="day">The day.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public Operation(int petitCash, double amount, string from, string desc, DateTime day)
        {
            if(petitCash != null && amount != null && !string.IsNullOrEmpty(from) && !string.IsNullOrWhiteSpace(desc))
            {
                this.PetitCashIDFK = petitCash;
                this.Value = amount;
                this.Description = desc;
                this.Date = day;
                if (this.OperationOrder > 1)
                {
                    this.OperationOrder += 1;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        /// <summary>
        /// Gets or sets the operation identifier.
        /// </summary>
        /// <value>The operation identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperationId { get; set; }

        /// <summary>
        /// Gets or sets the operation order.
        /// </summary>
        /// <value>The operation order.</value>
        public int OperationOrder { get; set; } = 1;


        /// <summary>
        /// Gets or sets the petit cash idfk.
        /// </summary>
        /// <value>The petit cash idfk.</value>
        [ForeignKey("PetitCashID")]
        public int PetitCashIDFK { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets the operation order.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// Methods

        public int GetOperationOrder()
        {
            return this.OperationOrder;
        }

        /// <summary>
        /// Sets the new operation date.
        /// </summary>
        /// <param name="day">The day.</param>
        public void SetNewOperationDate(DateTime day)
        {
            this.Date = day;
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetAmount()
        {
            return this.Value;
        }
        
    
    }
}
