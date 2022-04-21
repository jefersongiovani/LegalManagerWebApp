namespace LegalManagerUnitTests.Models.Core
{
    using LegalManager.Models.Core;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Finance;

    public static class InstalmentGeneratorTests
    {
        [Fact]
        public static void CanCallGenerateInstalments()
        {
            var invoice = new Invoice();
            invoice.InvoiceID = 123;
            invoice.TotalCost = 700;
            invoice.CaseLevel = "OISC";
            invoice.DateDue = DateTime.Now;
            invoice.Description = "Description";
            invoice.DateGenerated = DateTime.Now;
            invoice.FirstPayment = 100;
            invoice.PaymentDetails = "bank account to pay";
            invoice.TotalInstalments = 7;
            
            // Act
            var result = InstalmentGenerator.GenerateInstalments(invoice);
            Console.WriteLine(result.ToString());
            
            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public static void CannotCallGenerateInstalmentsWithNullI()
        {
            Assert.Throws<ArgumentNullException>(() => InstalmentGenerator.GenerateInstalments(default(Invoice)));
        }
    }
}