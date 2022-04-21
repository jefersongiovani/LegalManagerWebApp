// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="DigitalSignatureTests.cs" company="LegalManagerUnitTests">
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
    /// Class DigitalSignatureTests.
    /// </summary>
    public class DigitalSignatureTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private DigitalSignature _testClass;
        /// <summary>
        /// The identifier
        /// </summary>
        private string _id;
        /// <summary>
        /// The s
        /// </summary>
        private string _s;

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalSignatureTests"/> class.
        /// </summary>
        public DigitalSignatureTests()
        {
            _id = "TestValue437659122";
            _s = "TestValue1571029740";
            _testClass = new DigitalSignature(_id, _s);
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DigitalSignature();
            
            // Assert
            Assert.NotNull(instance);
            
            // Act
            instance = new DigitalSignature(_id, _s);
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CannotConstructWithInvalidId.
        /// </summary>
        /// <param name="value">The value.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new DigitalSignature(value, "TestValue527240983"));
        }

        /// <summary>
        /// Defines the test method CannotConstructWithInvalidS.
        /// </summary>
        /// <param name="value">The value.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidS(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new DigitalSignature("TestValue1350631460", value));
        }
    }
}