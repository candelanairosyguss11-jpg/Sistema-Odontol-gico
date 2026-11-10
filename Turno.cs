using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public class Turno
    {   public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Odontologo Odontologo { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }      //confirmado, sin confirmar, cancelado, reprogramado

        
        public void Confirmar()
        {
            Estado = "Confirmado";
        }

        public void Cancelar()
        {
            Estado = "Cancelado";
        }

        public void Reprogramar(DateTime nuevaFechaHora)
        {
            FechaHora = nuevaFechaHora;
            Estado = "Reprogramado";
        }

    }

}

