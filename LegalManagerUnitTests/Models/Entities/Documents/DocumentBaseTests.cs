// ***********************************************************************
// Assembly         : LegalManagerUnitTests
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="DocumentBaseTests.cs" company="LegalManagerUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LegalManagerUnitTests.Models.Entities.Documents
{
    using LegalManager.Models.Entities.Documents;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Cases;
    using System.Collections.Generic;

    /// <summary>
    /// Class DocumentBaseTests.
    /// </summary>
    public class DocumentBaseTests
    {
        /// <summary>
        /// The test class
        /// </summary>
        private DocumentBase _testClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentBaseTests"/> class.
        /// </summary>
        public DocumentBaseTests()
        {
            _testClass = new DocumentBase();
        }

        /// <summary>
        /// Defines the test method CanConstruct.
        /// </summary>
        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DocumentBase();
            
            // Assert
            Assert.NotNull(instance);
        }


        /// <summary>
        /// Defines the test method CanCallgetTotalTime.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetTotalTime()
        {
            // Act

            var result = _testClass.getTotalTime();
            
            // Assert
            Assert.True(_testClass.TotalTime == result);
        }

        /// <summary>
        /// Defines the test method CanCallgetTotalUnits.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetTotalUnits()
        {
            // Act
            var result = _testClass.getTotalUnits();

            // Assert
            Assert.True(_testClass.TotalUnits == result);
        }

        /// <summary>
        /// Defines the test method CanCalladdTimeUnits.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCalladdTimeUnits()
        {
            // Arrange
            var u = 923853085;
            var m = _testClass.TotalUnits;
            // Act
            _testClass.addTimeUnits(u);
            
            // Assert
            Assert.True(_testClass.TotalUnits == m + u);
        }

        /// <summary>
        /// Defines the test method CanCalldiscountTimeUnits.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCalldiscountTimeUnits()
        {
            // Arrange
            var u = 457131765;
            var m = _testClass.TotalUnits;
            // Act
            _testClass.discountTimeUnits(u);

            // Assert
            Assert.True(_testClass.TotalUnits == m - u);
        }

        /// <summary>
        /// Defines the test method CanCallCreateDocument.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallCreateDocument()
        {
            // Arrange
            var c = new Case();
            var lable = "TestValue726083673";
            var doctype = "TestValue216632094";
            var docname = "TestValue1943307147";
            var docDesc = "TestValue1500210188";
            var location = new Location();
            
            // Act
            _testClass.CreateDocument(c, lable, doctype, docname, docDesc, location);
            
            // Assert
            Assert.IsType<DocumentBase>(_testClass);
        }


        /// <summary>
        /// Defines the test method CanCallrenameDocument.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallrenameDocument()
        {
            // Arrange
            var name = "TestValue292253831";
            
            // Act
            _testClass.renameDocument(name);
            
            // Assert
            Assert.Equal(name, _testClass.DocName);
        }



        /// <summary>
        /// Defines the test method CanCallgetDocPath.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Create or modify test</exception>
        [Fact]
        public void CanCallgetDocPath()
        {
            // Act
            _testClass.DocPath = "c/docs/";
            var result = _testClass.getDocPath();
            
            
            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocumentID.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocumentID()
        {
            // Arrange
            var testValue = 502078117;
            
            // Act
            _testClass.DocumentID = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocumentID);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetCaseFK.
        /// </summary>
        [Fact]
        public void CanSetAndGetCaseFK()
        {
            // Arrange
            var testValue = 794096425;
            
            // Act
            _testClass.CaseFK = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.CaseFK);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetCase.
        /// </summary>
        [Fact]
        public void CanSetAndGetCase()
        {
            // Arrange
            var testValue = new Case();
            
            // Act
            _testClass.Case = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.Case);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocName.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocName()
        {
            // Arrange
            var testValue = "TestValue1207720923";
            
            // Act
            _testClass.DocName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocDescription.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocDescription()
        {
            // Arrange
            var testValue = "TestValue1852473107";
            
            // Act
            _testClass.DocDescription = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocDescription);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocumentContent.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocumentContent()
        {
            // Arrange
            var testValue = "TestValue1315626418";
            
            // Act
            _testClass.DocumentContent = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocumentContent);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocFileName.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocFileName()
        {
            // Arrange
            var testValue = "TestValue207812739";
            
            // Act
            _testClass.DocFileName = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocFileName);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocPath.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocPath()
        {
            // Arrange
            var testValue = "TestValue1751854674";
            
            // Act
            _testClass.DocPath = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocPath);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocLabels.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocLabels()
        {
            // Arrange
            var testValue = new List<string>();
            
            // Act
            _testClass.DocLabels = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.DocLabels);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDateCreated.
        /// </summary>
        [Fact]
        public void CanSetAndGetDateCreated()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.DateCreated = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DateCreated);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetOpenTime.
        /// </summary>
        [Fact]
        public void CanSetAndGetOpenTime()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.OpenTime = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.OpenTime);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetCloseTime.
        /// </summary>
        [Fact]
        public void CanSetAndGetCloseTime()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.CloseTime = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.CloseTime);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTotalTime.
        /// </summary>
        [Fact]
        public void CanSetAndGetTotalTime()
        {
            // Arrange
            var testValue = new TimeSpan();
            
            // Act
            _testClass.TotalTime = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.TotalTime);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetTotalUnits.
        /// </summary>
        [Fact]
        public void CanSetAndGetTotalUnits()
        {
            // Arrange
            var testValue = 24065498;
            
            // Act
            _testClass.TotalUnits = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.TotalUnits);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocLocation.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocLocation()
        {
            // Arrange
            var testValue = "TestValue1860823238";
            
            // Act
            _testClass.DocLocation = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocLocation);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDocType.
        /// </summary>
        [Fact]
        public void CanSetAndGetDocType()
        {
            // Arrange
            var testValue = "TestValue249725860";
            
            // Act
            _testClass.DocType = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DocType);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetFileContent.
        /// </summary>
        [Fact]
        public void CanSetAndGetFileContent()
        {
            // Arrange
            var testValue = new byte[] { 108, 76, 18, 86 };
            
            // Act
            _testClass.FileContent = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.FileContent);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetisDraft.
        /// </summary>
        [Fact]
        public void CanSetAndGetisDraft()
        {
            // Arrange
            var testValue = false;
            
            // Act
            _testClass.isDraft = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.isDraft);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetDateUpdated.
        /// </summary>
        [Fact]
        public void CanSetAndGetDateUpdated()
        {
            // Arrange
            var testValue = DateTime.UtcNow;
            
            // Act
            _testClass.DateUpdated = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.DateUpdated);
        }

        /// <summary>
        /// Defines the test method CanSetAndGetisDeleted.
        /// </summary>
        [Fact]
        public void CanSetAndGetisDeleted()
        {
            // Arrange
            var testValue = true;
            
            // Act
            _testClass.isDeleted = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.isDeleted);
        }
    }
}