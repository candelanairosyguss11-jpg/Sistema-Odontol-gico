using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public abstract class Usuario : IEntidad
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
        public bool Activo { get; set; } = true; //para dar de baja a secretarios

        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        public abstract string Rol { get; }

        public void EstablecerContrasena(string contrasena)
        {
            if (!Validador.EsContrasenaValida(contrasena))
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres, con al menos una letra mayúscula, una minúscula y un número.");
            }

            var (hash, sal) = ServicioContrasenas.Hashear(contrasena);
            HashContrasena = hash;
            SalContrasena = sal;
        }

        public bool VerificarContrasena(string contrasena) //para cuando se loggean
        {
            return ServicioContrasenas.Verificar(contrasena, HashContrasena, SalContrasena);
        }
    }
}