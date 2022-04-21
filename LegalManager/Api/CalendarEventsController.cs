// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-07-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="CalendarEventsController.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Data;
using LegalManager.Models.Entities.Calendar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalManager.Api
{
    /// <summary>
    /// Class CalendarEventsController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventsController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarEventsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CalendarEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>ActionResult&lt;IEnumerable&lt;Event&gt;&gt;.</returns>
        /// GET: api/CalendarEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return await _context.Events
                .Where(e => !((e.End <= start) || (e.Start >= end)))
                .ToListAsync();
        }

        /// <summary>
        /// Gets the calendar event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;Event&gt;.</returns>
        /// GET: api/CalendarEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetCalendarEvent(int id)
        {
            var calendarEvent = await _context.Events.FindAsync(id);

            if (calendarEvent == null)
            {
                return NotFound();
            }

            return calendarEvent;
        }

        /// <summary>
        /// Puts the calendar event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="calendarEvent">The calendar event.</param>
        /// <returns>IActionResult.</returns>
        /// PUT: api/CalendarEvents/5
        /// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarEvent(int id, Event calendarEvent)
        {
            if (id != calendarEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(calendarEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Posts the calendar event.
        /// </summary>
        /// <param name="calendarEvent">The calendar event.</param>
        /// <returns>ActionResult&lt;Event&gt;.</returns>
        /// POST: api/CalendarEvents
        /// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostCalendarEvent(Event calendarEvent)
        {
            _context.Events.Add(calendarEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarEvent", new { id = calendarEvent.Id }, calendarEvent);
        }

        /// <summary>
        /// Deletes the calendar event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// DELETE: api/CalendarEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarEvent(int id)
        {
            var calendarEvent = await _context.Events.FindAsync(id);
            if (calendarEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(calendarEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Calendars the event exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CalendarEventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
