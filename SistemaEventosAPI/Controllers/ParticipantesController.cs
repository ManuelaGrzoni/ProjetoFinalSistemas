using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventosAPI.Data;
using SistemaEventosAPI.Models;

namespace SistemaEventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantesController : ControllerBase
    {
        private readonly EventosDbContext _context;

        public ParticipantesController(EventosDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult RegisterParticipante([FromBody] Participante participante)
        {
            _context.Participantes.Add(participante);
            _context.SaveChanges();
            return Ok(participante);
        }


        [HttpGet("evento/{eventoId}")]
        public IActionResult GetParticipantesByEvento(int eventoId)
        {
            var participantes = _context.Participantes.Where(p => p.EventoId == eventoId).ToList();
            return Ok(participantes);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteParticipante(int id)
        {
            var participante = _context.Participantes.Find(id);
            if (participante == null)
                return NotFound();

            _context.Participantes.Remove(participante);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
