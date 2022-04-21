// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ExpensesTests.cs" company="LegalManagerUnitTests">
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
    /// Class ExpensesTests.
    /// </summary>
    public class ExpensesTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private Expenses _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpensesTests"/> class.
        /// </summary>
        public ExpensesTests()
        {
            _testClass = new Expenses();
            _testClass.Name = "nameExpense";
            _testClass.ExpenseRef = "ref8987239487";
            _testClass.isRecurrent = true;
            _testClass.isPaid = false;
            _testClass.Type = "expense";
            _testClass.Value = 323.0;
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Expenses();
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanCallpayExpense.
        /// </summary>
        [Fact]
        public void CanCallpayExpense()
        {
            // Act
            _testClass.payExpense();
            
            // Assert
            Assert.True(_testClass.isPaid);
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
            Assert.True(_testClass.getDescription() == result);
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
            Assert.True(_testClass.getCost() == result);
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
            Assert.True(_testClass.getReference() == result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetId.
        /// </summary>
        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 508647950;
            
            // Act
            _testClass.Id = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetExpenseRef.
        /// </summary>
        [Fact]
        public void CanSetAndGetExpenseRef()
        {
            // Arrange
            var testValue = "TestValue944426212";
            
            // Act
            _testClass.ExpenseRef = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.ExpenseRef);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetName.
        /// </summary>
        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue619129017";
            
            // Act
            _testClass.Name = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetisRecurrent.
        /// </summary>
        [Fact]
        public void CanSetAndGetisRecurrent()
        {
            // Arrange
            var testValue = true;
            
            // Act
            _testClass.isRecurrent = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.isRecurrent);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPaymentDay.
        /// </summary>
        [Fact]
        public void CanSetAndGetPaymentDay()
        {
            // Arrange
            var testValue = 1057211892;
            
            // Act
            _testClass.PaymentDay = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.PaymentDay);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPaidTo.
        /// </summary>
        [Fact]
        public void CanSetAndGetPaidTo()
        {
            // Arrange
            var testValue = "TestValue1623997592";
            
            // Act
            _testClass.PaidTo = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.PaidTo);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetType.
        /// </summary>
        [Fact]
        public void CanSetAndGetType()
        {
            // Arrange
            var testValue = "TestValue1094449650";
            
            // Act
            _testClass.Type = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Type);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetValue.
        /// </summary>
        [Fact]
        public void CanSetAndGetValue()
        {
            // Arrange
            var testValue = 1112190690L;
            
            // Act
            _testClass.Value = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Value);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDatePaid.
        /// </summary>
        [Fact]
        public void CanSetAndGetDatePaid()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.DatePaid = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DatePaid);
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
    }
}