using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventosAPI.Data;
using SistemaEventosAPI.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SistemaEventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly EventosDbContext _context;

        public EventosController(EventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventos()
        {
            var eventos = await _context.Eventos.Include(e => e.Participantes).ToListAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventoById(int id)
        {
            var evento = await _context.Eventos.Include(e => e.Participantes).FirstOrDefaultAsync(e => e.Id == id);
            if (evento == null)
                return NotFound();

            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEventos), new { id = evento.Id }, evento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
                return NotFound();

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}