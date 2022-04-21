// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="SystemUserTypeTests.cs" company="LegalManagerUnitTests">
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
    /// Class SystemUserTypeTests.
    /// </summary>
    public class SystemUserTypeTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private SystemUserType _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemUserTypeTests"/> class.
        /// </summary>
        public SystemUserTypeTests()
        {
            _testClass = new SystemUserType();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new SystemUserType();
            
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
            var testValue = 798009560;
            
            // Act
            _testClass.Id = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTypeName.
        /// </summary>
        [Fact]
        public void CanSetAndGetTypeName()
        {
            // Arrange
            var testValue = "TestValue1220197272";
            
            // Act
            _testClass.TypeName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.TypeName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetdateCreated.
        /// </summary>
        [Fact]
        public void CanSetAndGetdateCreated()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.dateCreated = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.dateCreated);
        }
    }
}