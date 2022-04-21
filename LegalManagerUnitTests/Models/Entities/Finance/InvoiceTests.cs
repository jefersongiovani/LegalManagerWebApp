// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="InvoiceTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Finance
{
    using LegalManager.Models.Entities.Finance;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Services;
    using System.Collections.Generic;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class InvoiceTests.
    /// </summary>
    public class InvoiceTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private Invoice _testClass;
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceTests"/> class.
        /// </summary>
        public InvoiceTests()
        {
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _testClass = new Invoice(_context);
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Invoice(_context);
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanCallsetBankAccount.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallsetBankAccount()
        {
            // Arrange
            var details = "TestValue401810687";
            
            // Act
            _testClass.setBankAccount(details);
            
            // Assert
            Assert.Equal(_testClass.PaymentDetails, details);
        }

        /// <summary>
        /// Defines the test method CannotCallsetBankAccountWithInvalidDetails.
        /// </summary>
        /// <param name="value">The value.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotCallsetBankAccountWithInvalidDetails(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.setBankAccount(value));
        }

        /// <summary>
        /// Defines the test method CanCallsetCaseLevel.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallsetCaseLevel()
        {
            // Act
            var level = "Case Level";
            _testClass.setCaseLevel(level);

            // Assert
            Assert.Equal(_testClass.CaseLevel, level);
        }

        /// <summary>
        /// Defines the test method CanCallsetInstallments.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallsetInstallments()
        {
            // Arrange
            var parcels = 12;
            
            // Act
            _testClass.setNumberOfInstallments(parcels);
            
            // Assert
            Assert.Equal(_testClass.TotalInstalments, parcels);
        }

        /// <summary>
        /// Defines the test method CanCalladdServices.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCalladdServices()
        {
            // Arrange
            var services = new ChosenService(127, "Title", "Description", "Type");
            
            // Act
            var result = _testClass.addServices(services);
            
            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Defines the test method CannotCalladdServicesWithNullServices.
        /// </summary>
        [Fact]
        public void CannotCalladdServicesWithNullServices()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.addServices(default(ChosenService)));
        }

        /// <summary>
        /// Defines the test method CanCallgenerateInstalments.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgenerateInstalments()
        {
            var invoice = _testClass;
            invoice.Instalments.Clear();
            // Act
            var result = invoice.generateInstalments();
            
            
            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Defines the test method CanCallgetTotalCost.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetTotalCost()
        {
            // Act
            var result = _testClass.getTotalCost();
            
            // Assert
            Assert.Equal(_testClass.TotalCost, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetTotalDiscount.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetTotalDiscount()
        {
            // Act
            var result = _testClass.getTotalDiscount();

            // Assert
            Assert.Equal(_testClass.TotalDiscount, result);
        }

        /// <summary>
        /// Defines the test method CanCalllistInstalments.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCalllistInstalments()
        {
            // Act
            var result = _testClass.listOfInstalments();

            // Assert
            Assert.Equal(_testClass.Instalments, result);
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

            // Assert
            Assert.Equal(_testClass.Description, result);
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
            Assert.Equal(_testClass.TotalCost, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetReference.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetReference()
        {
            // Act
            var result = _testClass.getReference();

            // Assert
            Assert.Equal(_testClass.ToString(), result);
        }

        /// <summary>
        /// Defines the test method CanCallToString.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallToString()
        {
            // Act
            var result = _testClass.ToString();

            // Assert
            Assert.Equal(_testClass.ToString(), result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetInvoiceID.
        /// </summary>
        [Fact]
        public void CanGetInvoiceID()
        {
            
            // Act
             var result = _testClass.InvoiceID;
            
            // Assert
            Assert.Equal(result, _testClass.InvoiceID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetCaseID.
        /// </summary>
        [Fact]
        public void CanGetCaseID()
        {

            // Act
            var result =_testClass.CaseID;
            
            // Assert
            Assert.Equal(result, _testClass.CaseID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetServiceID.
        /// </summary>
        [Fact]
        public void CanGetServiceID()
        {
            // Act
            var result =_testClass.ServiceID;
            
            // Assert
            Assert.Equal(result, _testClass.ServiceID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDateGenerated.
        /// </summary>
        [Fact]
        public void CanSetAndGetDateGenerated()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.DateGenerated = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DateGenerated);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDateDue.
        /// </summary>
        [Fact]
        public void CanSetAndGetDateDue()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.DateDue = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DateDue);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTotalCost.
        /// </summary>
        [Fact]
        public void CanSetAndGetTotalCost()
        {
            // Arrange
            var testValue = 792687152.07;
            
            // Act
            _testClass.TotalCost = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.TotalCost);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTotalDiscount.
        /// </summary>
        [Fact]
        public void CanSetAndGetTotalDiscount()
        {
            // Arrange
            var testValue = 112371030.09;
            
            // Act
            _testClass.TotalDiscount = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.TotalDiscount);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetFirstPayment.
        /// </summary>
        [Fact]
        public void CanSetAndGetFirstPayment()
        {
            // Arrange
            var testValue = 1731325610.52;
            
            // Act
            _testClass.FirstPayment = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.FirstPayment);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPaymentDetails.
        /// </summary>
        [Fact]
        public void CanSetAndGetPaymentDetails()
        {
            // Arrange
            var testValue = "TestValue219988769";
            
            // Act
            _testClass.PaymentDetails = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.PaymentDetails);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetOverdueFee.
        /// </summary>
        [Fact]
        public void CanSetAndGetOverdueFee()
        {
            // Arrange
            var testValue = 232937920.71;
            
            // Act
            _testClass.OverdueFee = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.OverdueFee);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTotalInstalments.
        /// </summary>
        [Fact]
        public void CanSetAndGetTotalInstalments()
        {
            // Arrange
            var testValue = 256009206;
            
            // Act
            _testClass.TotalInstalments = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.TotalInstalments);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetServices.
        /// </summary>
        [Fact]
        public void CanSetAndGetServices()
        {
            // Arrange
            var testValue = new List<ChosenService>();
            
            // Act
            _testClass.Services = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.Services);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetCaseLevel.
        /// </summary>
        [Fact]
        public void CanSetAndGetCaseLevel()
        {
            // Arrange
            var testValue = "TestValue6247727";
            
            // Act
            _testClass.CaseLevel = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.CaseLevel);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetInstalments.
        /// </summary>
        [Fact]
        public void CanSetAndGetInstalments()
        {
            // Arrange
            var testValue = new List<InvoiceInstalments>();
            
            // Act
            _testClass.Instalments = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.Instalments);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDescription.
        /// </summary>
        [Fact]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue1137523094";
            
            // Act
            _testClass.Description = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Description);
        }
    }
}