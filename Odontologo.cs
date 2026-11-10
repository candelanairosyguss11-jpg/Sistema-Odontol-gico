using System.Reflection.Metadata.Ecma335;

namespace Sistema_Odontológico
{
    public abstract class Odontologo : Usuario
    {
        public List<Tratamientos> Tratamientos { get; set; }



        public void RealizarTratamiento(Paciente paciente, Tratamientos tratamiento)
        {
            // Registrar que el odontólogo realizó el tratamiento al paciente
        }

        public void RegistrarTurno(Turno turno)
        {
            // Registrar turno
        }

        public void ModificarTurno(Turno turno)
        {
            // Modificar turno
        }

        public void ConsultarTurnos()
        {
            // Consultar agenda
        }

        public void RegistrarHistoriaClinica(HistoriaClinica historia)
        {
            // Registrar historia clínica
        }

        public void ModificarHistoriaClinica(HistoriaClinica historia)
        {
            // Modificar historia clínica
        }

        public void ConsultarHistoriaClinica(HistoriaClinica historia)
        {
            // Consultar historia clínica
        }


    }
}
