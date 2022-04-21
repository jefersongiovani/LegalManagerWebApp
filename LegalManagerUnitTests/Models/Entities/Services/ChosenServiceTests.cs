// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ChosenServiceTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Services
{
    using LegalManager.Models.Entities.Services;
    using System;
    using Xunit;

    /// <summary>
    /// Class ChosenServiceTests.
    /// </summary>
    public class ChosenServiceTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private ChosenService _testClass;
        /// <summary>
        /// The cost
        /// </summary>
        private double _cost;
        /// <summary>
        /// The title
        /// </summary>
        private string _title;
        /// <summary>
        /// The description
        /// </summary>
        private string _description;
        /// <summary>
        /// The type
        /// </summary>
        private string _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChosenServiceTests"/> class.
        /// </summary>
        public ChosenServiceTests()
        {
            _cost = 951372063.18;
            _title = "TestValue2124631516";
            _description = "TestValue825626484";
            _type = "TestValue210288766";
            _testClass = new ChosenService(_cost, _title, _description, _type);
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ChosenService(_cost, _title, _description, _type);
            
            // Assert
            Assert.NotNull(instance);
            
            // Act
            instance = new ChosenService();
            
            // Assert
            Assert.NotNull(instance);
        }



        /// <summary>
        /// Defines the test method CanCallgetCost.
        /// </summary>
        [Fact]
        public void CanCallgetCost()
        {
            // Act
            var result = _testClass.getCost();
            
            // Assert
            Assert.True(result == _testClass.getCost());
        }

        /// <summary>
        /// Defines the test method CanCallgetDescription.
        /// </summary>
        [Fact]
        public void CanCallgetDescription()
        {
            // Act
            var result = _testClass.getDescription();

            // Assert
            Assert.True(result == _testClass.getDescription());
        }

        /// <summary>
        /// Defines the test method CanCallgetTitle.
        /// </summary>
        [Fact]
        public void CanCallgetTitle()
        {
            // Act
            var result = _testClass.getTitle();

            // Assert
            Assert.True(result == _testClass.getTitle());
        }

        /// <summary>
        /// Defines the test method CanCallgetServiceType.
        /// </summary>
        [Fact]
        public void CanCallgetServiceType()
        {
            // Act
            var result = _testClass.getServiceType();

            // Assert
            Assert.True(result == _testClass.getServiceType());
        }

        /// <summary>
        /// Defines the test method CanCallgetReference.
        /// </summary>
        [Fact]
        public void CanCallgetReference()
        {
            // Act
            var result = _testClass.getReference();

            // Assert
            Assert.True(result == _testClass.getReference());
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
            Assert.True(result == _testClass.ToString());
        }
    }
}