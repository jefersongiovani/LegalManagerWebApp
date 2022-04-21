// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="EventTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Calendar
{
    using LegalManager.Models.Entities.Calendar;
    using System;
    using Xunit;

    /// <summary>
    /// Class EventTests.
    /// </summary>
    public class EventTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private Event _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventTests"/> class.
        /// </summary>
        public EventTests()
        {
            _testClass = new Event();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Event();
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetId.
        /// </summary>
        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1694749941;
            
            // Act
            _testClass.Id = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetStart.
        /// </summary>
        [Fact]
        public void CanSetAndGetStart()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.Start = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Start);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetEnd.
        /// </summary>
        [Fact]
        public void CanSetAndGetEnd()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.End = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.End);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetText.
        /// </summary>
        [Fact]
        public void CanSetAndGetText()
        {
            // Arrange
            var testValue = "TestValue2068324233";
            
            // Act
            _testClass.Text = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Text);
        }
    }
}