using System;
using System.Collections.Generic;

namespace Sistema_Odontológico
{
    public class HistoriaClinica : IEntidad
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string Alergias { get; set; } = string.Empty;
        public string Antecedentes { get; set; } = string.Empty;
        public string Medicacion { get; set; } = string.Empty;
        public string MotivoConsultaInicial { get; set; } = string.Empty; // motivo por el que el paciente vino la primera vez. opcional.

        // quién y cuándo modificó los datos por última vez
        public int? UltimaModificacionPorId { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

        public List<Observacion> Observaciones { get; set; } = new List<Observacion>();
        public List<Estudio> Estudios { get; set; } = new List<Estudio>();
        public List<Consentimiento> Consentimientos { get; set; } = new List<Consentimiento>();

        public void RegistrarModificacion(int odontologoId)
        {
            UltimaModificacionPorId = odontologoId;
            FechaUltimaModificacion = DateTime.Now;
        }
    }
}