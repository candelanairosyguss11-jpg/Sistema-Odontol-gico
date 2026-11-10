using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo
        {
            get;
            set
            {
                if(!Validador.EsCorreoValido(value))
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
        public string HashContrasena { get; set; }
        public string SalContrasena { get; set; }
        public bool Activo { get; set; } = true; //para dar de baja a odontologos y secretarios

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public abstract string Rol { get; }
    }
}
