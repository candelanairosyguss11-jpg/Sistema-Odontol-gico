using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public class Tratamiento
    {
        public string Descripcion { get; set; }
        
        public void MostrarInformacion()
        {
            Console.WriteLine("Tratamiento: " + Descripcion);
        }
        public static void ActualizarDescripcion()
        {
            // modificar descripción
        }

    }
}
