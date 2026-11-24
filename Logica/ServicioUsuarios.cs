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

        public void Registrar(Odontologo odontologo)
        {
            ValidarNuevoUsuario(odontologo);
            _repoOdontologos.Agregar(odontologo);
        }
        public void Registrar(Secretario secretario)
        {
            ValidarNuevoUsuario(secretario);
            _repoSecretarios.Agregar(secretario);
        }

        public Odontologo IniciarSesionOdontologo(string dni, string contrasena)
        {
            dni = Validador.NormalizarDni(dni);
            Odontologo odontologo = _repoOdontologos.ObtenerTodos().FirstOrDefault(o => o.DNI == dni);
            
            if (odontologo == null || !odontologo.Activo || !odontologo.VerificarContrasena(contrasena))
            {
                return null;
            }
            
            return odontologo;
        }
        public Secretario IniciarSesionSecretario(string dni, string contrasena)
        {
            dni = Validador.NormalizarDni(dni);
            Secretario secretario = _repoSecretarios.ObtenerTodos().FirstOrDefault(s => s.DNI == dni);

            if (secretario == null || !secretario.Activo || !secretario.VerificarContrasena(contrasena))
            {
                return null;
            }

            return secretario;
        }

        public void CambiarContrasena(Usuario usuario, string actual, string nueva)
        {
            if (!usuario.VerificarContrasena(actual))
            {
                throw new ArgumentException("La contraseña actual es incorrecta.");
            }
            if (usuario.VerificarContrasena(nueva))
            {
                throw new ArgumentException("La nueva contraseña debe ser distinta de la actual.");
            }

            usuario.EstablecerContrasena(nueva);

            if (usuario is Odontologo odontologo)
            {
                _repoOdontologos.Actualizar(odontologo);
            }
            else if (usuario is Secretario secretario)
            {
                _repoSecretarios.Actualizar(secretario);
            }
        }

        // Lista para la pantalla del secretario
        public List<Odontologo> ObtenerOdontologos()
        {
            return _repoOdontologos.ObtenerTodos().OrderBy(o => o.Apellido).ToList();
        }
        // Lista para ver los secretarios
        public List<Secretario> ObtenerSecretarios()
        {
            return _repoSecretarios.ObtenerTodos().OrderBy(s => s.Apellido).ToList();
        }

        private bool ExisteDni(string dni)
        {
            dni = Validador.NormalizarDni(dni);
            bool enOdontologos = _repoOdontologos.ObtenerTodos().Any(u => u.DNI == dni);
            bool enSecretarios = _repoSecretarios.ObtenerTodos().Any(u => u.DNI == dni);

            return enOdontologos || enSecretarios;
        }
        private void ValidarNuevoUsuario(Usuario usuario) //sirve para no escribir lo mismo para odontologo y secretario por si luego se debe realizar una modificación en las condiciones, esto te permite hacerlo en un solo lugar
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Apellido) ||
                string.IsNullOrWhiteSpace(usuario.DNI) || string.IsNullOrWhiteSpace(usuario.Correo) ||
                string.IsNullOrWhiteSpace(usuario.Telefono))
            {
                throw new InvalidOperationException("Faltan datos obligatorios del usuario.");
            }

            if (string.IsNullOrEmpty(usuario.HashContrasena))
            {
                throw new InvalidOperationException("El usuario no tiene una contraseña establecida.");
            }

            if (ExisteDni(usuario.DNI))
            {
                throw new InvalidOperationException("Ya existe un usuario con ese DNI.");
            }
        }

        //
        public void ActualizarDatos(Usuario usuario)
        {
            if (usuario is Odontologo odontologo)
            {
                _repoOdontologos.Actualizar(odontologo);
            }
            else if (usuario is Secretario secretario)
            {
                _repoSecretarios.Actualizar(secretario);
            }
        }

        public void CambiarEstadoSecretario(int id, bool activo)
        {
            Secretario secretario = _repoSecretarios.ObtenerPorId(id);
            if (secretario == null)
            {
                throw new InvalidOperationException("No existe el secretario seleccionado.");
            }
            secretario.Activo = activo;
            _repoSecretarios.Actualizar(secretario);
        }
    }
}