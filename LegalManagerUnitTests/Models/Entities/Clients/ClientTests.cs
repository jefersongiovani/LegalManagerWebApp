// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ClientTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Clients
{
    using LegalManager.Models.Entities.Clients;
    using System;
    using Xunit;
    using NSubstitute;
    using LegalManager.Models.Common;
    using System.Collections.Generic;

    /// <summary>
    /// Class ClientTests.
    /// </summary>
    public class ClientTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private Client _testClass;
        /// <summary>
        /// The client
        /// </summary>
        private Client client = new Client();
        /// <summary>
        /// The address
        /// </summary>
        private ClientAddress _address;



        /// <summary>
        /// Initializes a new instance of the <see cref="ClientTests"/> class.
        /// </summary>
        public ClientTests()
        {
            
            _testClass = client.addNewClient("John", "Doe", "email@dot.com", DateTime.Today, "0795775000000");
            _testClass.ClientID = 10;
            _address = new ClientAddress(10, "Home", "SE1 5TB", "100", "Flat A", "Bermondsay", "Southwark", "London", "UK");
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Client();
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanCallgetClientID.
        /// </summary>
        [Fact]
        public void CanCallgetClientID()
        {
            // Act
            var result = _testClass.getClientID();
            
            // Assert
            Assert.Equal(_testClass.getClientID(), result);
        }

        /// <summary>
        /// Defines the test method CanCallgetClientName.
        /// </summary>
        [Fact]
        public void CanCallgetClientName()
        {
            // Act
            var result = _testClass.getClientName();

            // Assert
            Assert.Equal(_testClass.FullName, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetClientEmail.
        /// </summary>
        [Fact]
        public void CanCallgetClientEmail()
        {
            // Act
            var result = _testClass.getClientEmail();

            // Assert
            Assert.Equal(_testClass.EmailAddress, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetClientDoB.
        /// </summary>
        [Fact]
        public void CanCallgetClientDoB()
        {
            // Act
            var result = _testClass.getClientDoB();

            // Assert
            Assert.Equal(_testClass.DateOfBirth, result);
        }

        /// <summary>
        /// Defines the test method CanCallgetClientRegDate.
        /// </summary>
        [Fact]
        public void CanCallgetClientRegDate()
        {
            // Act
            var result = _testClass.getClientRegDate();

            // Assert
            Assert.Equal(_testClass.getClientRegDate(), result);
        }

        /// <summary>
        /// Defines the test method CanCallgetClientMobNumber.
        /// </summary>
        [Fact]
        public void CanCallgetClientMobNumber()
        {
            // Act
            var result = _testClass.getClientMobNumber();

            // Assert
            Assert.Equal(_testClass.MobileNumber, result);
        }

        /// <summary>
        /// Defines the test method CanCalltoString.
        /// </summary>
        [Fact]
        public void CanCalltoString()
        {
            // Act
            var __client = client.addNewClient("John", "Doe", "email@dot.com", DateTime.Today, "0795775000000");
            __client.ClientID = 10;
            var __address = new ClientAddress(10, "Home", "SE1 5TB", "100", "Flat A", "Bermondsay", "Southwark", "London", "UK");
            var result = __client.ToString();

            // Assert
            Assert.Equal(_testClass.ToString(), result);
        }

        /// <summary>
        /// Defines the test method CanCalladdNewClient.
        /// </summary>
        [Fact]
        public void CanCalladdNewClient()
        {
            // Arrange
            var firstName = "TestValue142951833";
            var lastName = "TestValue2066941832";
            var email = "TestValue226480843";
            var doB = DateTime.UtcNow;
            var mobileNumber = "TestValue1280910877";
            
            // Act
            var result = _testClass.addNewClient(firstName, lastName, email, doB, mobileNumber);
            
            // Assert
            Assert.IsType<Client>(result);
        }


        /// <summary>
        /// Defines the test method addNewClientPerformsMapping.
        /// </summary>
        [Fact]
        public void addNewClientPerformsMapping()
        {
            // Arrange
            var firstName = "TestValue326042940";
            var lastName = "TestValue394121106";
            var email = "TestValue2036747574";
            var doB = DateTime.UtcNow;
            var mobileNumber = "TestValue1067257952";
            
            // Act
            var result = _testClass.addNewClient(firstName, lastName, email, doB, mobileNumber);
            
            // Assert
            Assert.Same(firstName, result.FirstName);
            Assert.Same(lastName, result.LastName);
            Assert.Same(mobileNumber, result.MobileNumber);
        }

        /// <summary>
        /// Defines the test method CanCallgetClientAddress.
        /// </summary>
        [Fact]
        public void CanCallgetClientAddress()
        {
            var __client = client.addNewClient("John", "Doe", "email@dot.com", DateTime.Today, "0795775000000");
            __client.ClientID = 10;
            var __address = new ClientAddress(10, "Home", "SE1 5TB", "100", "Flat A", "Bermondsay", "Southwark", "London", "UK");
            __client.clientAddress = __address;
            // Act
            var result = __client.getClientAddress();

            // Assert
            Assert.True(result == __client.getClientAddress());
        }

        /// <summary>
        /// Defines the test method CanSetAndGetClientID.
        /// </summary>
        [Fact]
        public void CanSetAndGetClientID()
        {
            // Arrange
            var testValue = 1744222301;
            
            // Act
            _testClass.ClientID = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.ClientID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetFirstName.
        /// </summary>
        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue347128333";
            
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
            var testValue = "TestValue566731644";
            
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
            var result = _testClass.FirstName + " " + _testClass.LastName;
            // Assert
            Assert.True(_testClass.FullName == result);

        }

        /// <summary>
        /// Defines the test method CanSetAndGetEmailAddress.
        /// </summary>
        [Fact]
        public void CanSetAndGetEmailAddress()
        {
            // Arrange
            var testValue = "TestValue104059498";
            
            // Act
            _testClass.EmailAddress = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.EmailAddress);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetMobileNumber.
        /// </summary>
        [Fact]
        public void CanSetAndGetMobileNumber()
        {
            // Arrange
            var testValue = "TestValue176113986";
            
            // Act
            _testClass.MobileNumber = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.MobileNumber);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetRegisteredDate.
        /// </summary>
        [Fact]
        public void CanSetAndGetRegisteredDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.RegisteredDate = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.RegisteredDate);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDateOfBirth.
        /// </summary>
        [Fact]
        public void CanSetAndGetDateOfBirth()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.DateOfBirth = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DateOfBirth);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetIdentificationName.
        /// </summary>
        [Fact]
        public void CanSetAndGetIdentificationName()
        {
            // Arrange
            var testValue = "TestValue1764362343";
            
            // Act
            _testClass.IdentificationName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.IdentificationName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetIdentification.
        /// </summary>
        [Fact]
        public void CanSetAndGetIdentification()
        {
            // Arrange
            var testValue = "TestValue1166750067";
            
            // Act
            _testClass.Identification = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Identification);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetNationality.
        /// </summary>
        [Fact]
        public void CanSetAndGetNationality()
        {
            // Arrange
            var testValue = "TestValue1520703729";
            
            // Act
            _testClass.Nationality = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.Nationality);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetclientAddress.
        /// </summary>
        [Fact]
        public void CanSetAndGetclientAddress()
        {
            // Arrange
            var testValue = new ClientAddress();
            
            // Act
            _testClass.clientAddress = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.clientAddress);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetClientAddresses.
        /// </summary>
        [Fact]
        public void CanSetAndGetClientAddresses()
        {
            // Arrange
            var testValue = Substitute.For<ICollection<ClientAddress>>();
            
            // Act
            _testClass.ClientAddresses = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.ClientAddresses);
        }
    }
}