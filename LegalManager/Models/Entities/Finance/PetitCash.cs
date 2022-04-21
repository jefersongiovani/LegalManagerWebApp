// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="PetitCash.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using AssertLibrary;
using LegalManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// Class that provides the Petit cash functionality.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class PetitCash : Payable {

        /// <summary>
        /// Class that provides the Petit cash functionality.
        /// @author Jeferson G.D. Schneider
        /// </summary>

        //Constructor for EF
        public PetitCash() {
        }

        //Attributes
        /// <summary>
        /// Gets or sets the petit cash identifier.
        /// </summary>
        /// <value>The petit cash identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetitCashID { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public double Balance { get; set; } = 0;

        /// <summary>
        /// Gets or sets the operations list.
        /// </summary>
        /// <value>The operations list.</value>
        public virtual ICollection<Operation> OperationsList { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed.
        /// </summary>
        /// <value><c>true</c> if this instance is closed; otherwise, <c>false</c>.</value>
        public bool isClosed { get; set; } = false;

        /// <summary>
        /// Closes the month.
        /// </summary>
        /// Methods
        public void closeMonth() {
            
            isClosed = true;
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double getBalance() {

            return this.Balance;
        }

        //Payable methods
        /// <inheritdoc />
        public string getDescription()
        {
            return "Petit Cash ID: " + PetitCashID
                + " - Date Created: " + StartDate
                + " - Atual Balance: £" + getBalance()
                + " - Is closed: " + isClosed;
        }
        /// <inheritdoc />
        public double getCost()
        {
            return this.Balance;
        }
        /// <inheritdoc />
        public string getReference()
        {
            return getDescription();    
        }

        /// <summary>
        /// Updates the balance.
        /// </summary>
        public void UpdateBalance()
        {
            double total = 0;

            foreach (Operation op in OperationsList)
            {
                total += op.Value;
            }
            this.Balance = total;
        }


    }
}