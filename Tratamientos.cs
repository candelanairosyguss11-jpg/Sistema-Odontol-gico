using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public class Tratamientos
    {
        public string Descripcion { get; set; }
        
        public void MostrarInformacion()
        {
            Console.WriteLine("Tratamiento: " + Descripcion);
        }
        public void ActualizarDescripcion()
        {
            // modificar descripción
        }

    }
}
