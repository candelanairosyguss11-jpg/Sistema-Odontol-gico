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
        public int DuracionMinutos { get; set; }
        public string Motivo { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))] //para que guarde el nombre y no el número
        public EstadoTurno Estado { get; set; } = EstadoTurno.Pendiente;

        [JsonIgnore]
        public DateTime Fin => Inicio.AddMinutes(DuracionMinutos);
    }

    //public class Turno
    //{   public int Id { get; set; }
    //    public Paciente Paciente { get; set; }
    //    public Odontologo Odontologo { get; set; }
    //    public DateTime FechaHora { get; set; }
    //    public string Estado { get; set; }      //confirmado, sin confirmar, cancelado, reprogramado


    //    public void Confirmar()
    //    {
    //        Estado = "Confirmado";
    //    }

    //    public void Cancelar()
    //    {
    //        Estado = "Cancelado";
    //    }

    //    public void Reprogramar(DateTime nuevaFechaHora)
    //    {
    //        FechaHora = nuevaFechaHora;
    //        Estado = "Reprogramado";
    //    }

    //}

}