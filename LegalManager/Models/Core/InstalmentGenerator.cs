// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-04-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-04-2022
// ***********************************************************************
// <copyright file="InstalmentGenerator.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Entities.Finance;
using System;
using System.Collections.Generic;
namespace LegalManager.Models.Core
{
    /// <summary>
    /// Class responsible for generating the instalments for a given invoice.
    /// 
    /// <author>Jeferson Giovani D. Schneider</author>
    /// </summary>
    public static class InstalmentGenerator
    {
        /// <summary>
        /// Generates the instalments.
        /// </summary>
        /// <param name="i">The Invoice object.</param>
        /// <returns>List&lt;InvoiceInstalments&gt;.</returns>
        public static List<InvoiceInstalments> GenerateInstalments(Invoice i)
        {
            if (i == null)
            {
                throw new ArgumentNullException(nameof(i));
            }
            ///The counter starts with 1 because at least one instalment will be generated for the first payment.
            int counter = 1;

            List<InvoiceInstalments> instalments = new List<InvoiceInstalments>();

            /// Creating the initial instalment to discount the first parcel
            InvoiceInstalments inst = new InvoiceInstalments();
            inst.Total = i.FirstPayment;
            inst.InvoiceID = i.InvoiceID;
            inst.DueDate = i.DateDue;
            inst.Fee = i.OverdueFee;
            inst.isPaid = false;
            inst.Invoice = i;
            inst.InstalmentNumber = counter;
            inst.PaymentDetails = i.PaymentDetails;
            instalments.Add(inst);

            ///The Total that generates the instalment values
            double thisTotal = i.TotalCost - i.FirstPayment;

            ///The total number of instalments less the first instalment
            int numberOfParcels = i.TotalInstalments - counter;

            counter++; ///used as iinstalment #order for the invoice

            DateTime day = i.DateDue;

            ///Testing condition: there are any parcels left?
            if (numberOfParcels > 0)
            {
                DateTime newDue = day.AddDays(30); ///updating the due date to more 30 days

                /// Setting up the instalment value, and round it to two decimal places.
                double parcelValue = Math.Round((thisTotal / numberOfParcels), 2);

                /// Loop for creating the remaining instalments
                for (int n = counter; numberOfParcels > 0; n++)
                {
                    InvoiceInstalments instalment = new InvoiceInstalments();
                    instalment.InvoiceID = i.InvoiceID;
                    instalment.InstalmentNumber = n;
                    instalment.Value = parcelValue;
                    instalment.DueDate = newDue;
                    instalment.Total = parcelValue;
                    instalment.Fee = i.OverdueFee;
                    instalment.isPaid = false;
                    instalment.Invoice = i;
                    instalment.PaymentDetails = "Instalment " + counter + "/" + i.TotalInstalments + " - " + i.PaymentDetails;

                    ///Add to the list
                    instalments.Add(instalment);

                    counter++;
                    numberOfParcels--;
                    newDue.AddDays(30);
                }
            }
            return instalments;
        }
    }
}