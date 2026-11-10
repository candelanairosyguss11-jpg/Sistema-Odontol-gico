using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public abstract class Secretario : Usuario
    {
        public override string Rol
        {
            get { return "Secretario"; }
        }
    }
}
