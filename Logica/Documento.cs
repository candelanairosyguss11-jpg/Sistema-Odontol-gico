using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public abstract class Documento
    {
        public string NombreArchivo { get; set; }
        public string RutaRelativa { get; set; }
        public DateTime FechaCarga { get; set; } = DateTime.Now;
        public string Comentario { get; set; } = string.Empty;
        
        //public string MostarInformacion()
        //{
        //    return $"Documento: {Nombre}\nTipo: {Tipo}";
        //}
    }
}