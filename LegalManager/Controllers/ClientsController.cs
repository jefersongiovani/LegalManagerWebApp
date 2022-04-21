// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-04-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-05-2022
// ***********************************************************************
// <copyright file="ClientsController.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Data;
using LegalManager.Models.Entities.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Areas.Administrative.Controllers
{
    /// <summary>
    /// Controller responsible for providing common operations with
    /// the Client object
    /// </summary>
    public class ClientsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="context">ApplicationDbContext object</param>
        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Provides a list of clients for the Clients View.
        /// </summary>
        /// <returns>IActionResult object to render the view.</returns>
        /// GET: /Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }


        /// <summary>
        /// Provide a list of clients to AJAX grid
        /// </summary>
        /// <returns>Json with list of clients</returns>
        [HttpGet]
        public async Task<IActionResult> GetListOfClients()
        {
            return Json(await _context.Clients.ToListAsync());
        }

        /// <summary>
        /// Provides the information about a selected client.
        /// </summary>
        /// <param name="id">Integer - the Client ID</param>
        /// <returns>IActionResult object to render the view.</returns>
        /// GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }
            ViewBag.Cases = _context.Cases.Where(c => c.clientID == id).ToList();

            return View(client);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// GET: Administrative/Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Administrative/Clients/Create
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,FirstName,LastName,EmailAddress,MobileNumber,RegisteredDate,DateOfBirth,IdentificationName,Identification,Nationality")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        /// <summary>
        /// Starts the process of updating a client by trying to find the client.
        /// </summary>
        /// <param name="id">Integer</param>
        /// <returns>Returns to the view form with the loaded data</returns>
        /// GET: Administrative/Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        /// <summary>
        /// Updates a client based on the form's content.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="client">Client Object</param>
        /// <returns>Returns to the view with the updated data.</returns>
        /// POST: Administrative/Clients/Edit/5
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,FirstName,LastName,EmailAddress,MobileNumber,RegisteredDate,DateOfBirth,IdentificationName,Identification,Nationality")] Client client)
        {
            if (id != client.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientID))
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
            return View(client);
        }

        /// <summary>
        /// Performs the starting point of the deletion process.
        /// It try to find the client by its id and if it succeed
        /// it reloads with the id, and proceed to deletion.
        /// </summary>
        /// <param name="id">Integer</param>
        /// <returns>IActionResult.</returns>
        /// GET: Administrative/Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }
        /// <summary>
        /// Deletes a given client after confirmation
        /// </summary>
        /// <param name="id">Integer</param>
        /// <returns>Returns to the main view if success.</returns>
        /// POST: Administrative/Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Private method that returns true if a Client object is found
        /// matching the id parameter
        /// </summary>
        /// <param name="id">Integer</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientID == id);
        }

        /// <summary>
        /// Returns a list of cases for a given client
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of Cases</returns>
        public async Task<IActionResult> ClientCases(int id)
        {
            var cases = _context.Cases.Where(c => c.clientID == id).ToList();
            return View(cases);
        }
    }
}
