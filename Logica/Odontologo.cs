using System.Reflection.Metadata.Ecma335;

namespace Sistema_Odontológico
{
    public abstract class Odontologo : Usuario
    {
        public List<Tratamiento> Tratamientos { get; set; }

        public override string Rol
        {
            get { return "Odontólogo"; }
        }

        public static void RealizarTratamiento(Paciente paciente, Tratamiento tratamiento)
        {
            // Registrar que el odontólogo realizó el tratamiento al paciente
        }

        public static void RegistrarTurno(Turno turno)
        {
            // Registrar turno
        }

        public static void ModificarTurno(Turno turno)
        {
            // Modificar turno
        }

        public static void ConsultarTurnos()
        {
            // Consultar agenda
        }

        public static void RegistrarHistoriaClinica(HistoriaClinica historia)
        {
            // Registrar historia clínica
        }

        public static void ModificarHistoriaClinica(HistoriaClinica historia)
        {
            // Modificar historia clínica
        }

        public static void ConsultarHistoriaClinica(HistoriaClinica historia)
        {
            // Consultar historia clínica
        }


    }
}
