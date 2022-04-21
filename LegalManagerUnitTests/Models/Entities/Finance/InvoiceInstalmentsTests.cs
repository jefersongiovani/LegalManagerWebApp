// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="InvoiceInstalmentsTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Finance
{
    using LegalManager.Models.Entities.Finance;
    using System;
    using Xunit;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class InvoiceInstalmentsTests.
    /// </summary>
    public class InvoiceInstalmentsTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private InvoiceInstalments _testClass;
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// The i
        /// </summary>
        private Invoice _i;
        /// <summary>
        /// The invoice identifier
        /// </summary>
        private int _invoiceId;
        /// <summary>
        /// The instlment number
        /// </summary>
        private int _instlmentNumber;
        /// <summary>
        /// The parcel value
        /// </summary>
        private double _parcelValue;
        /// <summary>
        /// The datedue
        /// </summary>
        private DateTime _datedue;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceInstalmentsTests"/> class.
        /// </summary>
        public InvoiceInstalmentsTests()
        {
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _i = new Invoice(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()));
            _i.InvoiceID = 2020283085;
            _i.TotalInstalments = 5;
            _i.TotalCost = 382.23;
            _i.DateDue = DateTime.UtcNow;
            _i.FirstPayment = 100;
            _i.CaseID = 100;
            _i.CaseLevel = "Level";
            _i.DateGenerated = DateTime.Today;
            _i.Description = "Payment case";
            _i.OverdueFee = 8.5;
            _i.Services.Add(new LegalManager.Models.Entities.Services.ChosenService());
            _i.Instalments.Add(new InvoiceInstalments());

            _testClass = new InvoiceInstalments(_i);
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new InvoiceInstalments(_context);
            
            // Assert
            Assert.NotNull(instance);
            
            // Act
            instance = new InvoiceInstalments(_i);
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanCallapplyFee.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallapplyFee()
        {
            // Arrange
            var fee = 8.5;

            // Act
            var value = _testClass.Total;
            _testClass.applyFee(fee);
            
            // Assert
            Assert.True(_testClass.getCost() > value);
        }

        /// <summary>
        /// Defines the test method CanCallchangeDueDate.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallchangeDueDate()
        {
            // Arrange
            var d = DateTime.UtcNow;
            
            // Act
            _testClass.changeDueDate(d);
            
            // Assert
            Assert.True(_testClass.DueDate == d);
        }

        /// <summary>
        /// Defines the test method CanCallgetDescription.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetDescription()
        {
            // Act
            var result = _testClass.getDescription();
            var result2 = _testClass.ToString();
            
            // Assert
            Assert.Equal(result, result2);
        }

        /// <summary>
        /// Defines the test method CanCallgetCost.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetCost()
        {
            // Act
            var result = _testClass.getCost();
            
            // Assert
            Assert.Equal(_testClass.Total, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetReference.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetReference()
        {
            var refer = _testClass.InvoiceID + _testClass.InstalmentNumber
                + " - Instalment serial#: " + _testClass.InstalmentID;
            // Act
            var result = _testClass.getReference();
            
            // Assert
            Assert.Equal(refer, result);
        }


        /// <summary>
        /// Defines the test method CanSetAndGetInstalmentID.
        /// </summary>
        [Fact]
        public void CanSetAndGetInstalmentID()
        {
            // Arrange
            var testValue = 566569093;
            
            // Act
            _testClass.InstalmentID = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.InstalmentID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetInvoiceID.
        /// </summary>
        [Fact]
        public void CanSetAndGetInvoiceID()
        {
            // Arrange
            var testValue = 1150744257;
            
            // Act
            _testClass.InvoiceID = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.InvoiceID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetInstalmentNumber.
        /// </summary>
        [Fact]
        public void CanSetAndGetInstalmentNumber()
        {
            // Arrange
            var testValue = 365302426;
            
            // Act
            _testClass.InstalmentNumber = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.InstalmentNumber);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetValue.
        /// </summary>
        [Fact]
        public void CanSetAndGetValue()
        {
            // Arrange
            var testValue = 1172179205.51;
            
            // Act
            _testClass.Value = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Value);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetFee.
        /// </summary>
        [Fact]
        public void CanSetAndGetFee()
        {
            // Arrange
            var testValue = 2083729519.08;
            
            // Act
            _testClass.Fee = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Fee);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetExcessFee.
        /// </summary>
        [Fact]
        public void CanSetAndGetExcessFee()
        {
            // Arrange
            var testValue = 537189369.75;
            
            // Act
            _testClass.ExcessFee = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.ExcessFee);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTotal.
        /// </summary>
        [Fact]
        public void CanSetAndGetTotal()
        {
            // Arrange
            var testValue = 2047504874.58;
            
            // Act
            _testClass.Total = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Total);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetisPaid.
        /// </summary>
        [Fact]
        public void CanSetAndGetisPaid()
        {
            // Arrange
            var testValue = false;
            
            // Act
            _testClass.isPaid = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.isPaid);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDueDate.
        /// </summary>
        [Fact]
        public void CanSetAndGetDueDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.DueDate = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DueDate);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetInvoice.
        /// </summary>
        [Fact]
        public void CanSetAndGetInvoice()
        {
            // Arrange
            var testValue = new Invoice(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()));
            
            // Act
            _testClass.Invoice = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.Invoice);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPaymentDetails.
        /// </summary>
        [Fact]
        public void CanSetAndGetPaymentDetails()
        {
            // Arrange
            var testValue = "TestValue1887068932";
            
            // Act
            _testClass.PaymentDetails = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.PaymentDetails);
        }
    }
}