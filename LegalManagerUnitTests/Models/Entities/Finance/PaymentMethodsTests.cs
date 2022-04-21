// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="PaymentMethodsTests.cs" company="LegalManagerUnitTests">
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
    /// Class PaymentMethodsTests.
    /// </summary>
    public class PaymentMethodsTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private PaymentMethods _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodsTests"/> class.
        /// </summary>
        public PaymentMethodsTests()
        {
            _testClass = new PaymentMethods();
        }

        /// <summary>
        /// Defines the test method CanSetAndGetId.
        /// </summary>
        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 998684599;
            
            // Act
            _testClass.Id = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetName.
        /// </summary>
        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1500149895";
            
            // Act
            _testClass.Name = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }
    }
}