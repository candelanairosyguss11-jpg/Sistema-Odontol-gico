using System;

namespace Sistema_Odontológico
{
    public class Observacion
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int OdontologoId { get; set; }
        public int? TurnoId { get; set; } // opcional. turno al que se vincula

        public string Texto
        {
            get;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La observación no puede estar vacía.");
                }
                field = value.Trim();
            }
        }
    }
}