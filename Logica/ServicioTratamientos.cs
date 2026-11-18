using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Odontológico
{
    public class ServicioTratamientos
    {
        private readonly IRepositorio<Tratamiento> _repoTratamientos;

        public ServicioTratamientos(IRepositorio<Tratamiento> repoTratamientos)
        {
            _repoTratamientos = repoTratamientos;
        }

        public void Agregar(Tratamiento tratamiento)
        {
            ValidarTratamiento(tratamiento, 0);
            _repoTratamientos.Agregar(tratamiento);
        }

        public void Actualizar(Tratamiento tratamiento)
        {
            ValidarTratamiento(tratamiento, tratamiento.Id);
            _repoTratamientos.Actualizar(tratamiento);
        }

        public void Desactivar(int id)
        {
            CambiarEstado(id, false);
        }

        public void Reactivar(int id)
        {
            CambiarEstado(id, true);
        }

        public Tratamiento ObtenerPorId(int id) // devuelve el tratamiento aunque esté inactivo (pq los turnos viejos lo necesitan)
        {
            return _repoTratamientos.ObtenerPorId(id);
        }

        public List<Tratamiento> ObtenerActivosDeOdontologo(int odontologoId) // para agendar turnos. SOLO los activos
        {
            return _repoTratamientos.ObtenerTodos()
                .Where(t => t.OdontologoId == odontologoId && t.Activo)
                .OrderBy(t => t.Nombre).ToList();
        }

        // para la pantalla de gestión. todos, también los inactivos
        public List<Tratamiento> ObtenerTodosDeOdontologo(int odontologoId)
        {
            return _repoTratamientos.ObtenerTodos()
                .Where(t => t.OdontologoId == odontologoId)
                .OrderBy(t => t.Nombre).ToList();
        }

        // para armar el texto de un turno a partir de su TratamientosIds
        public List<Tratamiento> ObtenerPorIds(List<int> ids)
        {
            return _repoTratamientos.ObtenerTodos().Where(t => ids.Contains(t.Id)).ToList();
        }

        private void ValidarTratamiento(Tratamiento tratamiento, int idAExcluir)
        {
            if (tratamiento.OdontologoId <= 0)
            {
                throw new InvalidOperationException("El tratamiento no tiene un odontólogo asignado.");
            }

            if (string.IsNullOrWhiteSpace(tratamiento.Nombre))
            {
                throw new InvalidOperationException("El tratamiento no tiene nombre.");
            }

            Tratamiento existente = BuscarPorNombre(tratamiento.OdontologoId, tratamiento.Nombre, idAExcluir);

            if (existente != null)
            {
                if (existente.Activo)
                {
                    throw new InvalidOperationException("Ya tenés un tratamiento con ese nombre.");
                }

                throw new InvalidOperationException("Ya tenés un tratamiento con ese nombre, pero está desactivado. Reactivalo desde tu lista de tratamientos.");
            }
        }

        // devuelve el tratamiento con ese nombre (del mismo odontólogo), o null si no hay
        private Tratamiento BuscarPorNombre(int odontologoId, string nombre, int idAExcluir)
        {
            string buscado = nombre.Trim().ToLower();
            return _repoTratamientos.ObtenerTodos().FirstOrDefault(t => t.OdontologoId == odontologoId
                && t.Id != idAExcluir && t.Nombre.ToLower() == buscado); // mismo odontólogo, mismo nombre (sin distinguir mayúsculas), distinto Id
        }

        private void CambiarEstado(int id, bool activo)
        {
            Tratamiento tratamiento = _repoTratamientos.ObtenerPorId(id);

            if (tratamiento == null)
            {
                throw new InvalidOperationException("No existe un tratamiento con ese Id.");
            }

            tratamiento.Activo = activo;
            _repoTratamientos.Actualizar(tratamiento);
        }
    }
}