using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sistema_Odontológico
{
    public class Secretario : Usuario
    {
        [JsonIgnore]
        public override string Rol
        {
            get { return "Secretario"; }
        }
    }
}