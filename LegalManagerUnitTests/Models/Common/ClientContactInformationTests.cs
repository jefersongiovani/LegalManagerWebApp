// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ClientContactInformationTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Common
{
    using LegalManager.Models.Common;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Clients;

    /// <summary>
    /// Class ClientContactInformationTests.
    /// </summary>
    public class ClientContactInformationTests
    {
        /// <summary>
        /// The client
        /// </summary>
        private Client _client;
        /// <summary>
        /// The test class
        /// </summary>
        private ClientContactInformation _testClass;
        /// <summary>
        /// The usr
        /// </summary>
        private Client _usr;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The information
        /// </summary>
        private string _information;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientContactInformationTests"/> class.
        /// </summary>
        public ClientContactInformationTests()
        {
            _usr = new Client();
            _name = "TestValue442748265";
            _information = "TestValue1105014271";
            _testClass = new ClientContactInformation(_usr, _name, _information);
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            Client testValue = new Client();
            var instance = new ClientContactInformation(testValue, _name, _information);

            // Assert
            Assert.NotNull(instance);
            
        }


        /// <summary>
        /// Defines the test method CanCallsetDeprecated.
        /// </summary>
        [Fact]
        public void CanCallsetDeprecated()
        {
            // Act
            Client testValue = new Client();
            var newContactInfo = new ClientContactInformation(testValue, _name, _information);
            newContactInfo.setDeprecated();

            var result = newContactInfo.isDeprecated;
            // Assert
            Assert.True(newContactInfo.isDeprecated == result);
        }

        /// <summary>
        /// Defines the test method CanCallToString.
        /// </summary>
        [Fact]
        public void CanCallToString()
        {
            // Act
            Client testValue = new Client();
            var newContactInfo = new ClientContactInformation(testValue, _name, _information);
            var result = newContactInfo.ToString();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Defines the test method CanGetClientId.
        /// </summary>
        [Fact]
        public void CanGetClientId()
        {
            var result = _testClass.client.ClientID;
            // Assert
            Assert.Equal(_usr.ClientID, result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetclientID.
        /// </summary>
        [Fact]
        public void CanSetAndGetclientID()
        {
            // Arrange
            Client testValue = new Client();

            ClientContactInformation contact = new ClientContactInformation(testValue, _name, _information);


            // Assert
            Assert.Equal(contact.client.ClientID, testValue.ClientID);
        }


    }
}