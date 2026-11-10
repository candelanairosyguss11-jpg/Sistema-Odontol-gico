using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sistema_Odontológico
{
    public class Tratamiento
    {
        public string Descripcion { get; set; }
        
        public string MostrarInformacion()
        {
            return $"Tratamiento: {Descripcion}";
        }
        public static void ActualizarDescripcion()
        {
            // modificar descripción
        }

    }
}
