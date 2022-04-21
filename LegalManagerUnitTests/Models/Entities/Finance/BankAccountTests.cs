// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="BankAccountTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Finance
{
    using LegalManager.Models.Entities.Finance;
    using System;
    using Xunit;

    /// <summary>
    /// Class BankAccountTests.
    /// </summary>
    public class BankAccountTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private BankAccount _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountTests"/> class.
        /// </summary>
        public BankAccountTests()
        {
            _testClass = new BankAccount();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new BankAccount();
            
            // Assert
            Assert.NotNull(instance);
        }

        /// <summary>
        /// Defines the test method CanCallgetAccountDetails.
        /// </summary>
        [Fact]
        public void CanCallgetAccountDetails()
        {
            // Act
            var result = _testClass.getAccountBasics();

            // Assert
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Defines the test method CanCallgetAccountBasics.
        /// </summary>
        [Fact]
        public void CanCallgetAccountBasics()
        {
            // Act
            var result = _testClass.getAccountBasics();
            
            // Assert
            Assert.NotEmpty(result);
        }


        /// <summary>
        /// Defines the test method CanSetAndGetBankId.
        /// </summary>
        [Fact]
        public void CanSetAndGetBankId()
        {
            // Arrange
            var testValue = 310700466;
            
            // Act
            _testClass.BankId = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.BankId);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetCompanyID.
        /// </summary>
        [Fact]
        public void CanSetAndGetCompanyID()
        {
            // Arrange
            var testValue = "TestValue618252125";
            
            // Act
            _testClass.CompanyID = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.CompanyID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAccountName.
        /// </summary>
        [Fact]
        public void CanSetAndGetAccountName()
        {
            // Arrange
            var testValue = "TestValue149184031";
            
            // Act
            _testClass.AccountName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.AccountName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAccountPayName.
        /// </summary>
        [Fact]
        public void CanSetAndGetAccountPayName()
        {
            // Arrange
            var testValue = "TestValue1238142643";
            
            // Act
            _testClass.AccountPayName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.AccountPayName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAccountSortCode.
        /// </summary>
        [Fact]
        public void CanSetAndGetAccountSortCode()
        {
            // Arrange
            var testValue = "TestValue1512079326";
            
            // Act
            _testClass.AccountSortCode = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.AccountSortCode);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAccountNumber.
        /// </summary>
        [Fact]
        public void CanSetAndGetAccountNumber()
        {
            // Arrange
            var testValue = 1646171044;
            
            // Act
            _testClass.AccountNumber = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.AccountNumber);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAccountIBAN.
        /// </summary>
        [Fact]
        public void CanSetAndGetAccountIBAN()
        {
            // Arrange
            var testValue = "TestValue365420748";
            
            // Act
            _testClass.AccountIBAN = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.AccountIBAN);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAccountBIC.
        /// </summary>
        [Fact]
        public void CanSetAndGetAccountBIC()
        {
            // Arrange
            var testValue = "TestValue1040884457";
            
            // Act
            _testClass.AccountBIC = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.AccountBIC);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetAccountType.
        /// </summary>
        [Fact]
        public void CanSetAndGetAccountType()
        {
            // Arrange
            var testValue = "TestValue1195049288";
            
            // Act
            _testClass.AccountType = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.AccountType);
        }
    }
}