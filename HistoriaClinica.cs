using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Sistema_Odontológico
{
    public class HistoriaClinica
    {
        public Paciente Paciente { get; set; }
        public List<string> TratamientosRealizados { get; set; }
        public List<string> Alergias { get; set; }
        public List<string> Estudios { get; set; }
        public List<string> Fotos { get; set; }
        public string Odontograma { get; set; }
        public List<string> ConsentimientosInformados { get; set; }


        //metodos
        public void AgregarTratamiento(Tratamientos tratamientos)
        {
            TratamientosRealizados.Add(tratamientos);
        }

        public void AgregarAlergia(string alergia)
        {
            Alergias.Add(alergia);
        }

        public void AgregarEstudio(Documento estudio)
        {
            Estudios.Add(estudio);
        }

        public void ActualizarOdontograma(string odontograma)
        {
            Odontograma = odontograma;
        }

        public void AgregarConsentimiento(Documento consentimiento)
        {
            ConsentimientosInformados.Add(consentimiento);
        }

    }
}
