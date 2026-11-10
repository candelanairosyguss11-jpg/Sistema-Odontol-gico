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

        
        public static void SolicitarTurno()
        {
            // Solicitar un turno
        }

        public static void CancelarTurno(Turno turno)
        {
            // Cancelar turno
        }

        public static void ReprogramarTurno(Turno turno)
        {
            // Reprogramar turno
        }


    }
}
