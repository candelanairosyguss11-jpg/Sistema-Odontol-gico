using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Odontológico
{
    public class ServicioTurnos
    {
        private static readonly TimeSpan HoraApertura = TimeSpan.FromHours(8); //solo desde las 8hs
        private static readonly TimeSpan HoraCierre = TimeSpan.FromHours(21); //solo hasta las 21hs

        private readonly IRepositorio<Turno> _repoTurnos;
        private readonly ServicioPacientes _servicioPacientes;
        private readonly ServicioTratamientos _servicioTratamientos;

        public ServicioTurnos(IRepositorio<Turno> repoTurnos,
                              ServicioPacientes servicioPacientes,
                              ServicioTratamientos servicioTratamientos)
        {
            _repoTurnos = repoTurnos;
            _servicioPacientes = servicioPacientes;
            _servicioTratamientos = servicioTratamientos;
        }

        public void Agendar(Turno turno)
        {
            ValidarTurno(turno, 0);
            _repoTurnos.Agregar(turno);
        }

        // crea un turno nuevo (copia del original con otra fecha/duración) y marca el original como Reprogramado
        public Turno Reprogramar(int turnoId, DateTime nuevoInicio, int nuevaDuracion)
        {
            Turno original = ObtenerTurnoExistente(turnoId);

            if (original.Estado != EstadoTurno.Pendiente)
            {
                throw new InvalidOperationException("Solo se puede reprogramar un turno pendiente.");
            }

            Turno nuevo = new Turno();
            nuevo.PacienteId = original.PacienteId;
            nuevo.OdontologoId = original.OdontologoId;
            nuevo.Inicio = nuevoInicio;
            nuevo.DuracionMinutos = nuevaDuracion;
            nuevo.TratamientosIds = new List<int>(original.TratamientosIds); //copia de la lista, para no compartir el mismo objeto y que se terminen modificando ambos
            nuevo.Detalle = original.Detalle;
            nuevo.TurnoOriginalId = original.Id;

            ValidarTurno(nuevo, original.Id); //se excluye el original para que no se superponga consigo mismo

            //recién acá, con todo validado, se modifica algo
            _repoTurnos.Agregar(nuevo);
            original.MarcarReprogramado();
            _repoTurnos.Actualizar(original);

            return nuevo;
        }

        public void Cancelar(int turnoId)
        {
            Turno turno = ObtenerTurnoExistente(turnoId);
            turno.Cancelar();
            _repoTurnos.Actualizar(turno);
        }

        public void MarcarAsistencia(int turnoId, bool asistio)
        {
            Turno turno = ObtenerTurnoExistente(turnoId);
            turno.MarcarAsistencia(asistio);
            _repoTurnos.Actualizar(turno);
        }

        public Turno ObtenerPorId(int id)
        {
            return _repoTurnos.ObtenerPorId(id);
        }

        // turnos de un odontólogo en un día (sin cancelados ni reprogramados), ordenados por hora
        public List<Turno> ObtenerAgenda(int odontologoId, DateTime dia)
        {
            return _repoTurnos.ObtenerTodos()
                .Where(t => t.OdontologoId == odontologoId && t.OcupaHorario && t.Inicio.Date == dia.Date)
                .OrderBy(t => t.Inicio).ToList();
        }

        // historial de un paciente. todos los odontólogos y todos los estados, del más reciente al más antiguo
        public List<Turno> ObtenerTurnosDePaciente(int pacienteId)
        {
            return _repoTurnos.ObtenerTodos()
                .Where(t => t.PacienteId == pacienteId)
                .OrderByDescending(t => t.Inicio)
                .ToList();
        }

        // texto para mostrar en la agenda, por ej. "Limpieza, Extracción"
        public string ObtenerTextoTratamientos(Turno turno)
        {
            List<string> nombres = _servicioTratamientos.ObtenerPorIds(turno.TratamientosIds)
                .Select(t => t.Nombre)
                .ToList();

            return string.Join(", ", nombres);
        }

        private Turno ObtenerTurnoExistente(int turnoId)
        {
            Turno turno = _repoTurnos.ObtenerPorId(turnoId);

            if (turno == null)
            {
                throw new InvalidOperationException("No existe el turno buscado.");
            }

            return turno;
        }

        private void ValidarTurno(Turno turno, int idAExcluir)
        {
            if (_servicioPacientes.ObtenerPorId(turno.PacienteId) == null)
            {
                throw new InvalidOperationException("El paciente no existe.");
            }
            if (turno.OdontologoId <= 0)
            {
                throw new InvalidOperationException("El turno no tiene un odontólogo asignado.");
            }
            if (turno.DuracionMinutos < Turno.DuracionMinima)
            {
                throw new InvalidOperationException($"La duración del turno es muy corta (al menos {Turno.DuracionMinima} minutos).");
            }
            if (turno.Inicio < DateTime.Now)
            {
                throw new InvalidOperationException("No se puede agendar un turno en el pasado.");
            }
            if (turno.Inicio.TimeOfDay < HoraApertura || turno.Fin.TimeOfDay > HoraCierre
                || turno.Fin.Date != turno.Inicio.Date)
            {
                throw new InvalidOperationException("Horario fuera del rango permitido.");
            }
            if (turno.TratamientosIds.Count == 0)
            {
                throw new InvalidOperationException("El turno debe incluir al menos un tratamiento.");
            }

            List<Tratamiento> tratamientos = _servicioTratamientos.ObtenerPorIds(turno.TratamientosIds);

            if (tratamientos.Count != turno.TratamientosIds.Distinct().Count()) //que ninguno NO exista
            {
                throw new InvalidOperationException("Alguno de los tratamientos elegidos no existe.");
            }
            if (tratamientos.Any(t => t.OdontologoId != turno.OdontologoId)) //que todos tengan OdontologoId igual al del turno
            {
                throw new InvalidOperationException("Alguno de los tratamientos no pertenece a este odontólogo.");
            }

            // hay algún turno que ocupe horario (no cancelado ni reprogramado), no sea el que estoy reprogramando, y se pise con el nuevo
            if (_repoTurnos.ObtenerTodos().Any(t => t.OcupaHorario
                && t.Id != idAExcluir && t.SeSuperponeCon(turno)))
            {
                throw new InvalidOperationException("El turno se superpone con un turno ya agendado.");
            }
        }
    }
}