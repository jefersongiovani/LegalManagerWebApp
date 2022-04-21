// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="BankAccount.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;

namespace LegalManager.Models.Entities.Finance
{
    /// <summary>
    /// Entity class that stores the Company's bank accounts.
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class BankAccount {


        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        public BankAccount() {
        }

        //Attributes
        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        [Key]
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>The company identifier.</value>
        public string CompanyID {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        public String AccountName {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the account pay.
        /// </summary>
        /// <value>The name of the account pay.</value>
        public String AccountPayName {
            get; set;
        }

        /// <summary>
        /// Gets or sets the account sort code.
        /// </summary>
        /// <value>The account sort code.</value>
        public String AccountSortCode {
            get; set;
        }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public int AccountNumber {
            get; set;
        }

        /// <summary>
        /// Gets or sets the account iban.
        /// </summary>
        /// <value>The account iban.</value>
        public String AccountIBAN {
            get; set;
        }

        /// <summary>
        /// Gets or sets the account bic.
        /// </summary>
        /// <value>The account bic.</value>
        public String AccountBIC {
            get; set;
        }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>The type of the account.</value>
        public String AccountType {
            get; set;
        }


        /// <summary>
        /// Gets the account details.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getAccountDetails() {
            return "Account Name: " + AccountName + " - Pay Name: " + AccountPayName + "/n "
                + AccountSortCode + " - " + AccountNumber;
        }

        /// <summary>
        /// Gets the account basics.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getAccountBasics() {
            return "Account Name: " + AccountName + " - Pay Name: " + AccountPayName + "/n "
               + AccountSortCode + " - " + AccountNumber;
        }


    }
}