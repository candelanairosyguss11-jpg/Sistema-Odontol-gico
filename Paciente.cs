using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public class Paciente
    {
        public int Edad { get; set; }
        public string ObraSocial { get; set; }
        public string CorreoElect { get; set; }

        
        public void SolicitarTurno()
        {
            // Solicitar un turno
        }

        public void CancelarTurno(Turno turno)
        {
            // Cancelar turno
        }

        public void ReprogramarTurno(Turno turno)
        {
            // Reprogramar turno
        }


    }
}
