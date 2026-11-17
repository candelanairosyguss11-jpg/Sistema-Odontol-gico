using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Sistema_Odontológico
{
    public static class ServicioArchivos
    {
        private static readonly string[] ExtensionesPermitidas = { ".jpg", ".jpeg", ".png", ".pdf" };
        private const long TamanoMaximoBytes = 10 * 1024 * 1024; // 10 MB

        // copia el archivo a la carpeta de la app con un nombre único y devuelve la ruta relativa
        public static string Guardar(string rutaOrigen, int pacienteId)
        {
            if (!File.Exists(rutaOrigen))
            {
                throw new FileNotFoundException("No se encontró el archivo seleccionado.");
            }

            string extension = Path.GetExtension(rutaOrigen).ToLowerInvariant();
            if (!ExtensionesPermitidas.Contains(extension))
            {
                throw new ArgumentException("Solo se permiten archivos JPG, PNG o PDF.");
            }

            if (new FileInfo(rutaOrigen).Length > TamanoMaximoBytes)
            {
                throw new ArgumentException("El archivo supera el máximo de 10 MB.");
            }

            string carpetaPaciente = pacienteId.ToString(); //convierte el Id en texto para ponerle de nombre a la carpeta
            string carpetaDestino = Path.Combine(Rutas.CarpetaArchivos, carpetaPaciente); //arma la ruta a la carpeta
            Directory.CreateDirectory(carpetaDestino); //crea la carpeta si no existe

            string nombreNuevo = Guid.NewGuid().ToString("N") + extension; //genera un identificador único aleatorio, lo escribe como 32 caracteres sin guiones, y se le suma la extensión original
            File.Copy(rutaOrigen, Path.Combine(carpetaDestino, nombreNuevo)); //copia el archivo original que se subio en la carpeta nueva

            return Path.Combine(carpetaPaciente, nombreNuevo);
        }

        public static void Abrir(string rutaRelativa)
        {
            string rutaCompleta = Path.Combine(Rutas.CarpetaArchivos, rutaRelativa);
            if (!File.Exists(rutaCompleta))
            {
                throw new FileNotFoundException("El archivo ya no existe en el sistema.");
            }
            Process.Start(new ProcessStartInfo(rutaCompleta) { UseShellExecute = true }); //Windows decide con qué abrir según la extensión
        }

        public static void AbrirEnlace(string enlace)
        {
            if (!Validador.EsEnlaceValido(enlace))
            {
                throw new ArgumentException("El enlace no es válido.");
            }
            Process.Start(new ProcessStartInfo(enlace) { UseShellExecute = true });
        }
    }
}