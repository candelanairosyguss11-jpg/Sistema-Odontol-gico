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

        public void MostrarInformacion()
        {
            Console.WriteLine("Documento: " + Nombre);
            Console.WriteLine("Tipo: " + Tipo);
        }

    }
}
