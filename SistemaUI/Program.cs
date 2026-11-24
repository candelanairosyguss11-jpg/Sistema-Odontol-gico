using Sistema_Odontológico;

namespace SistemaUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            InicializarDatosPorDefecto();
            Application.Run(new FormLogin());
        }

        private static void InicializarDatosPorDefecto()
        {
            if (Servicios.Usuarios.ObtenerOdontologos().Count == 0)
            {
                var odontologo = new Odontologo
                {
                    Nombre = "Ana",
                    Apellido = "Martínez",
                    DNI = "11111111",
                    Correo = "ana.martinez@clinica.com",
                    Telefono = "1122334455"
                };
                odontologo.EstablecerContrasena("Admin1234");
                Servicios.Usuarios.Registrar(odontologo);

                // tratamiento base cargado para que pueda recibir turnos
                Servicios.Tratamientos.Agregar(new Tratamiento
                {
                    OdontologoId = odontologo.Id,
                    Nombre = "Consulta general",
                    DuracionMinutos = 30
                });
            }

            if (Servicios.Usuarios.ObtenerSecretarios().Count == 0)
            {
                var secretario = new Secretario
                {
                    Nombre = "Carlos",
                    Apellido = "Gómez",
                    DNI = "22222222",
                    Correo = "carlos.gomez@clinica.com",
                    Telefono = "1166778899"
                };
                secretario.EstablecerContrasena("Admin1234");
                Servicios.Usuarios.Registrar(secretario);
            }
        }
    }
}