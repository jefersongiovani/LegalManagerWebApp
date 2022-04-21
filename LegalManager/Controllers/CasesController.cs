// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="CasesController.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using AssertLibrary;
using IronPdf;
using LegalManager.Data;
using LegalManager.Models.Core;
using LegalManager.Models.Entities.Cases;
using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Entities.Documents;
using LegalManager.Models.Entities.Services;
using LegalManager.Models.Entities.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace LegalManager.Api
{
    /// <summary>
    /// This class controller is responsible for all operations
    /// involving Cases, from listing cases to open and close cases.
    /// <author>Jeferson Giovani Schneider</author>
    /// </summary>
    public class CasesController : Controller
    {
        /// <summary>
        /// Private attributs for dependency injection of
        /// the database context, the logger, the user manager,
        /// and th sign-in manager.
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Case> _logger;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IWebHostEnvironment _env;

        /// <summary>
        /// Temporary attribute for user feedback message.
        /// </summary>
        /// <value>The status message.</value>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        /// The constructor that injects the dependencies.
        /// </summary>
        /// <param name="signInManager">SignInManager object of type ApplicationUser</param>
        /// <param name="logger">Ilogger object</param>
        /// <param name="userManager">UserManager object of type ApplicationUser</param>
        /// <param name="context">ApplicationDbContext</param>
        /// Getters Section
        public CasesController(SignInManager<ApplicationUser> signInManager,
            ILogger<Case> logger,
            UserManager<ApplicationUser> userManager, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _env = env;

        }

        /// <summary>
        /// Returns a list with the open cases.
        /// </summary>
        /// <returns>List object of cases</returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<Case> cases = new List<Case>();
            var result = _context.Set<Case>().Where(c => c.Status != CaseStatus.CASE_CLOSED.ToString())
                .Include("Client")
                .OrderBy(c => c.Client.FirstName)
                .AsNoTracking();

            if (result.Any())
            {
                cases.AddRange(result);
            }

            return View(cases);
        }


        public ActionResult CaseDocumentList()
        {

            List<Case> cases = new List<Case>();
            var result = _context.Set<Case>().Where(c => c.Status != CaseStatus.CASE_CLOSED.ToString())
                .Include("Client")
                .OrderBy(c => c.Client.FirstName)
                .AsNoTracking();

            if (result.Any())
            {
                cases.AddRange(result);
            }

            return View(cases);
        }

        /// <summary>
        /// Returns a list with closed cases.
        /// </summary>
        /// <returns>List object of cases</returns>
        [HttpGet]
        public ActionResult ClosedCases()
        {
            List<Case> cases = new List<Case>();
            var result = _context.Set<Case>().Where(c => c.Status == CaseStatus.CASE_CLOSED.ToString())
                .Include("Client")
                .AsNoTracking();

            if (result.Any())
            {
                cases.AddRange(result);
            }

            return View(cases);
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = _context.Cases.Find(id);
            ViewBag.Client = _context.Clients.Where(c => c.ClientID == @case.clientID).FirstOrDefault();

            if (@case == null)
            {
                return NotFound();
            }
            ViewBag.Documents = _context.DocumentBases.Where(c => c.CaseFK == id).ToList();

            return View(@case);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// GET: Cases/Create
        public IActionResult Create()
        {
            ListOfClients();
            ListOfCaseTypes();
            ViewBag.Datetime = DateTime.Now;
            ViewBag.Status = CaseStatus.CASE_CREATED.ToString();
            ViewData["clientID"] = new SelectList(_context.Clients, "ClientID", "FullName");
            return View();
        }

        /// <summary>
        /// Creates the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Cases/Create
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseID,CaseTitle,ShortDescription,dateCreated,OpenTime,OwnerIDFK,clientID,Status,CaseType")] Case c)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ListOfClients();
            ListOfCaseTypes();
            ViewBag.Datetime = DateTime.Now;
            ViewBag.Status = CaseStatus.CASE_CREATED.ToString();
            ViewData["clientID"] = new SelectList(_context.Clients, "ClientID", "FullName", c.clientID);
            return View(c);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }
            ListOfCaseTypes();
            ListOfClients();
            ListOfCaseStatuses();
            ViewData["clientID"] = new SelectList(_context.Clients, "ClientID", "FirstName, LastName", @case.clientID);
            return View(@case);
        }

        /// <summary>
        /// Creates a SelectList with the clients with full name.
        /// </summary>
        /// <param name="selectedClient">Object</param>
        private void ListOfClients(Object selectedClient = null)
        {
            var clientsQuery = from c in _context.Clients
                               orderby c.getClientName()
                               select c;
            ViewBag.ClientID = new SelectList(clientsQuery.AsNoTracking(), "ClientID", "FirstName", selectedClient);
        }

        /// <summary>
        /// Provides a <c>SelectList</c> with the names of CaseTypes
        /// </summary>
        /// <param name="selectedCaseType">String - The selected string element. Initial value is null.</param>
        private void ListOfCaseTypes(Object selectedCaseType = null)
        {
            List<String> items = new List<string>();

            var enumValues = Enum.GetNames((typeof(CaseType)));
            foreach (string value in enumValues)
            {
                items.Add(value);
            }
            ViewBag.CaseTypes = new SelectList(items, selectedCaseType);
            

        }

        /// <summary>
        /// Lists the of document types.
        /// </summary>
        /// <param name="selectedDocType"><c>SelectList</c></param>
        private void ListOfDocumentTypes(Object selectedDocType = null)
        {
            List<string> items = new List<string>();
            var enumValues = Enum.GetNames(typeof(DocumentType));
            foreach(string value in enumValues)
            {
                items.Add(value);
            }
            ViewBag.DocTypes = new SelectList(items, selectedDocType);
        }

        /// <summary>
        /// Returns a ViewBag with a list of status for the case.
        /// </summary>
        /// <param name="selectedStatus"><c>SelectList</c></param>
        private void ListOfCaseStatuses(Object selectedStatus = null)
        {
            List<string> items = new List<string>();
            var enumValues = Enum.GetNames(typeof(CaseStatus));
            foreach (string value in enumValues)
            {
                items.Add(value);
            }
            ViewBag.Status = new SelectList(items, selectedStatus);
        }


        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="case">The case.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Client/Edit/5
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseID,CaseTitle,ShortDescription,dateCreated,OpenTime,OwnerIDFK,clientID,Status")] Case @case)
        {
            if (id != @case.CaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.CaseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ListOfClients();

            ViewData["clientID"] = new SelectList(_context.Clients, "ClientID", "FullName");
            return View(@case);
        }



        /// <summary>
        /// Cases the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.CaseID == id);
        }


        /// <summary>
        /// Returns a list of cases for a given client.
        /// </summary>
        /// <param name="client">Client object</param>
        /// <returns>List object of clients</returns>
        public JsonResult GetCasesByClient(int id)
        {
            List<Case> cases = new List<Case>();

            if (id > 0)
            {
                var listResultsClient = _context.Cases.Where(c => c.clientID == id).ToList();
                cases.AddRange(listResultsClient);
            }
            return Json(cases);

        }

        /// <summary>
        /// List of clients
        /// </summary>
        /// <returns>Json list of clients</returns>
        public JsonResult GetClientList()
        {
            var clist = _context.Clients.ToList();
            return Json(clist);
        }

        /// <summary>
        /// Returns a list of cases for a given case owner
        /// </summary>
        /// <param name="id">String - the user id</param>
        /// <returns>List of Case objects</returns>
        /// <exception cref="System.ArgumentException">id</exception>
        [HttpGet]
        [ValidateAntiForgeryToken]
        public JsonResult GetCasesByOwner(string id)
        {
            List<Case> cases = new List<Case>();

            if (id != null && id.Trim().Equals(id))
            {
                var listResults = _context.Cases.Where(c => c.OwnerIDFK == id).ToList();
                cases.AddRange(listResults);
                return Json(cases);
            }
            else
            {
                throw new ArgumentException(nameof(id));
            }


        }

        /// <summary>
        /// Returns a list of cases based on the given user.
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <returns>List of Case object</returns>
        [HttpGet]
        [ValidateAntiForgeryToken]
        public JsonResult GetCasesByUser(ApplicationUser user)
        {
            List<Case> cases = new List<Case>();

            if (user != null)
            {
                var listResults = _context.Cases.Where(c => c.CaseUsers.Contains(user)).ToList();
                cases.AddRange(listResults);
            }
            return Json(cases);

        }

        /// <summary>
        /// Creates the document.
        /// </summary>
        /// <param name="id">int - The CaseID</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult CreateDocument(int id)
        {
            ViewBag.Id = id;
            ViewBag.Created =  DateTime.Now;
            ListOfDocumentTypes();
            return View();
        }

        /// <summary>
        /// Creates a document and store it into the database.
        /// </summary>
        /// <param name="b">DocumentBase type.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateDocument([Bind("CaseFK,DateCreated, DocType, DocName, isDraft, DocDescription, DocumentContent, OpenTime, CloseTime")] DocumentBase b)
        {
            var myView = "~/Cases/Details/" + b.CaseFK;

            if (ModelState.IsValid)
            {
                _context.Add(b);
                await _context.SaveChangesAsync();
                return Redirect(myView);
            }
           
            return Redirect(myView);
        }

        /// <summary>
        /// Gets the type of the MIME for a given filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>System.String.</returns>
        private string GetMIMEType(string filename)
        {
            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(filename, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        /// <summary>
        /// Opens the document from filesystem or database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Microsoft.AspNetCore.Mvc.FileStreamResult.</returns>
        public FileStreamResult OpenDocument(int id)
        {
            DocumentBase document = _context.DocumentBases.Find(id);

            if (document.DocPath != null)
            {
                string path = Path.Combine(_env.WebRootPath, document.DocPath);
                var stream = new MemoryStream(System.IO.File.ReadAllBytes(path));
                return new FileStreamResult(stream, new MediaTypeHeaderValue(GetMIMEType(document.DocName))) { FileDownloadName = document.DocName };

            }
            else
            {

                ///Create the doc
                ///Creates a new combined name

                var content = document.DocumentContent;
                var Renderer = new ChromePdfRenderer();
                var file = Path.Combine(_env.WebRootPath, "/_temp") + document.DocName ;
                var baseUrl = AppContext.BaseDirectory + "wwwroot/_temp";
                using var PDF = Renderer.RenderHtmlAsPdf(content, baseUrl); //Is not working even with absolute path
                PDF.SaveAs(document.DocName);

                

                ///Read the file
                var stream = new MemoryStream(System.IO.File.ReadAllBytes(file));

                return new FileStreamResult(stream, "application/pdf") { FileDownloadName = document.DocName };

            }

        }


        /// <summary>
        /// Return a list of open cases.
        /// </summary>
        /// <returns>List of Case objects</returns>
        [HttpGet]
        [ValidateAntiForgeryToken]
        public JsonResult GetOpenCases()
        {
            List<Case> cases = new List<Case>();

            var listResults = _context.Cases.Where(c => c.Status != "CASE_CLOSED")
            .OrderBy<Case, DateTime>(d => d.dateCreated)
            .ToList();
            cases.AddRange(listResults);

            return Json(cases);
        }

        /// <summary>
        /// Returns a list of closed cases.
        /// </summary>
        /// <returns>List of Case objects</returns>
        [HttpGet]
        [ValidateAntiForgeryToken]
        public JsonResult GetClosedCases()
        {
            List<Case> cases = new List<Case>();

            var listResults = _context.Cases.Where(c => c.Status.Equals("CASE_CLOSED"))
            .OrderBy<Case, DateTime>(d => d.dateCreated)
            .ToList();
            cases.AddRange(listResults);

            return Json(cases);
        }


        //Setters Section


        /// <summary>
        /// Closes a case according to its type.
        /// If the case is of type Mediation the method: 1. Destroy any documents it has,
        /// 2. Nulls all inner information, 3. Sets the case as closed.
        /// </summary>
        /// <param name="c">Case object</param>
        /// <returns>String - the confirmation result</returns>
        /// <exception cref="System.NullReferenceException">ex</exception>
        public IActionResult CloseCase(Case c)
        {

            try
            {
                //If the case is a mediation case then:
                if (c != null && c.CaseType.Equals("MEDIATION"))
                {

                    c.Client = null;
                    c.CaseTitle = "This mediation case is closed with no additional information";
                    c.ShortDescription = null;

                    //Delete from the DB all documents related to the case
                    if (c.Documents != null)
                    {
                        foreach (DocumentBase doc in c.Documents)
                        {
                            _context.Remove<DocumentBase>(doc);
                            _context.SaveChanges();
                        }
                    }
                    c.closeCase(); //Set the case as closed

                    //Delete from the DB all services related to the case
                    if (c.Services != null)
                    {
                        foreach (ChosenService service in c.Services)
                        {
                            _context.Remove<ChosenService>(service);
                            _context.SaveChanges();
                        }
                    }
                    _context.Cases.Update(c);
                    _context.SaveChanges();

                    this.StatusMessage = "The mediation case was destroyed and closed.";

                }
                else if (c != null)
                {
                    this.StatusMessage = "Case removed successfully.";
                    c.closeCase();

                    _context.SaveChanges();



                }

                return View(StatusMessage);

            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(nameof(ex));

            }
            RedirectToAction("Index");
        }

        /// <summary>
        /// This <c>JsonResult</c> creates a user from a Ajax call
        /// </summary>
        /// <param name="c">Client object</param>
        /// <param name="usr">ApplicationUser object</param>
        /// <param name="type">String</param>
        /// <param name="caseTitle">String</param>
        /// <param name="description">String</param>
        /// <param name="caseType">String</param>
        /// <returns>JsonResult.</returns>
        public JsonResult CreateCase(Client c, ApplicationUser usr, string type, string caseTitle, string description, string caseType)
        {
            var newCase = new Case(c, usr, type, caseTitle, description, caseType);
            _context.Cases.Add(newCase);
            _context.SaveChanges();
            return Json(newCase);
        }

        /// <summary>
        /// Uploads the document, test if it has the supported types and save it into a protected application folder (AppData)
        /// </summary>
        /// <param name="CaseID">The case identifier.</param>
        /// <param name="FirstName">The first name.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="caseType">Type of the case.</param>
        /// <param name="files">The files.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> UploadDocument(int CaseID, string FirstName, int clientId, string caseType, List<IFormFile> files)
        {
            ///Logic to create a new folder for client and for case if not exists
            var clientName = clientId + "-" + FirstName;
            var caseName = CaseID + "-" + caseType;
            var myView = "~/Cases/Details/" + CaseID;

            try
            {
                foreach (var f in files)
                {
                    if (f.Length > 0)
                    {
                        ///Getting FileName from the file
                        var fileName = Path.GetFileName(f.FileName);

                        ///Assigning Unique Filename using GeneratorBase class
                        var myUniqueFileName = GeneratorBase.GetDocumentStampID(CaseID) + "-" + fileName.Trim('.');

                        ///Getting the file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        ///Verifying it the file has the permitted extension types
                        if (fileExtension.ToLower() != ".pdf")
                            return View();

                        /// concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        /// Combines strings into a path like AppData/_clients/13-Sean/2-Mediation
                        /// Changed because of the path size and deepness
                        ///var filepath =
                        ///     new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "AppData", "_clients")).Root + $@"\{clientName}\{caseName}";

                        ///Gets the relative path to the folder or file
                        var fpath = AppDomain.CurrentDomain.GetData("AppData/_clients") + $@"\{clientName}\{caseName}";

                        ///Verifies if the folder exists, and if not creates it
                        if (!Directory.Exists(fpath)) Directory.CreateDirectory(fpath);

                        ///Creates a new combined name
                        var newName = Path.Combine(fpath, newFileName);

                        ///saves it to the folder
                        using (FileStream fs = System.IO.File.Create(newName))
                        {
                            f.CopyTo(fs);
                            fs.Flush();
                        }

                        ///Create the document object to save into the database
                        DocumentBase doc = new DocumentBase();
                        doc.isDraft = false;
                        doc.CaseFK = CaseID;
                        doc.DocName = newFileName;
                        doc.DocPath = newName;
                        doc.DateCreated = DateTime.Today;
                        doc.DateUpdated = DateTime.Today;
                        doc.DocLocation = "Application Folder";
                        doc.isDeleted = false;

                        _context.DocumentBases.Add(doc);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Redirect(myView);
            }

            return Redirect(myView);
        }

    }
}
