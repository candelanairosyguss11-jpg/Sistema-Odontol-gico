using System;
using System.IO;

namespace Sistema_Odontológico
{
    public static class Rutas
    {
        public static string CarpetaBase =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "SistemaOdontologico");

        public static string CarpetaDatos => Path.Combine(CarpetaBase, "Datos");
        public static string CarpetaArchivos => Path.Combine(CarpetaBase, "Archivos");
    }
}