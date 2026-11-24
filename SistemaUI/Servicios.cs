using Sistema_Odontológico;

namespace SistemaUI
{
    public static class Servicios
    {
        private static readonly ContenedorServicios _contenedor = new ContenedorServicios();

        public static ServicioUsuarios Usuarios => _contenedor.Usuarios; //=> reemplazo de {get {return ...} }
        public static ServicioPacientes Pacientes => _contenedor.Pacientes;
        public static ServicioTratamientos Tratamientos => _contenedor.Tratamientos;
        public static ServicioTurnos Turnos => _contenedor.Turnos;
        public static ServicioHistorias Historias => _contenedor.Historias;
    }

    public static class Sesion
    {
        public static Usuario Actual { get; set; }

        public static bool EsOdontologo => Actual is Odontologo;
        public static bool EsSecretario => Actual is Secretario;

        public static Odontologo OdontologoActual => Actual as Odontologo;
        public static Secretario SecretarioActual => Actual as Secretario;

        public static void Cerrar()
        {
            Actual = null;
        }
    }
}