// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-01-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-01-2022
// ***********************************************************************
// <copyright file="DocumentBase.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Entities.Cases;
using LegalManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using LegalManager.Models.Core;

namespace LegalManager.Models.Entities.Documents
{
    /// <summary>
    /// Class that encapsulates a given document.
    /// It acts as a base class for different types of documents. The basic configuration is that a document is digitalised and stored into the filesystem. If the document needs to be stored into the database then a more specialised class is used.
    /// @author Jeferson Giovani D. Schneider
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public class DocumentBase : Document, TimetabledInterface {


        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentBase"/> class.
        /// </summary>
        public DocumentBase() {
        }

        //Attributes
        /// <summary>
        /// The Unique ID for the document of type int.
        /// </summary>
        /// <value>The document identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentID { get; set; }


        /// <summary>
        /// The CaseID of which this documents belongs to.
        /// </summary>
        /// <value>The case fk.</value>
        [ForeignKey("Case")]
        public int CaseFK { get; set; }

        /// <summary>
        /// Gets or sets the case.
        /// </summary>
        /// <value>The case.</value>
        public Case Case { get; set; }

        /// <summary>
        /// Name that identifies the document.
        /// </summary>
        /// <value>The name of the document.</value>
        [DisplayName("Document Name")]
        public string DocName { get; set; }

        /// <summary>
        /// Short description of the document.
        /// </summary>
        /// <value>The document description.</value>
        [DisplayName("Short Description")]
        public string DocDescription { get; set; }

        /// <summary>
        /// The text content for this document in case of a created digital document.
        /// </summary>
        /// <value>The content of the document.</value>
        [Display(Name ="Text")]
        [Column(TypeName ="longtext")]
        public string DocumentContent { get; set; }

        /// <summary>
        /// The filename of the document. The default use is a stored document into the file system.
        /// </summary>
        /// <value>The name of the document file.</value>
        [DisplayName("Document Filename")]
        public string DocFileName { get; set; }

        /// <summary>
        /// The path for the document.
        /// This field is used for generate documents or scanned documents.
        /// </summary>
        /// <value>The document path.</value>
        [DisplayName("Document's path")]
        public string DocPath { get; set; }

        /// <summary>
        /// List of labels for the present document.
        /// </summary>
        /// <value>The document labels.</value>
        [DisplayName("Lables")]
        [NotMapped]
        public List<string> DocLabels { get; set; } = new List<string>();

        /// <summary>
        /// Date on which the document was created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Time that the document was open. It is the starting
        /// point to measure how much time was spent with the document,
        /// convert it to time units and store the amount for the document.
        /// </summary>
        /// <value>The open time.</value>
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// Used to register the final time for unit time calculations.
        /// </summary>
        /// <value>The close time.</value>
        public DateTime CloseTime { get; set; }

        /// <summary>
        /// The total time spent with the document.
        /// </summary>
        /// <value>The total time.</value>
        public TimeSpan TotalTime { get; set; }

        /// <summary>
        /// The total time spent with the document converted to time units.
        /// </summary>
        /// <value>The total units.</value>
        public int TotalUnits { get; set; }

        /// <summary>
        /// If this document is a physical document then it can
        /// record the storage location for this document.
        /// </summary>
        /// <value>The document location.</value>
        public string DocLocation { get; set; }

        /// <summary>
        /// Common types of documents.
        /// </summary>
        /// <value>The type of the document.</value>
        public string DocType { get; set; }

        /// <summary>
        /// Field to store the file in case of an upload
        /// </summary>
        /// <value>The content of the file.</value>
        [Display(Name ="Digital File")]
        [Column(TypeName = "mediumblob")]
        public byte[] FileContent { get; set; }


        /// <summary>
        /// Boolean value for documents that are not finished yet.
        /// </summary>
        /// <value><c>true</c> if this instance is draft; otherwise, <c>false</c>.</value>
        public bool isDraft { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>The date updated.</value>
        /// <publicsummary>
        /// Last time the document was updated.
        /// </publicsummary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool isDeleted { get; set; } = false;


        //TimetabledInterface Methods
        /// <inheritdoc />
        public void setStartTime()
        {
            //Starting to count the time which this document is open (someone is working on it)
            this.OpenTime = DateTime.Now;
        }

        /// <inheritdoc />
        public void setEndTime()
        {
            //Closing the document must register the time
            this.CloseTime = DateTime.Now;

            this.DateUpdated = DateTime.Now;

            //Calculates the total time spent
            double totaltime = TimeAndUnitsCalculator.calculateTimeInMinutesFromDate(this.CloseTime, this.OpenTime);

            //Add the time spent into the TotalTime attribute (TimeSpan type)
            this.TotalTime.Add(TimeAndUnitsCalculator.calculateTimeTimeSpanFromDate(this.CloseTime, this.OpenTime));

            //Add the calculated total units of time to the field.
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
            this.TotalUnits += u;
        }

        /// <inheritdoc />
        public void discountTimeUnits(int u)
        {

            this.TotalUnits -= u;
        }

        /// <inheritdoc />
        public void CreateDocument(Case c, string lable, string doctype, string docname, string docDesc, Location location)
        {
            this.DateCreated = DateTime.Now.Date;
            this.OpenTime = DateTime.Now;
            this.CaseFK = c.CaseID;

            ///Getting the string and separating it to insert into the list (e.g. "Statement, Personal Document" => ["Statement", "Personal Document"]
            string[] ls = lable.Split(',');
            foreach(string s in ls)
            {
                this.DocLabels.Add(lable);
            }
            
            this.DocName = docname;
            this.DocDescription = docDesc;
            this.DocLocation = location.ToString();
            this.DocType = doctype;
        }

        /// <inheritdoc />
        public void renameDocument(string name)
        {
            this.DocName = name;
        }

        /// <inheritdoc />
        public string getDocPath()
        {
            return this.DocPath;
        }


    }
}