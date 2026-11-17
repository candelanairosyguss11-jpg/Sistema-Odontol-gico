using System;
using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public abstract class Documento
    {
        public string NombreOriginal { get; set; } = string.Empty; // lo que se muestra
        public string RutaRelativa { get; set; } = string.Empty;   // dentro de Rutas.CarpetaArchivos
        public DateTime FechaCarga { get; set; } = DateTime.Now;
        public int SubidoPorOdontologoId { get; set; }
        public string Comentario { get; set; } = string.Empty;
    }
}