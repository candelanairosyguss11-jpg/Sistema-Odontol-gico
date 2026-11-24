using Sistema_Odontológico;
using System;
using System.Collections.Generic;
using System.Text;


namespace SistemaUI
{
    public static class Servicios
    {
        public static ServicioUsuarios Usuarios { get; }
        public static ServicioPacientes Pacientes { get; }
        public static ServicioTratamientos Tratamientos { get; }
        public static ServicioTurnos Turnos { get; }
        public static ServicioHistorias Historias { get; }

        static Servicios()
        {
            Usuarios = new ServicioUsuarios(
                new RepositorioJson<Odontologo>("odontologos.json"),
                new RepositorioJson<Secretario>("secretarios.json"));
            Pacientes = new ServicioPacientes(new RepositorioJson<Paciente>("pacientes.json"));
            Tratamientos = new ServicioTratamientos(new RepositorioJson<Tratamiento>("tratamientos.json"));
            Turnos = new ServicioTurnos(new RepositorioJson<Turno>("turnos.json"), Pacientes, Tratamientos);
            Historias = new ServicioHistorias(new RepositorioJson<HistoriaClinica>("historias.json"));
        }
    }

    public static class Sesion
    {
        public static Usuario Actual { get; set; }
    }
}