// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="Expenses.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using LegalManager.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// Entity class that stores the payments made by the company.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class Expenses : Payable {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Expenses"/> class.
        /// </summary>
        public Expenses() {
        }

        //Attributes

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the expense reference.
        /// </summary>
        /// <value>The expense reference.</value>
        public string ExpenseRef { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is recurrent.
        /// </summary>
        /// <value><c>true</c> if this instance is recurrent; otherwise, <c>false</c>.</value>
        public bool isRecurrent { get; set; }
        /// <summary>
        /// Gets or sets the payment day.
        /// </summary>
        /// <value>The payment day.</value>
        public int PaymentDay { get; set; }
        /// <summary>
        /// Gets or sets the paid to.
        /// </summary>
        /// <value>The paid to.</value>
        public string PaidTo { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; set; }
        /// <summary>
        /// Gets or sets the date paid.
        /// </summary>
        /// <value>The date paid.</value>
        public DateTime DatePaid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is paid.
        /// </summary>
        /// <value><c>true</c> if this instance is paid; otherwise, <c>false</c>.</value>
        public bool isPaid { get; set; } = false;


        //Methods
        /// <summary>
        /// Pays the expense.
        /// </summary>
        public void payExpense() {
            isPaid = true;
        }

        //Payable methods
        /// <inheritdoc />
        public string getDescription()
        {
            return "Name: " + Name
                + "- Is Recurrent: " + isRecurrent +
                " - Type: " + Type + " - " + "Value: " + Value;
        }
        /// <inheritdoc />
        public double getCost()
        {
            return Value;
        }
        /// <inheritdoc />
        public string getReference()
        {
            return "Reference: " + getDescription();
        }

    }
}