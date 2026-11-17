using System;
using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public enum TipoEstudio { Radiografia, Fotografia, Tomografia, Otro }
    public class Estudio : Documento
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoEstudio Tipo { get; set; }

        public string Enlace { get; set; } = string.Empty; // para tomografías

        [JsonIgnore]
        public bool EsEnlace
        {
            get { return !string.IsNullOrWhiteSpace(Enlace); }
        }
    }
}
