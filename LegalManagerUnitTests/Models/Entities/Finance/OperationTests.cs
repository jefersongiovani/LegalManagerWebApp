// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="OperationTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Finance
{
    using LegalManager.Models.Entities.Finance;
    using System;
    using Xunit;

    /// <summary>
    /// Class OperationTests.
    /// </summary>
    public class OperationTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private Operation _testClass;
        /// <summary>
        /// The petit cash
        /// </summary>
        private int _petitCash;
        /// <summary>
        /// The amount
        /// </summary>
        private double _amount;
        /// <summary>
        /// From
        /// </summary>
        private string _from;
        /// <summary>
        /// The desc
        /// </summary>
        private string _desc;
        /// <summary>
        /// The day
        /// </summary>
        private DateTime _day;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationTests"/> class.
        /// </summary>
        public OperationTests()
        {
            _petitCash = 702913212;
            _amount = 944290359.54;
            _from = "TestValue1218480075";
            _desc = "TestValue1728590830";
            _day = DateTime.UtcNow;
            _testClass = new Operation(_petitCash, _amount, _from, _desc, _day);
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Operation(_petitCash, _amount, _from, _desc, _day);
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CannotConstructWithInvalidFrom.
        /// </summary>
        /// <param name="value">The value.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CannotConstructWithInvalidFrom(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Operation(1431393545, 2013535528.29, value, "TestValue1323795368", DateTime.UtcNow));
        }

        /// <summary>
        /// Defines the test method CanCallGetOperationOrder.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallGetOperationOrder()
        {
            // Act
            var result = _testClass.GetOperationOrder();
            
            // Assert
            Assert.True(_testClass.OperationOrder == result);
        }

        /// <summary>
        /// Defines the test method CanCallSetNewOperationDate.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallSetNewOperationDate()
        {
            // Arrange
            var day = DateTime.UtcNow;
            
            // Act
            _testClass.SetNewOperationDate(day);

            // Assert
            Assert.True(_testClass.Date == day);
        }

        /// <summary>
        /// Defines the test method CanCallGetAmount.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallGetAmount()
        {
            // Act
            var result = _testClass.GetAmount();

            // Assert
            Assert.True(_testClass.Value == result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetOperationId.
        /// </summary>
        [Fact]
        public void CanSetAndGetOperationId()
        {
            // Arrange
            var testValue = 2102767594;
            
            // Act
            _testClass.OperationId = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.OperationId);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetOperationOrder.
        /// </summary>
        [Fact]
        public void CanSetAndGetOperationOrder()
        {
            // Arrange
            var testValue = 1100825413;
            
            // Act
            _testClass.OperationOrder = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.OperationOrder);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPetitCashIDFK.
        /// </summary>
        [Fact]
        public void CanSetAndGetPetitCashIDFK()
        {
            // Arrange
            var testValue = 1972353700;
            
            // Act
            _testClass.PetitCashIDFK = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.PetitCashIDFK);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetValue.
        /// </summary>
        [Fact]
        public void CanSetAndGetValue()
        {
            // Arrange
            var testValue = 837692854.02;
            
            // Act
            _testClass.Value = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Value);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDescription.
        /// </summary>
        [Fact]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue501364747";
            
            // Act
            _testClass.Description = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Description);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDate.
        /// </summary>
        [Fact]
        public void CanSetAndGetDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.Date = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Date);
        }
    }
}