using AssertLibrary;
using LegalManager.Data;
using LegalManager.Models.Entities.Cases;
using LegalManager.Models.Entities.Documents;
using LegalManager.Models.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Controllers
{
    /// <summary>Class DocumentController.
    /// Implements the <see cref="Controller" /></summary>
    public class DocumentController : Controller
    {
        /// <summary>
        /// Private attributs for dependency injection of
        /// the database context, the logger, the user manager,
        /// and th sign-in manager.
        /// </summary>
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DocumentBase> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// The constructor that injects the dependencies.
        /// </summary>
        /// <param name="signInManager">SignInManager object of type ApplicationUser</param>
        /// <param name="logger">Ilogger object</param>
        /// <param name="userManager">UserManager object of type ApplicationUser</param>
        /// <param name="context">ApplicationDbContext</param>
        public DocumentController(SignInManager<ApplicationUser> signInManager,
            ILogger<DocumentBase> logger,
            UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        /// Builds a list of documents for a given case
        /// </summary>
        /// <param name="caseId">Int</param>
        /// <returns>Json object - list results</returns>
        public JsonResult Index(int caseId)
        {
            List<DocumentBase> documents = new List<DocumentBase>();
            var listResults = _context.DocumentBases.Where(a => a.CaseFK == caseId)
                .OrderBy<DocumentBase, DateTime>(d => d.DateUpdated)
                .ToList();
            documents.AddRange(listResults);

            return Json(documents);
        }


        /// <summary>
        /// Creates a new document into the system. This method creates the document with the given paramenters and open it for edition.
        /// </summary>
        /// <param name="cs">Case object - cannot be null</param>
        /// <param name="docName">String</param>
        /// <param name="docDescription">String</param>
        /// <param name="docContent">String</param>
        /// <param name="lables">String </param>
        /// <param name="location">String</param>
        /// <returns></returns>
        public IActionResult CreateDocument(Case cs, string docName, string docDescription, string docContent, string lables, string location )
        {
            Assert.IsNotNull(cs);
            Assert.IsOfType<Case>(cs);
            Assert.IsNotNull(docName);
            Assert.IsNotNull(docDescription);

            DocumentBase doc = new DocumentBase();
            doc.isDraft = true;
            doc.Case = cs;
            doc.CaseFK = cs.CaseID;
            doc.DocName = docName;  
            doc.DocDescription = docDescription;
            doc.DocumentContent = docContent;
            doc.DocLocation = location;

            ///Getting the sting and separating it to insert into the list (e.g. "Statement, Personal Document" => ["Statement", "Personal Document"]
            string[] lb = lables.Split(",");
            foreach (string lbName in lb)
            {
                doc.DocLabels.Add(lbName);
            }

            doc.DateCreated = DateTime.Now;


            _context.DocumentBases.Add(doc);
            _context.SaveChanges();

            return View(doc);

        }

        /// <summary>
        /// Try to find a document to edit
        /// </summary>
        /// <param name="id">Integer</param>
        /// <returns>Redirects to the overloaded method that edits.</returns>
        public async Task<IActionResult> EditDocument(int? id)
        {
            Assert.IsOfType<int>(id);
            Assert.IsNotNull(id);

            var document = await _context.DocumentBases.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);


        }

        /// <summary>
        /// Edits the current document and returns it updated state.
        /// </summary>
        /// <param name="id">Integer</param>
        /// <param name="document">DocumentBase type</param>
        /// <returns>View</returns>
        // POST: Document/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDocument(int id, [Bind("DocumentID, CaseFK, Case, DocName, DocDescription, " +
            "DocumentContent, DocFileName, DocPath, DocLabels, OpenTime, CloseTime, DocLocation, " +
            "DocType, IsDraft, DateUpdated, IsDeleted")] DocumentBase document)
        {
            if (id != document.DocumentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    document.setEndTime();
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentID))
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
            return View(document);
        }

        /// <summary>
        /// Closes a document by setting the end time and saving the changes.
        /// </summary>
        /// <param name="id">Integer</param>
        /// <returns>Redirect to the Index View</returns>
        public async Task<IActionResult> CloseDocument(int id)
        {
            Assert.IsNotNull(id);

            DocumentBase document = await _context.DocumentBases.FindAsync(id);
            if (!DocumentExists(document.DocumentID))
            {
                return NotFound();
            }
            document.setEndTime();
            _context.Update(document);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// Private method that checks if the document exists and the id is the same.
        /// </summary>
        /// <param name="id">Integer</param>
        /// <returns>Boolean</returns>
        private bool DocumentExists(int id)
        {
            return _context.DocumentBases.Any(e => e.DocumentID == id);
        }
    }
}
