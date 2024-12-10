using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventosAPI.Data;
using SistemaEventosAPI.Models;

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
        public IActionResult GetEventos()
        {
            var eventos = _context.Eventos.Include(e => e.Participantes).ToList();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetEventoById(int id)
        {
            var evento = _context.Eventos.Include(e => e.Participantes).FirstOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();

            return Ok(evento);
        }


        [HttpPost]
        public IActionResult CreateEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEventos), new { id = evento.Id }, evento);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {
            var evento = _context.Eventos.Find(id);
            if (evento == null)
                return NotFound();

            _context.Eventos.Remove(evento);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
