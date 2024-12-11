namespace SistemaEventosAPI.Models
{
    public class Participante
    {
        public int Id { get; set; }  // Identificador único
        public string Nombre { get; set; } // Nombre del participante
        public string Correo { get; set; } = string.Empty;// Correo del participante
        public int EventoId { get; set; }  // FK al evento
    }
}
