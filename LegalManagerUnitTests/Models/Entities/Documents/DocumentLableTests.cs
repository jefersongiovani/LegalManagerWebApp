// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="DocumentLableTests.cs" company="LegalManagerUnitTests">
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
    /// Class DocumentLableTests.
    /// </summary>
    public class DocumentLableTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private DocumentLable _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentLableTests"/> class.
        /// </summary>
        public DocumentLableTests()
        {
            _testClass = new DocumentLable();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DocumentLable();
            
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
            var testValue = 1938579905;
            
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
            var testValue = "TestValue333492981";
            
            // Act
            _testClass.Name = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }
    }
}