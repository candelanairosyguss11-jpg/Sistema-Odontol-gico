using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public class Observacion
    {
        public DateTime Fecha = DateTime.Now;
        public int OdontologoId { get; set; }
        public string Texto { get; set; } = string.Empty; //poner lo de .Empty o no?
    }
}
