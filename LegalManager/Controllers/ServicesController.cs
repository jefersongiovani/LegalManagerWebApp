// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ServicesController.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LegalManager.Data;
using LegalManager.Models.Entities.Services;

namespace LegalManager.Controllers
{
    /// <summary>
    /// Class ServicesController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    public class ServicesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// GET: Services
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChosenServices.ToListAsync());
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chosenService = await _context.ChosenServices
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (chosenService == null)
            {
                return NotFound();
            }

            return View(chosenService);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// GET: Services/Create
        public IActionResult Create()
        {
            ListOfServiceTypes();
            return View();
        }

        /// <summary>
        /// Creates the specified chosen service.
        /// </summary>
        /// <param name="chosenService">The chosen service.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Services/Create
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceID,Title,Description,Cost,ServiceType")] ChosenService chosenService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chosenService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(chosenService);
        }

        /// <summary>
        /// Lists the of service types.
        /// </summary>
        /// <param name="selectedCaseType">Type of the selected case.</param>
        private void ListOfServiceTypes(Object selectedCaseType = null)
        {
            List<String> items = new List<string>();

            var enumValues = Enum.GetNames((typeof(ServiceTypes)));
            foreach (string value in enumValues)
            {
                items.Add(value);
            }
            ViewBag.ServiceTypes = new SelectList(items, selectedCaseType);

        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chosenService = await _context.ChosenServices.FindAsync(id);
            if (chosenService == null)
            {
                return NotFound();
            }
            return View(chosenService);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="chosenService">The chosen service.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Services/Edit/5
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceID,Title,Description,Cost,ServiceType")] ChosenService chosenService)
        {
            if (id != chosenService.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chosenService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChosenServiceExists(chosenService.ServiceID))
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
            return View(chosenService);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chosenService = await _context.ChosenServices
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (chosenService == null)
            {
                return NotFound();
            }

            return View(chosenService);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chosenService = await _context.ChosenServices.FindAsync(id);
            _context.ChosenServices.Remove(chosenService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Chosens the service exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ChosenServiceExists(int id)
        {
            return _context.ChosenServices.Any(e => e.ServiceID == id);
        }
    }
}
