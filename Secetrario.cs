using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public abstract class Secetrario : Usuario
    {
        public override string Rol
        {
            get { return "Secretario"; }
        }
    }
}
