using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Odontológico
{
    public class ServicioPacientes
    {
        private readonly IRepositorio<Paciente> _repoPacientes;

        public ServicioPacientes(IRepositorio<Paciente> repoPacientes)
        {
            _repoPacientes = repoPacientes;
        }

        public void Registrar(Paciente paciente)
        {
            ValidarDatosObligatorios(paciente);

            if (ExisteDni(paciente.DNI, 0))
            {
                throw new InvalidOperationException("Ya existe un paciente con ese DNI.");
            }

            _repoPacientes.Agregar(paciente);
        }

        public void Actualizar(Paciente paciente)
        {
            ValidarDatosObligatorios(paciente);

            if (ExisteDni(paciente.DNI, paciente.Id))
            {
                throw new InvalidOperationException("Ya existe otro paciente con ese DNI.");
            }

            _repoPacientes.Actualizar(paciente);
        }

        public Paciente BuscarPorDni(string dni)
        {
            dni = Validador.NormalizarDni(dni);
            return _repoPacientes.ObtenerTodos().FirstOrDefault(p => p.DNI == dni);
        }

        public Paciente ObtenerPorId(int id)
        {
            return _repoPacientes.ObtenerPorId(id);
        }

        public List<Paciente> BuscarPorNombre(string texto) //para el buscador. busca por nombre, apellido o DNI sin distinguir mayúsculas
        {
            List<Paciente> todos = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(texto))
            {
                return todos;
            }

            texto = texto.Trim().ToLower();
            return todos.Where(p => p.NombreCompleto.ToLower().Contains(texto) || p.DNI.Contains(texto)).ToList();
        }

        public List<Paciente> ObtenerTodos()
        {
            return _repoPacientes.ObtenerTodos().OrderBy(p => p.Apellido).ThenBy(p => p.Nombre).ToList();
        }

        private bool ExisteDni(string dni, int idAExcluir) // idAExcluir: el Id del paciente que se está editando (0 si es uno nuevo)
        {
            dni = Validador.NormalizarDni(dni);
            return _repoPacientes.ObtenerTodos().Any(p => p.DNI == dni && p.Id != idAExcluir);
        }

        private void ValidarDatosObligatorios(Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.Nombre) || string.IsNullOrWhiteSpace(paciente.Apellido) ||
                string.IsNullOrWhiteSpace(paciente.DNI) || string.IsNullOrWhiteSpace(paciente.Correo) ||
                string.IsNullOrWhiteSpace(paciente.Telefono) || paciente.FechaNacimiento == default)
            {
                throw new InvalidOperationException("Faltan datos obligatorios del paciente.");
            }
        }
    }
}