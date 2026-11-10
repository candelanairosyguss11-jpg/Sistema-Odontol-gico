using System.Linq;
using System.Text.RegularExpressions;

namespace Sistema_Odontológico
{
    public static class Validador
    {
        public static bool EsCorreoValido(string correo) =>
            !string.IsNullOrWhiteSpace(correo) &&
            Regex.IsMatch(correo.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"); //[^@\s]+ es uno o más caracteres que no sean @ ni espacio

        public static bool EsDniValido(string dni) =>
            !string.IsNullOrWhiteSpace(dni) &&
            dni.All(char.IsDigit) &&
            dni.Length is >= 7 and <= 8;
        public static string NormalizarDni(string dni) =>
            dni?.Replace(".", "").Replace(" ", "").Trim(); //saca los puntos y espacios

        public static bool EsTelefonoValido(string telefono) =>
            !string.IsNullOrWhiteSpace(telefono) &&
            Regex.IsMatch(telefono.Trim(), @"^\+?[\d\s\-]{6,15}$");
    }
}