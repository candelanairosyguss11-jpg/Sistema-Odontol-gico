using System;

namespace Sistema_Odontológico
{
    public class Tratamiento : IEntidad
    {
        public int Id { get; set; }
        public int OdontologoId { get; set; }

        public string Nombre
        {
            get;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del tratamiento no puede estar vacío.");
                }
                field = value.Trim();
            }
        }

        // duración sugerida, sirve para autocompletar la del turno
        public int DuracionMinutos
        {
            get;
            set
            {
                if (value < Turno.DuracionMinima || value > Turno.DuracionMaxima)
                {
                    throw new ArgumentException("La duración sugerida no es válida.");
                }
                field = value;
            }
        } = 30;

        public bool Activo { get; set; } = true; // baja lógica para no romper turnos viejos

        public override string ToString()
        {
            return Nombre; // útil para mostrarlo en listas desplegables
        }
    }
}