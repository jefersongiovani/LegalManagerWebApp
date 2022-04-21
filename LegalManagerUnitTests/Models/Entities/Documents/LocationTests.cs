// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="LocationTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Documents
{
    using LegalManager.Models.Entities.Documents;
    using System;
    using Xunit;

    /// <summary>
    /// Class LocationTests.
    /// </summary>
    public class LocationTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private Location _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationTests"/> class.
        /// </summary>
        public LocationTests()
        {
            _testClass = new Location();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Location();
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanCallToString.
        /// </summary>
        [Fact]
        public void CanCallToString()
        {
            // Act
            var result = _testClass.ToString();
            
            // Assert
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetId.
        /// </summary>
        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 466965853;
            
            // Act
            _testClass.Id = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetLocationName.
        /// </summary>
        [Fact]
        public void CanSetAndGetLocationName()
        {
            // Arrange
            var testValue = "TestValue2032475214";
            
            // Act
            _testClass.LocationName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.LocationName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPosition.
        /// </summary>
        [Fact]
        public void CanSetAndGetPosition()
        {
            // Arrange
            var testValue = "TestValue995240980";
            
            // Act
            _testClass.Position = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Position);
        }
    }
}