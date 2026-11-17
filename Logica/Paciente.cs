using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public class Paciente : Persona
    {
        public DateOnly FechaNacimiento 
        { 
            get; 
            set
            {
                if (!Validador.EsFechaNacimientoValida(value))
                {
                    throw new ArgumentException("La fecha de nacimiento no es válida.");
                }
                field = value;
            }
        }

        [JsonIgnore]
        public int Edad //se calcula con la fecha de nacimiento así siempre está actualizada
        {
            get
            {
                DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
                int edad = hoy.Year - FechaNacimiento.Year;

                if (hoy < FechaNacimiento.AddYears(edad)) //si todavía no cumplió años le resta un año
                {
                    edad--;
                }

                return edad;
            }
        }
        public string ObraSocial { get; set; } = string.Empty;
        public string NumAfiliado { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;

    }
}