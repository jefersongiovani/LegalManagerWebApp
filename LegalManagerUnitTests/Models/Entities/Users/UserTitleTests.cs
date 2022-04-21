// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="UserTitleTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Users
{
    using LegalManager.Models.Entities.Users;
    using System;
    using Xunit;

    /// <summary>
    /// Class UserTitleTests.
    /// </summary>
    public class UserTitleTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private UserTitle _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTitleTests"/> class.
        /// </summary>
        public UserTitleTests()
        {
            _testClass = new UserTitle();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UserTitle();
            
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
            var testValue = 1518678281;
            
            // Act
            _testClass.Id = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTitle.
        /// </summary>
        [Fact]
        public void CanSetAndGetTitle()
        {
            // Arrange
            var testValue = "TestValue342089358";
            
            // Act
            _testClass.Title = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Title);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAbbreviation.
        /// </summary>
        [Fact]
        public void CanSetAndGetAbbreviation()
        {
            // Arrange
            var testValue = "TestValue723275707";
            
            // Act
            _testClass.Abbreviation = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Abbreviation);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetRegisteredNumber.
        /// </summary>
        [Fact]
        public void CanSetAndGetRegisteredNumber()
        {
            // Arrange
            var testValue = "TestValue1880629357";
            
            // Act
            _testClass.RegisteredNumber = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.RegisteredNumber);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetuser.
        /// </summary>
        [Fact]
        public void CanSetAndGetuser()
        {
            // Arrange
            var testValue = new ApplicationUser();
            
            // Act
            _testClass.user = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.user);
        }
    }
}