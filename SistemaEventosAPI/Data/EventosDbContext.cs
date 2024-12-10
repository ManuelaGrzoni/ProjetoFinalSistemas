using Microsoft.EntityFrameworkCore;
using SistemaEventosAPI.Models;

namespace SistemaEventosAPI.Data
{
    public class EventosDbContext : DbContext
    {
        public EventosDbContext(DbContextOptions<EventosDbContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }  // Tabla de eventos
        public DbSet<Participante> Participantes { get; set; }  // Tabla de participantes

    }
}
