// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ApplicationUserTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace LegalManagerUnitTests.Models.Entities.Users
{
    using LegalManager.Models.Entities.Users;
    using System;
    using Xunit;
    
    using System.Collections.Generic;
    using LegalManager.Models.Common;
    using LegalManager.Models.Entities.Cases;
    using NSubstitute;

    /// <summary>
    /// Class ApplicationUserTests.
    /// </summary>
    public class ApplicationUserTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private ApplicationUser _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserTests"/> class.
        /// </summary>
        public ApplicationUserTests()
        {
            _testClass = new ApplicationUser();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ApplicationUser();
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanCalladdUserTitle.
        /// </summary>
        [Fact]
        public void CanCalladdUserTitle()
        {
            // Arrange
            var t = new UserTitle { Id = 789115162, Title = "TestValue19879531", Abbreviation = "TestValue1528017413", RegisteredNumber = "TestValue655426242", user = new ApplicationUser() };
            
            // Act
            _testClass.addUserTitle(t);
            var t2 = _testClass.userTitles;

            // Assert
            Assert.Contains(t, t2);
        }


        /// <summary>
        /// Defines the test method CanCallGetUserCompleteName.
        /// </summary>
        [Fact]
        public void CanCallGetUserCompleteName()
        {
            // Act
            var result = _testClass.GetUserCompleteName();
            
            // Assert
            Assert.Equal(_testClass.FullName, result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetId.
        /// </summary>
        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = "TestValue1791545033";
            
            // Act
            _testClass.Id = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetFirstName.
        /// </summary>
        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue518167382";
            
            // Act
            _testClass.FirstName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetLastName.
        /// </summary>
        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue277669096";
            
            // Act
            _testClass.LastName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        /// <summary>
        /// Defines the test method CanGetFullName.
        /// </summary>
        [Fact]
        public void CanGetFullName()
        {
            var result = _testClass.FullName;
            string flname = _testClass.FirstName + " " + _testClass.LastName;
            // Assert
            Assert.Equal(flname, result);
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
        /// Defines the test method CanSetAndGetUserStatus.
        /// </summary>
        [Fact]
        public void CanSetAndGetUserStatus()
        {
            // Arrange
            var testValue = false;
            
            // Act
            _testClass.UserStatus = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.UserStatus);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPersonalEmail.
        /// </summary>
        [Fact]
        public void CanSetAndGetPersonalEmail()
        {
            // Arrange
            var testValue = "TestValue565467656";
            
            // Act
            _testClass.PersonalEmail = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.PersonalEmail);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetaddresses.
        /// </summary>
        [Fact]
        public void CanSetAndGetaddresses()
        {
            // Arrange
            var testValue = new List<Address>();
            
            // Act
            _testClass.addresses = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.addresses);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDigitalSignId.
        /// </summary>
        [Fact]
        public void CanSetAndGetDigitalSignId()
        {
            // Arrange
            var testValue = 1242560258;
            
            // Act
            _testClass.DigitalSignId = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DigitalSignId);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetPhoto.
        /// </summary>
        [Fact]
        public void CanSetAndGetPhoto()
        {
            // Arrange
            var testValue = new byte[] { 193, 113, 166, 45 };
            
            // Act
            _testClass.Photo = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.Photo);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetuserTitles.
        /// </summary>
        [Fact]
        public void CanSetAndGetuserTitles()
        {
            // Arrange
            var testValue = new List<UserTitle>();
            
            // Act
            _testClass.userTitles = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.userTitles);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetContactInformation.
        /// </summary>
        [Fact]
        public void CanSetAndGetContactInformation()
        {
            // Arrange
            var testValue = Substitute.For<ICollection<UserContactInformation>>();
            
            // Act
            _testClass.ContactInformation = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.ContactInformation);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetcases.
        /// </summary>
        [Fact]
        public void CanSetAndGetcases()
        {
            // Arrange
            var testValue = Substitute.For<ICollection<Case>>();
            
            // Act
            _testClass.cases = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.cases);
        }
    }
}