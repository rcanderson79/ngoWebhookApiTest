using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngoWebhookApi.Models;

namespace ngoWebhookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class exampleEventsController : ControllerBase
    {
        private readonly exampleEventContext _context;

        public exampleEventsController(exampleEventContext context)
        {
            _context = context;
        }

        // GET: api/exampleEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ngoEvent>>> GetexampleEvents()
        {
            return await _context.exampleEvents.ToListAsync();
        }

        // GET: api/exampleEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ngoEvent>> GetexampleEvent(string id)
        {
            var exampleEvent = await _context.exampleEvents.FindAsync(id);

            if (exampleEvent == null)
            {
                return NotFound();
            }

            return exampleEvent;
        }

        // PUT: api/exampleEvents/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutexampleEvent(string id, ngoEvent exampleEvent)
        {
            if (id != exampleEvent.id)
            {
                return BadRequest();
            }

            _context.Entry(exampleEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!exampleEventExists(id))
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

        // POST: api/exampleEvents
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ngoEvent>> PostexampleEvent(ngoEvent exampleEvent)
        {
            _context.exampleEvents.Add(exampleEvent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (exampleEventExists(exampleEvent.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetexampleEvent), new { id = exampleEvent.id }, exampleEvent);
        }

        // DELETE: api/exampleEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ngoEvent>> DeleteexampleEvent(string id)
        {
            var exampleOrder = await _context.exampleEvents.FindAsync(id);
            if (exampleOrder == null)
            {
                return NotFound();
            }

            _context.exampleEvents.Remove(exampleOrder);
            await _context.SaveChangesAsync();

            return exampleOrder;
        }

        private bool exampleEventExists(string id)
        {
            return _context.exampleEvents.Any(e => e.id == id);
        }
    }
}
