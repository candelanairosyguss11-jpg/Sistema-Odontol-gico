using System;
using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public abstract class Persona : IEntidad
    {
        public int Id { get; set; }
        public string Nombre
        {
            get;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }
                field = value.Trim();
            }
        }
        public string Apellido
        {
            get;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido no puede estar vacío.");
                }
                field = value.Trim();
            }
        }

        [JsonIgnore]
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }

        public string Correo
        {
            get;
            set
            {
                if (!Validador.EsCorreoValido(value))
                {
                    throw new ArgumentException("El correo no tiene un formato válido.");
                }
                field = value.Trim();
            }
        }
        public string DNI
        {
            get;
            set
            {
                string limpio = Validador.NormalizarDni(value);
                if (!Validador.EsDniValido(limpio))
                {
                    throw new ArgumentException("El DNI debe tener entre 7 y 8 dígitos.");
                }
                field = limpio;
            }
        }
        public string Telefono //por los +, guiones, etc
        {
            get;
            set
            {
                if (!Validador.EsTelefonoValido(value))
                {
                    throw new ArgumentException("El teléfono no tiene un formato válido.");
                }
                field = value.Trim();
            }
        }
    }
}