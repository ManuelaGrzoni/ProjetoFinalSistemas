namespace SistemaEventosAPI.Models

{
    using System;
    using System.Collections.Generic;

    public class Evento
    {
        public int Id { get; set; }  // Identificador único
        public string Nombre { get; set; } 
        public DateTime Fecha { get; set; }  // Fecha del evento
        public string Ubicación { get; set; } 
        public int Capacidad { get; set; }  // Número máximo de participantes
        public List<Participante> Participantes { get; set; }  // Relación con Participante

    }
}
