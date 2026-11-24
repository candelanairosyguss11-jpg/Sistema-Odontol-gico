using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sistema_Odontológico
{
    public class ServicioHistorias
    {
        private readonly IRepositorio<HistoriaClinica> _repoHistorias;
        private readonly ServicioPacientes _servicioPacientes;
        private readonly ServicioTratamientos _servicioTratamientos;

        public ServicioHistorias(IRepositorio<HistoriaClinica> repoHistorias,
                                 ServicioPacientes servicioPacientes,
                                 ServicioTratamientos servicioTratamientos)
        {
            _repoHistorias = repoHistorias;
            _servicioPacientes = servicioPacientes;
            _servicioTratamientos = servicioTratamientos;
        }

        public void Crear(HistoriaClinica historia, Odontologo autor)
        {
            if (_servicioPacientes.ObtenerPorId(historia.PacienteId) == null)
            {
                throw new InvalidOperationException("El paciente no existe.");
            }

            if (ObtenerPorPaciente(historia.PacienteId) != null)
            {
                throw new InvalidOperationException("Este paciente ya tiene historia clínica.");
            }

            historia.RegistrarModificacion(autor.Id);
            _repoHistorias.Agregar(historia);
        }

        public void ActualizarDatos(HistoriaClinica historia, Odontologo autor) //para cuando se editan los datos generales
        {
            ObtenerHistoriaExistente(historia.Id);
            historia.RegistrarModificacion(autor.Id);
            _repoHistorias.Actualizar(historia);
        }

        public HistoriaClinica ObtenerPorId(int id)
        {
            return _repoHistorias.ObtenerPorId(id); //el procedimiento real está en RepositorioJson
        }

        public HistoriaClinica ObtenerPorPaciente(int pacienteId)
        {
            return _repoHistorias.ObtenerTodos().FirstOrDefault(h => h.PacienteId == pacienteId); //null si el paciente no tiene historia
        }

        public List<HistoriaClinica> BuscarPorNombrePaciente(string texto)
        {
            List<Paciente> pacientes = _servicioPacientes.BuscarPorNombre(texto);
            return pacientes.Select(p => ObtenerPorPaciente(p.Id)).Where(h => h != null).ToList();
        }

        public void AgregarObservacion(int historiaId, Odontologo autor, string texto, int? turnoId)
        {
            HistoriaClinica historia = ObtenerHistoriaExistente(historiaId);

            Observacion observacion = new Observacion();
            observacion.OdontologoId = autor.Id;
            observacion.TurnoId = turnoId;
            observacion.Texto = texto; //si está vacío, el set lanza ArgumentException

            historia.Observaciones.Add(observacion);
            _repoHistorias.Actualizar(historia);
        }

        public void AgregarEstudioArchivo(int historiaId, Odontologo autor, string rutaOrigen, TipoEstudio tipo, string comentario)
        {
            HistoriaClinica historia = ObtenerHistoriaExistente(historiaId);

            //copia el archivo y devuelve la ruta relativa. Si el archivo no sirve, lanza su excepción antes de tocar la historia
            string rutaRelativa = ServicioArchivos.Guardar(rutaOrigen, historia.PacienteId);

            Estudio estudio = new Estudio();
            estudio.NombreOriginal = Path.GetFileName(rutaOrigen);
            estudio.RutaRelativa = rutaRelativa;
            estudio.Tipo = tipo;
            estudio.Comentario = comentario;
            estudio.SubidoPorOdontologoId = autor.Id;

            historia.Estudios.Add(estudio);
            _repoHistorias.Actualizar(historia);
        }

        public void AgregarEstudioEnlace(int historiaId, Odontologo autor, string enlace, string comentario)
        {
            HistoriaClinica historia = ObtenerHistoriaExistente(historiaId);

            if (!Validador.EsEnlaceValido(enlace))
            {
                throw new ArgumentException("El enlace ingresado no es válido.");
            }

            Estudio estudio = new Estudio();
            estudio.Tipo = TipoEstudio.Tomografia;
            estudio.Enlace = enlace;
            estudio.NombreOriginal = "Tomografía (enlace)";
            estudio.Comentario = comentario;
            estudio.SubidoPorOdontologoId = autor.Id;

            historia.Estudios.Add(estudio);
            _repoHistorias.Actualizar(historia);
        }

        public void AgregarConsentimiento(int historiaId, Odontologo autor, string rutaOrigen, int tratamientoId, string comentario)
        {
            HistoriaClinica historia = ObtenerHistoriaExistente(historiaId);

            if (_servicioTratamientos.ObtenerPorId(tratamientoId) == null)
            {
                throw new InvalidOperationException("El tratamiento no existe.");
            }

            string rutaRelativa = ServicioArchivos.Guardar(rutaOrigen, historia.PacienteId);

            Consentimiento consentimiento = new Consentimiento();
            consentimiento.TratamientoId = tratamientoId;
            consentimiento.NombreOriginal = Path.GetFileName(rutaOrigen);
            consentimiento.RutaRelativa = rutaRelativa;
            consentimiento.Comentario = comentario;
            consentimiento.SubidoPorOdontologoId = autor.Id;

            historia.Consentimientos.Add(consentimiento);
            _repoHistorias.Actualizar(historia);
        }

        private HistoriaClinica ObtenerHistoriaExistente(int historiaId)
        {
            HistoriaClinica historiaClinica = _repoHistorias.ObtenerPorId(historiaId);

            if (historiaClinica == null)
            {
                throw new InvalidOperationException("No existe la historia clínica.");
            }

            return historiaClinica;
        }
    }
}