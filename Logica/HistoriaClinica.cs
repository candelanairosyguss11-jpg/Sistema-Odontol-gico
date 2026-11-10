using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Sistema_Odontológico
{
    public class HistoriaClinica
    {
        public Paciente Paciente { get; set; }
       
        public List<Tratamiento> TratamientosRealizados { get; set; } = new List<Tratamiento>();
        public List<string> Alergias { get; set; } = new List<string>();
        public List<Documento> Estudios { get; set; } = new List<Documento>();
        public List<string> Fotos { get; set; } = new List<string>();
        public string Odontograma { get; set; }
        public List<Documento> ConsentimientosInformados { get; set; } = new List<Documento>();


        public void AgregarTratamiento(Tratamiento tratamiento)
        {
            TratamientosRealizados.Add(tratamiento);
        }

        public void AgregarAlergia(string alergia)
        {
            Alergias.Add(alergia);
        }

        public void AgregarEstudio(Documento estudio) // Cambia "Documento" por el tipo de tu lista
        {
            Estudios.Add(estudio);
        }

        public void ActualizarOdontograma(string odontograma)
        {
            Odontograma = odontograma;
        }

        // Método corregido (agregado void y removido static)
        public void AgregarConsentimiento(Documento consentimiento)
        {
            ConsentimientosInformados.Add(consentimiento);
        }
    }
}
