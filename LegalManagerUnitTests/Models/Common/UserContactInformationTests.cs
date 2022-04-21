// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="UserContactInformationTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Common
{
    using LegalManager.Models.Common;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Users;

    /// <summary>
    /// Class UserContactInformationTests.
    /// </summary>
    public class UserContactInformationTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private UserContactInformation _testClass;
        /// <summary>
        /// The usr
        /// </summary>
        private ApplicationUser _usr;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The information
        /// </summary>
        private string _information;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserContactInformationTests"/> class.
        /// </summary>
        public UserContactInformationTests()
        {
            _usr = new ApplicationUser();
            _name = "TestValue1271371133";
            _information = "TestValue541145946";
            _testClass = new UserContactInformation(_usr, _name, _information);
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UserContactInformation(_usr, _name, _information);
            
            // Assert
            Assert.NotNull(instance);
            
            // Act
            instance = new UserContactInformation();
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CannotConstructWithNullUsr.
        /// </summary>
        [Fact]
        public void CannotConstructWithNullUsr()
        {
            Assert.Throws<ArgumentNullException>(() => new UserContactInformation(default(ApplicationUser), "TestValue548586389", "TestValue1145477081"));
        }

        /// <summary>
        /// Defines the test method CannotConstructWithInvalidName.
        /// </summary>
        /// <param name="value">The value.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new UserContactInformation(new ApplicationUser(), value, "TestValue1587968833"));
        }



        [Fact]
        public void CanCallsetDeprecated()
        {
            // Act
            _testClass.setDeprecated();
            
            // Assert
            Assert.True(_testClass.isDeprecated);
        }

        /// <summary>
        /// Defines the test method CanCallToString.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallToString()
        {
            // Act
            var result = _testClass.ToString();
            
            // Assert
            Assert.Equal(_testClass.ToString(), result);
        }

        /// <summary>
        /// Defines the test method CanGetId.
        /// </summary>
        [Fact]
        public void CanGetId()
        {
            // Arrange
            var testValue = _testClass.Id;

            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
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


        /// <summary>
        /// Defines the test method CanSetAndGetName.
        /// </summary>
        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue460395002";
            
            // Act
            _testClass.Name = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }


        /// <summary>
        /// Defines the test method CanSetAndGetInformation.
        /// </summary>
        [Fact]
        public void CanSetAndGetInformation()
        {
            // Arrange
            var testValue = "TestValue1405975734";
            
            // Act
            _testClass.Information = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Information);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetisDeprecated.
        /// </summary>
        [Fact]
        public void CanSetAndGetisDeprecated()
        {
            // Arrange
            var testValue = true;
            
            // Act
            _testClass.isDeprecated = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.isDeprecated);
        }
    }
}