using System;
using System.Collections.Generic;
using System.Text;

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
        public string MotivoConsultaInicial { get; set; } = string.Empty;

        public List<Observacion> Observaciones { get; set; } = new List<Observacion>();
        public List<Estudio> Estudios { get; set; } = new List<Estudio>();
        public List<Consentimiento> Consentimientos { get; set; } = new List<Consentimiento>();

        //public Paciente Paciente { get; set; }

        //public List<Tratamiento> TratamientosRealizados { get; set; } = new List<Tratamiento>();
        //public List<string> Alergias { get; set; } = new List<string>();
        //public List<Documento> Estudios { get; set; } = new List<Documento>();
        //public List<string> Fotos { get; set; } = new List<string>();
        ////public string Odontograma { get; set; }
        //public List<Documento> ConsentimientosInformados { get; set; } = new List<Documento>();


        //public void AgregarTratamiento(Tratamiento tratamiento)
        //{
        //    TratamientosRealizados.Add(tratamiento);
        //}

        //public void AgregarAlergia(string alergia)
        //{
        //    Alergias.Add(alergia);
        //}

        //public void AgregarEstudio(Documento estudio) // Cambia "Documento" por el tipo de tu lista
        //{
        //    Estudios.Add(estudio);
        //}

        //public void ActualizarOdontograma(string odontograma)
        //{
        //    Odontograma = odontograma;
        //}

        //// Método corregido (agregado void y removido static)
        //public void AgregarConsentimiento(Documento consentimiento)
        //{
        //    ConsentimientosInformados.Add(consentimiento);
        //}
    }
}