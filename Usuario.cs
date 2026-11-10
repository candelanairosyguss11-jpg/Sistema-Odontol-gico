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
        public string Correo { get; set; }
        public string DNI { get; set; } //para evitar problemas con los .
        public string Telefono { get; set; } //por los +, guiones, etc
        public string HashContrasena { get; set; }
        public string SalContrasena { get; set; }
        public bool Activo { get; set; } = true; //para dar de baja a odontologos y secretarios

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public abstract string Rol { get; }
    }
}
