namespace SistemaEventosAPI.Models

{
    using System;
    using System.Collections.Generic;

    public class Evento
    {
        public int Id { get; set; }  // Identificador único
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }  // Fecha del evento
        public string Ubicación { get; set; } = string.Empty;
        public int Capacidad { get; set; }  // Número máximo de participantes

        // Inicializa como lista vacía para evitar que sea requerido
        public List<Participante> Participantes { get; set; } = new List<Participante>();

    }
}
