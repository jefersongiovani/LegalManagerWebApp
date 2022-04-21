// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-21-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="PayInstalment.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Entities.Finance;

namespace LegalManager.Models.Core
{
    /// <summary>
    /// Class responsible for pay a given instalment and to add this
    /// payment to the BookKeeping control
    /// </summary>
    public class PayInstalment
    {
        /// <summary>
        /// This method changes this instalment to paid status and call
        /// BookKeeping method to add this Total value as a credit operation.
        /// </summary>
        /// <param name="t">The t.</param>
        public static void payTheInstalment(InvoiceInstalments t)
        {
            BookKeeping bookKeeping = new BookKeeping();
            bookKeeping.addCredit(t);
            t.isPaid = true;
        }
    }
}
