using System;
using System.Security.Cryptography;

namespace Sistema_Odontológico
{
    public static class ServicioContrasenas
    {
        private const int TamanoSal = 16; // bytes
        private const int TamanoHash = 32; // bytes
        private const int Iteraciones = 600_000;
        private static readonly HashAlgorithmName Algoritmo = HashAlgorithmName.SHA256;

        // recibe la contraseña en texto y devuelve el hash y la sal (ambos en Base64)
        public static (string Hash, string Sal) Hashear(string contrasena)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(TamanoSal);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                contrasena, sal, Iteraciones, Algoritmo, TamanoHash);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(sal)); //lo convierte en un string seguro pq no se puede guardar como texto en un JSON si son bytes
        }

        // comprueba si la contraseña escrita coincide con el hash y la sal guardados
        public static bool Verificar(string contrasena, string hashGuardado, string salGuardada)
        {
            if (string.IsNullOrEmpty(contrasena) ||
                string.IsNullOrEmpty(hashGuardado) ||
                string.IsNullOrEmpty(salGuardada))
                return false;

            try
            {
                byte[] sal = Convert.FromBase64String(salGuardada);
                byte[] esperado = Convert.FromBase64String(hashGuardado);

                byte[] calculado = Rfc2898DeriveBytes.Pbkdf2(
                    contrasena, sal, Iteraciones, Algoritmo, esperado.Length);

                return CryptographicOperations.FixedTimeEquals(calculado, esperado); //compara los dos arreglos de bytes en tiempo constante para q no se detenga en la primera diferencia?
            }
            catch (FormatException)
            {
                return false; // el JSON tenía un hash o sal dañados
            }
        }
    }
}