using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerParcialGrupo4WebApi.Data;
using PrimerParcialGrupo4WebApi.Models;

namespace PrimerParcialGrupo4WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAll()
        {
            var events = await _context.Events.AsNoTracking().ToListAsync();
            return Ok(events);
        }

        // GET: api/events/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetById(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        // POST: api/events
        [HttpPost]
        public async Task<ActionResult<Event>> Create(Event ev)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Events.Add(ev);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ev.Id }, ev);
        }

        // PUT: api/events/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Event ev)
        {
            if (id != ev.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _context.Events.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Title = ev.Title;
            existing.Location = ev.Location;
            existing.StartAt = ev.StartAt;
            existing.EndAt = ev.EndAt;
            existing.IsOnline = ev.IsOnline;
            existing.Notes = ev.Notes;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/events/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
