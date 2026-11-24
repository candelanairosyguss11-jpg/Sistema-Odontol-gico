using Sistema_Odontológico;

namespace Sistema_Odontológico;
public class ContenedorServicios
{
    public ServicioUsuarios Usuarios { get; }
    public ServicioPacientes Pacientes { get; }
    public ServicioTratamientos Tratamientos { get; }
    public ServicioTurnos Turnos { get; }
    public ServicioHistorias Historias { get; }

    public ContenedorServicios()
    {
        Usuarios = new ServicioUsuarios(
            new RepositorioJson<Odontologo>("odontologos.json"),
            new RepositorioJson<Secretario>("secretarios.json"));
        Pacientes = new ServicioPacientes(new RepositorioJson<Paciente>("pacientes.json"));
        Tratamientos = new ServicioTratamientos(new RepositorioJson<Tratamiento>("tratamientos.json"));
        Turnos = new ServicioTurnos(new RepositorioJson<Turno>("turnos.json"), Pacientes, Tratamientos);
        Historias = new ServicioHistorias(new RepositorioJson<HistoriaClinica>("historias.json"), Pacientes, Tratamientos);
    }
}