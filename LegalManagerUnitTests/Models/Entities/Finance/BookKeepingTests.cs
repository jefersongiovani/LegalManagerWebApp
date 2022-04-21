// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="BookKeepingTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Finance
{
    using LegalManager.Models.Entities.Finance;
    using System;
    using Xunit;
    using NSubstitute;
    using LegalManager.Models.Interfaces;

    /// <summary>
    /// Class BookKeepingTests.
    /// </summary>
    public class BookKeepingTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private BookKeeping _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookKeepingTests"/> class.
        /// </summary>
        public BookKeepingTests()
        {
            _testClass = new BookKeeping();
        }

        /// <summary>
        /// Defines the test method CanCalladdCredit.
        /// </summary>
        [Fact]
        public void CanCalladdCredit()
        {
            // Arrange
            var p = new PetitCash();
            p.Balance = 100;

            // Act
            var result = _testClass.Value;
            _testClass.addCredit(p);

            // Assert
            Assert.True(_testClass.Value == result + 100);
        }

        /// <summary>
        /// Defines the test method CannotCalladdCreditWithNullP.
        /// </summary>
        [Fact]
        public void CannotCalladdCreditWithNullP()
        {
            var pay = new PetitCash();
            Assert.Throws<ArgumentNullException>(() => _testClass.addCredit(pay));
        }

        /// <summary>
        /// Defines the test method CanCalladdDebit.
        /// </summary>
        [Fact]
        public void CanCalladdDebit()
        {
            // Arrange
            var p = new PetitCash();
            p.Balance = -100;

            // Act
            var result = _testClass.Value;
            _testClass.addDebit(p);

            // Assert
            Assert.True(_testClass.Value == result - 100);
        }

        /// <summary>
        /// Defines the test method CannotCalladdDebitWithNullP.
        /// </summary>
        [Fact]
        public void CannotCalladdDebitWithNullP()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.addDebit(default(Payable)));
        }

        /// <summary>
        /// Defines the test method CanSetAndGetBid.
        /// </summary>
        [Fact]
        public void CanSetAndGetBid()
        {
            // Arrange
            var testValue = 1309019986;
            
            // Act
            _testClass.Bid = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Bid);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetOperationDate.
        /// </summary>
        [Fact]
        public void CanSetAndGetOperationDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.OperationDate = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.OperationDate);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDescription.
        /// </summary>
        [Fact]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue1390540267";
            
            // Act
            _testClass.Description = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Description);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetValue.
        /// </summary>
        [Fact]
        public void CanSetAndGetValue()
        {
            // Arrange
            var testValue = 744564149.51;
            
            // Act
            _testClass.Value = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Value);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetOperation.
        /// </summary>
        [Fact]
        public void CanSetAndGetOperation()
        {
            // Arrange
            var testValue = "TestValue25812691";
            
            // Act
            _testClass.Operation = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Operation);
        }
    }
}