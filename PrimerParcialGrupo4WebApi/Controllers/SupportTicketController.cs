using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerParcialGrupo4WebApi.Data;
using PrimerParcialGrupo4WebApi.Models;

namespace PrimerParcialGrupo4WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportTicketController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SupportTicketController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SupportTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetAll()
        {
            return await _context.SupportTickets.ToListAsync();
        }

        // GET: api/SupportTicket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicket>> GetById(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);

            if (ticket == null)
                return NotFound();

            return ticket;
        }

        // POST: api/SupportTicket
        [HttpPost]
        public async Task<ActionResult<SupportTicket>> Create(SupportTicket ticket)
        {
            ticket.OpenedAt = DateTime.UtcNow;

            _context.SupportTickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        // PUT: api/SupportTicket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SupportTicket ticket)
        {
            if (id != ticket.Id)
                return BadRequest("ID del ticket no coincide con el parámetro");

            var existing = await _context.SupportTickets.FindAsync(id);
            if (existing == null)
                return NotFound();

            // Actualizar campos
            existing.Subject = ticket.Subject;
            existing.RequesterEmail = ticket.RequesterEmail;
            existing.Description = ticket.Description;
            existing.Severity = ticket.Severity;
            existing.Status = ticket.Status;
            existing.ClosedAt = ticket.ClosedAt;
            existing.AssignedTo = ticket.AssignedTo;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SupportTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);
            if (ticket == null)
                return NotFound();

            _context.SupportTickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}