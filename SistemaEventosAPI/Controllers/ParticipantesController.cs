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
    public class ParticipantesController : ControllerBase
    {
        private readonly EventosDbContext _context;

        public ParticipantesController(EventosDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterParticipante([FromBody] Participante participante)
        {
            await _context.Participantes.AddAsync(participante);
            await _context.SaveChangesAsync();
            return Ok(participante);
        }

        [HttpGet("evento/{eventoId}")]
        public async Task<IActionResult> GetParticipantesByEvento(int eventoId)
        {
            var participantes = await _context.Participantes.Where(p => p.EventoId == eventoId).ToListAsync();
            return Ok(participantes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
                return NotFound();

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
