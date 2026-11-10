using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public class Documento
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        
        public static void Abrir()
        {
            // Abrir documento
        }

        public string MostarInformacion()
        {
            return $"Documento: {Nombre}\nTipo: {Tipo}";
        }

    }
}
