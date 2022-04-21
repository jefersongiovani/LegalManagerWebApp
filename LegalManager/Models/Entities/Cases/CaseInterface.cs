// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="CaseInterface.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Entities.Documents;
using LegalManager.Models.Entities.Services;
using LegalManager.Models.Entities.Users;
using System;
using System.Collections.Generic;

namespace LegalManager.Models.Entities.Cases
{
    /// <summary>
    /// Abstract Interface that provides the default methods for all case implementations.
    /// @author Jeferson G. D. Schneider
    /// </summary>
    public interface CaseInterface {

        /// <summary>
        /// Add a new document to the case
        /// </summary>
        /// <param name="d">Document d. The document object.</param>
        /// <returns>True if the document was added, and false otherwise.</returns>
        public void addDocument(Document d);

        /// <summary>
        /// Adds the service.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <font color="red">Badly formed XML comment.</font>
        public void addService(Service s);


        /// <summary>
        /// @return int with the case id.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getCaseID();

        /// <summary>
        /// Returns the unique case stamp.
        /// </summary>
        /// <returns>String</returns>
        public string getCaseStamp();

        /// <summary>
        /// Returns the client object of the case.
        /// </summary>
        /// <returns>Client - the client that owns the case.</returns>
        public Client getClient();

        /// <summary>
        /// The date the case was created.
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime getDateCreated();

        /// <summary>
        /// Returns the title of the case.
        /// </summary>
        /// <returns>String</returns>
        public String getTitle();

        /// <summary>
        /// Returns the short description of the case
        /// </summary>
        /// <returns>String</returns>
        public String getShortDescription();


        /// <summary>
        /// Returns the list of document objects for this case
        /// </summary>
        /// <returns>Document document list</returns>
        public List<Document> getDocumentList();

        /// <summary>
        /// Add an system user to the case.
        /// </summary>
        /// <param name="u">The u.</param>
        public void addUsers(ApplicationUser u);

        /// <summary>
        /// The owner of the case.
        /// </summary>
        /// <returns>User owner</returns>
        public ApplicationUser getOwner();

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List&lt;ApplicationUser&gt;.</returns>
        /// <font color="red">Badly formed XML comment.</font>
        public List<ApplicationUser> getUsers();


        /// <summary>
        /// Change the status of a case to closed.
        /// </summary>
        public void closeCase();


        /// <summary>
        /// Changes the case status.
        /// </summary>
        /// <param name="s">The s.</param>
        public void changeCaseStatus(Enum s);


    }
}