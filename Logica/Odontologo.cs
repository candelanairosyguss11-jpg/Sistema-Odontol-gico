using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public class Odontologo : Usuario
    {
        [JsonIgnore]
        public override string Rol
        {
            get { return "Odontólogo"; }
        }
    }
}