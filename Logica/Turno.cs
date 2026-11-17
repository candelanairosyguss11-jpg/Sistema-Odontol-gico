using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public enum EstadoTurno { Pendiente, Asistio, NoAsistio, Cancelado, Reprogramado }

    public class Turno : IEntidad
    {
        public const int DuracionMinima = 15;
        public const int DuracionMaxima = 240; // 4 horas

        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int OdontologoId { get; set; }
        public DateTime Inicio { get; set; }

        public int DuracionMinutos 
        { 
            get; 
            set
            {
                if (value < DuracionMinima || value > DuracionMaxima)
                {
                    throw new ArgumentException($"La duración debe estar entre {DuracionMinima} y {DuracionMaxima} minutos.");
                }
                field = value;
            }
        }

        public List<int> TratamientosIds { get; set; } = new List<int>();
        public string Detalle { get; set; } = string.Empty; // nota previa opcional

        [JsonConverter(typeof(JsonStringEnumConverter))] //para que guarde el nombre y no el número

        public int? TurnoOriginalId { get; set; } // si es una reprogramación

        public EstadoTurno Estado { get; set; } = EstadoTurno.Pendiente;

        [JsonIgnore]
        public DateTime Fin
        {
            get { return Inicio.AddMinutes(DuracionMinutos); }
        }

        public bool SeSuperponeCon(Turno otro)
        {
            return OdontologoId == otro.OdontologoId
                && Inicio < otro.Fin
                && otro.Inicio < Fin;
        }

        public void Cancelar()
        {
            if (Estado != EstadoTurno.Pendiente)
            {
                throw new InvalidOperationException("Solo se puede cancelar un turno pendiente.");
            }
            Estado = EstadoTurno.Cancelado;
        }

        public void MarcarReprogramado()
        {
            if (Estado != EstadoTurno.Pendiente)
            {
                throw new InvalidOperationException("Solo se puede reprogramar un turno pendiente.");
            }
            Estado = EstadoTurno.Reprogramado;
        }

        public void MarcarAsistencia(bool asistio)
        {
            if (Estado != EstadoTurno.Pendiente)
            {
                throw new InvalidOperationException("El turno ya no está pendiente.");
            }
            if (DateTime.Now < Inicio)
            {
                throw new InvalidOperationException("No se puede marcar la asistencia antes del turno.");
            }

            if (asistio)
            {
                Estado = EstadoTurno.Asistio;
            }
            else
            {
                Estado = EstadoTurno.NoAsistio;
            }
        }
    }
}