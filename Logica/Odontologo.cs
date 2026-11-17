using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public class Odontologo : Usuario
    {
        public List<Tratamiento> Tratamientos { get; set; }

        [JsonIgnore]
        public override string Rol
        {
            get { return "Odontólogo"; }
        }

        public static void RealizarTratamiento(Paciente paciente, Tratamiento tratamiento)
        {
            // Registrar que el odontólogo realizó el tratamiento al paciente
        }
    }
}