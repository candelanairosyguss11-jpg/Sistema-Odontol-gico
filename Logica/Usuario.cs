using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public abstract class Usuario : Persona
    {
        public string HashContrasena { get; set; } = string.Empty;
        public string SalContrasena { get; set; } = string.Empty;
        public bool Activo { get; set; } = true; //para dar de baja a secretarios
        
        [JsonIgnore]
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