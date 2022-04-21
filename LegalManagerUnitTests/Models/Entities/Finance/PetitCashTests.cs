// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="PetitCashTests.cs" company="LegalManagerUnitTests">
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
    using System.Collections.Generic;

    /// <summary>
    /// Class PetitCashTests.
    /// </summary>
    public class PetitCashTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private PetitCash _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetitCashTests"/> class.
        /// </summary>
        public PetitCashTests()
        {
            _testClass = new PetitCash();
            _testClass.PetitCashID = 1;
            _testClass.Balance = 100;
            _testClass.isClosed = false;

        }

        /// <summary>
        /// Defines the test method CanCallcloseMonth.
        /// </summary>
        [Fact]
        public void CanCallcloseMonth()
        {
            // Act
            _testClass.closeMonth();

            // Assert
            Assert.True(_testClass.isClosed);
        }

        /// <summary>
        /// Defines the test method CanCallgetBalance.
        /// </summary>
        [Fact]
        public void CanCallgetBalance()
        {
            // Act
            var result = _testClass.getBalance();

            // Assert
            Assert.Equal(_testClass.Balance, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetDescription.
        /// </summary>
        [Fact]
        public void CanCallgetDescription()
        {
            // Act
            var result = _testClass.getDescription();

            // Assert
            Assert.Equal(_testClass.getDescription(), result);
        }

        /// <summary>
        /// Defines the test method CanCallgetCost.
        /// </summary>
        [Fact]
        public void CanCallgetCost()
        {
            // Act
            var result = _testClass.getCost();

            // Assert
            Assert.Equal(_testClass.Balance, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetReference.
        /// </summary>
        [Fact]
        public void CanCallgetReference()
        {
            // Act
            var result = _testClass.getReference();

            // Assert
            Assert.Equal(_testClass.getReference(), result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPetitCashID.
        /// </summary>
        [Fact]
        public void CanSetAndGetPetitCashID()
        {
            // Arrange
            var testValue = 1882176962;

            // Act
            _testClass.PetitCashID = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PetitCashID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetStartDate.
        /// </summary>
        [Fact]
        public void CanSetAndGetStartDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.StartDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StartDate);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetBalance.
        /// </summary>
        [Fact]
        public void CanSetAndGetBalance()
        {
            // Arrange
            var testValue = 390065132.16;

            // Act
            _testClass.Balance = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Balance);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetOperationsList.
        /// </summary>
        [Fact]
        public void CanSetAndGetOperationsList()
        {
            // Arrange
            var testValue = Substitute.For<ICollection<Operation>>();

            // Act
            _testClass.OperationsList = testValue;

            // Assert
            Assert.Same(testValue, _testClass.OperationsList);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetisClosed.
        /// </summary>
        [Fact]
        public void CanSetAndGetisClosed()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.isClosed = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.isClosed);
        }

    }
}