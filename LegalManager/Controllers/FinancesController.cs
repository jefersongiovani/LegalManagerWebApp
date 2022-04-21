// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="FinancesController.cs" company="LegalManager">
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
using LegalManager.Models.Entities.Finance;

namespace LegalManager.Controllers
{
    /// <summary>
    /// Class FinancesController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    public class FinancesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public FinancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// GET: Finances
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookKeepings.ToListAsync());
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// GET: Finances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookKeeping = await _context.BookKeepings
                .FirstOrDefaultAsync(m => m.Bid == id);
            if (bookKeeping == null)
            {
                return NotFound();
            }

            return View(bookKeeping);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// GET: Finances/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified book keeping.
        /// </summary>
        /// <param name="bookKeeping">The book keeping.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Finances/Create
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bid,OperationDate,Description,Value,Operation")] BookKeeping bookKeeping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookKeeping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookKeeping);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// GET: Finances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookKeeping = await _context.BookKeepings.FindAsync(id);
            if (bookKeeping == null)
            {
                return NotFound();
            }
            return View(bookKeeping);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookKeeping">The book keeping.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Finances/Edit/5
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bid,OperationDate,Description,Value,Operation")] BookKeeping bookKeeping)
        {
            if (id != bookKeeping.Bid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookKeeping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookKeepingExists(bookKeeping.Bid))
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
            return View(bookKeeping);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// GET: Finances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookKeeping = await _context.BookKeepings
                .FirstOrDefaultAsync(m => m.Bid == id);
            if (bookKeeping == null)
            {
                return NotFound();
            }

            return View(bookKeeping);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// POST: Finances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookKeeping = await _context.BookKeepings.FindAsync(id);
            _context.BookKeepings.Remove(bookKeeping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Books the keeping exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool BookKeepingExists(int id)
        {
            return _context.BookKeepings.Any(e => e.Bid == id);
        }
    }
}
