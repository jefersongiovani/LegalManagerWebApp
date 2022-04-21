// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="Case.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using AssertLibrary;
using Microsoft.AspNetCore.Identity;
using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Entities.Documents;
using LegalManager.Models.Entities.Services;
using LegalManager.Models.Entities.Users;
using LegalManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LegalManager.Models.Core;

namespace LegalManager.Models.Entities.Cases
{
    /// <summary>
    /// Concrete class that act as an repository of legal cases (apart from the Mediator cases).
    /// Jeferson Giovani D. Schneider
    /// </summary>
    [ProtectedPersonalData]
    public class Case : TimetabledInterface, LegalCaseInterface
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Case"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="u">The u.</param>
        /// <param name="type">The type.</param>
        /// <param name="caseTitle">The case title.</param>
        /// <param name="description">The description.</param>
        /// <param name="caseT">The case t.</param>
        /// Constructor
        public Case(Client c, ApplicationUser u, string type, string caseTitle, string description, string caseT)
        {
            Assert.IsNotNull(c);
            Assert.IsNotNull(u);
            Assert.IsNotNull(type);
            Assert.IsNotNull(caseTitle);
            Assert.IsNotNull(description);

            this.Client = c;
            this.Owner = u;
            this.OpenTime = DateTime.Now;
            this.dateCreated = DateTime.Now;
            this.CaseTitle = caseTitle;
            this.ShortDescription = description;
            this.Status = CaseStatus.GetName(CaseStatus.CASE_CREATED);
            this.clientID = c.ClientID;

    
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Case"/> class.
        /// </summary>
        /// Empty constructor for EF Core
        public Case() { }

        /// <summary>
        /// Gets or sets the case identifier.
        /// </summary>
        /// <value>The case identifier.</value>
        /// Attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseID { get; set; }

        /// <summary>
        /// Gets or sets the case identifier stamp.
        /// </summary>
        /// <value>The case identifier stamp.</value>
        public string CaseIdStamp { get; set; } = "-" + DateTime.Now.ToString("yyyyMMddHHmm");

        /// <summary>
        /// Gets or sets the case title.
        /// </summary>
        /// <value>The case title.</value>
        public string CaseTitle { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime dateCreated { get; set; }

        /// <summary>
        /// Gets or sets the open time.
        /// </summary>
        /// <value>The open time.</value>
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the close time.
        /// </summary>
        /// <value>The close time.</value>
        public DateTime CloseTime { get; set; }

        /// <summary>
        /// Gets or sets the total time.
        /// </summary>
        /// <value>The total time.</value>
        public TimeSpan TotalTime { get; set; }

        /// <summary>
        /// Gets or sets the total units.
        /// </summary>
        /// <value>The total units.</value>
        public int TotalUnits { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [NotMapped]
        public ApplicationUser Owner { get; set; }

        /// <summary>
        /// Gets or sets the case users.
        /// </summary>
        /// <value>The case users.</value>
        [NotMapped]
        public List<ApplicationUser> CaseUsers { get; set; } = new List<ApplicationUser>();

        /// <summary>
        /// Gets or sets the owner idfk.
        /// </summary>
        /// <value>The owner idfk.</value>
        [ForeignKey("ApplicationUser")]
        public string OwnerIDFK { get; set; }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        [ForeignKey("Client")]
        public int clientID { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the type of the case.
        /// </summary>
        /// <value>The type of the case.</value>
        public string CaseType { get; set; }


        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>The documents.</value>
        [ForeignKey("CaseFK")]
        public virtual ICollection<DocumentBase> Documents { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>The services.</value>
        [ForeignKey("CaseFK")]
        public virtual ICollection<ChosenService> Services { get; set; }



        /// <summary>
        /// Adjusts the caseIdStamp to the final form
        /// </summary>
        /// <param name="enum">Enum - the case type to be transformed to a string</param>
        /// Methods
        public void setCaseType(Enum @enum)
        {
            this.CaseType = @enum.ToString();
            string cs = this.CaseIdStamp;
            this.CaseIdStamp = CaseType + cs;
        }


        /// <summary>
        /// Gets the case identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getCaseID()
        {
            return this.CaseID;
        }
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <returns>Client.</returns>
        public virtual Client getClient()
        {
            return this.Client;
        }
        /// <summary>
        /// Gets the client identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public virtual int getClientId()
        {
            return this.Client.getClientID();
        }
        /// <summary>
        /// Gets the date created.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime getDateCreated()
        {
            return this.dateCreated;
        }
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getTitle()
        {
            return this.CaseTitle;
        }
        /// <summary>
        /// Gets the short description.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getShortDescription()
        {
            return this.ShortDescription;
        }

        /// <summary>
        /// Adds the users.
        /// </summary>
        /// <param name="u">The u.</param>
        public virtual void addUsers(ApplicationUser u)
        {
            Assert.IsNotNull(u);
            Assert.IsOfType<ApplicationUser>(u);
            CaseUsers.Add(u);
        }
        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <returns>ApplicationUser.</returns>
        public ApplicationUser getOwner()
        {
            return this.Owner;
        }
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List&lt;ApplicationUser&gt;.</returns>
        public virtual List<ApplicationUser> getUsers()
        {
            return this.CaseUsers;
        }
        /// <summary>
        /// Closes the case.
        /// </summary>
        public virtual void closeCase()
        {
            this.Status = CaseStatus.GetName(CaseStatus.CASE_CLOSED);
        }

        /// <summary>
        /// Changes the case status.
        /// </summary>
        /// <param name="s">The s.</param>
        public void changeCaseStatus(Enum s)
        {
            this.Status = s.ToString();
        }


        /// <inheritdoc />
        public void setStartTime()
        {
            ///Starting to count the time which this document is open (someone is working on it)
            this.OpenTime = DateTime.Now;
        }
        /// <inheritdoc />
        public void setEndTime()
        {
            ///Closing the document must register the time
            this.CloseTime = DateTime.Now;

            ///Calculates the total time spent
           double totaltime = TimeAndUnitsCalculator.calculateTimeInMinutesFromDate(this.CloseTime, this.OpenTime);

            ///Add the time spent into the TotalTime attribute (TimeSpan type)
            this.TotalTime.Add(TimeAndUnitsCalculator.calculateTimeTimeSpanFromDate(this.CloseTime, this.OpenTime));

            ///Add the calculated total units of time to the field.
            this.TotalUnits += TimeAndUnitsCalculator.timeUnitsCalculator(totaltime);
        }

        /// <inheritdoc />
        public TimeSpan getTotalTime()
        {
            return this.TotalTime;
        }
        /// <inheritdoc />
        public int getTotalUnits()
        {
            return this.TotalUnits;
        }

        /// <inheritdoc />
        public void addTimeUnits(int u)
        {
            this.TotalUnits +=  u;
        }

        /// <inheritdoc />
        public void discountTimeUnits(int u) {

            this.TotalUnits -=  u;
        }

        /// <summary>
        /// Gets the case stamp.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getCaseStamp()
        {
            return clientID + CaseType + CaseIdStamp;
        }


        /// <inheritdoc />
        public void caseNotification()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public void generateBundle(Case c)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public void changeStatus(Enum e)
        {
            throw new NotImplementedException();
        }


    }
}