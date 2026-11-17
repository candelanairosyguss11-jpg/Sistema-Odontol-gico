using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Odontológico
{
    public class ServicioUsuarios
    {
        private readonly IRepositorio<Odontologo> _repoOdontologos; //para que el servicio no sepa que hay un JSON detrás (inyección de dependencias)
        private readonly IRepositorio<Secretario> _repoSecretarios;

        public ServicioUsuarios(IRepositorio<Odontologo> repoOdontologos,
                                IRepositorio<Secretario> repoSecretarios)
        {
            _repoOdontologos = repoOdontologos;
            _repoSecretarios = repoSecretarios;
        }

        public void Registrar(Odontologo odontologo) { }
        public void Registrar(Secretario secretario) { }

        public Odontologo IniciarSesionOdontologo(string dni, string contrasena) { }
        public Secretario IniciarSesionSecretario(string dni, string contrasena) { }

        public void CambiarContrasena(Usuario usuario, string actual, string nueva) { }

        // Listado para la pantalla del secretario
        public List<Odontologo> ObtenerOdontologos() { }

        private bool ExisteDni(string dni)
        {
            dni = Validador.NormalizarDni(dni);
            
        }
    }
}