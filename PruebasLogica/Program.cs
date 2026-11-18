using Sistema_Odontológico;
using System.Text;

internal static class Program
{
    static StringBuilder _informe = new StringBuilder();

    static void Main()
    {
        Console.WriteLine("Ejecutando pruebas, puede tardar unos segundos...\n");
        PruebasTemporales();
        Console.WriteLine("\nPresioná una tecla para salir...");
        Console.ReadKey();
    }

    static void Caso(string nombre, Func<bool> prueba)
    {
        try
        {
            _informe.AppendLine((prueba() ? "OK      " : "FALLÓ   ") + nombre);
        }
        catch (Exception ex)
        {
            _informe.AppendLine("ERROR   " + nombre + " -> " + ex.Message);
        }
    }

    // true si la acción lanza una excepción del tipo T
    static bool Lanza<T>(Action accion) where T : Exception
    {
        try { accion(); return false; }
        catch (T) { return true; }
    }

    static Odontologo NuevoOdontologo(string dni)
    {
        var o = new Odontologo();
        o.Nombre = "Ana"; o.Apellido = "Pérez"; o.DNI = dni;
        o.Correo = "ana@mail.com"; o.Telefono = "1112345678";
        o.EstablecerContrasena("Clave1234");
        return o;
    }

    static Secretario NuevoSecretario(string dni)
    {
        var s = new Secretario();
        s.Nombre = "Sofía"; s.Apellido = "Ruiz"; s.DNI = dni;
        s.Correo = "sofia@mail.com"; s.Telefono = "1198765432";
        s.EstablecerContrasena("Clave1234");
        return s;
    }

    static Turno NuevoTurno(int odontologoId, DateTime inicio, int minutos)
    {
        var t = new Turno();
        t.PacienteId = 1; t.OdontologoId = odontologoId;
        t.Inicio = inicio; t.DuracionMinutos = minutos;
        return t;
    }

    static Paciente NuevoPaciente(string dni, string nombre, string apellido)
    {
        var p = new Paciente();
        p.Nombre = nombre; p.Apellido = apellido; p.DNI = dni;
        p.Correo = "paciente@mail.com"; p.Telefono = "1122334455";
        p.FechaNacimiento = DateOnly.FromDateTime(DateTime.Today).AddYears(-30);
        return p;
    }

    static Tratamiento NuevoTratamiento(int odontologoId, string nombre)
    {
        var t = new Tratamiento();
        t.OdontologoId = odontologoId; t.Nombre = nombre; t.DuracionMinutos = 30;
        return t;
    }

    static void LimpiarDatos()
    {
        if (Directory.Exists(Rutas.CarpetaDatos)) Directory.Delete(Rutas.CarpetaDatos, true);
        string carpetaPrueba = Path.Combine(Rutas.CarpetaArchivos, "99");
        if (Directory.Exists(carpetaPrueba)) Directory.Delete(carpetaPrueba, true);
    }

    static void PruebasTemporales()
    {
        LimpiarDatos();

        var repoO = new RepositorioJson<Odontologo>("odontologos.json");
        var repoS = new RepositorioJson<Secretario>("secretarios.json");
        var servicio = new ServicioUsuarios(repoO, repoS);
        string rutaOdontologos = Path.Combine(Rutas.CarpetaDatos, "odontologos.json");

        // ---------- USUARIOS ----------
        _informe.AppendLine("--- USUARIOS ---");
        Caso("Registrar odontólogo", () => { servicio.Registrar(NuevoOdontologo("12345678")); return repoO.ObtenerTodos().Count == 1; });
        Caso("DNI repetido (odontólogo, con puntos) falla", () => Lanza<InvalidOperationException>(() => servicio.Registrar(NuevoOdontologo("12.345.678"))));
        Caso("DNI repetido en secretario falla", () => Lanza<InvalidOperationException>(() => servicio.Registrar(NuevoSecretario("12345678"))));
        Caso("Registrar secretario con otro DNI", () => { servicio.Registrar(NuevoSecretario("87654321")); return repoS.ObtenerTodos().Count == 1; });

        Caso("Registrar sin contraseña falla", () => Lanza<InvalidOperationException>(() =>
        {
            var o = new Odontologo();
            o.Nombre = "Sin"; o.Apellido = "Clave"; o.DNI = "11111111";
            o.Correo = "s@mail.com"; o.Telefono = "1112345678";
            servicio.Registrar(o);
        }));

        Caso("Registrar sin nombre falla", () => Lanza<InvalidOperationException>(() =>
        {
            var o = new Odontologo();
            o.Apellido = "SinNombre"; o.DNI = "22222222";
            o.Correo = "s@mail.com"; o.Telefono = "1112345678";
            o.EstablecerContrasena("Clave1234");
            servicio.Registrar(o);
        }));

        Caso("Login correcto", () => servicio.IniciarSesionOdontologo("12345678", "Clave1234") != null);
        Caso("Login con clave incorrecta -> null", () => servicio.IniciarSesionOdontologo("12345678", "otraClave1") == null);
        Caso("Login con DNI con puntos", () => servicio.IniciarSesionOdontologo("12.345.678", "Clave1234") != null);
        Caso("DNI inexistente -> null", () => servicio.IniciarSesionOdontologo("99999999", "Clave1234") == null);
        Caso("Secretario por login de odontólogo -> null", () => servicio.IniciarSesionOdontologo("87654321", "Clave1234") == null);
        Caso("Login de secretario correcto", () => servicio.IniciarSesionSecretario("87654321", "Clave1234") != null);

        Caso("Secretario inactivo no puede entrar", () =>
        {
            var s = servicio.IniciarSesionSecretario("87654321", "Clave1234");
            s.Activo = false; repoS.Actualizar(s);
            bool resultado = servicio.IniciarSesionSecretario("87654321", "Clave1234") == null;
            s.Activo = true; repoS.Actualizar(s);
            return resultado;
        });

        Caso("Cambiar contraseña (la vieja ya no entra, la nueva sí)", () =>
        {
            var u = servicio.IniciarSesionOdontologo("12345678", "Clave1234");
            servicio.CambiarContrasena(u, "Clave1234", "NuevaClave99");
            return servicio.IniciarSesionOdontologo("12345678", "Clave1234") == null
                && servicio.IniciarSesionOdontologo("12345678", "NuevaClave99") != null;
        });

        Caso("Cambiar contraseña con la actual incorrecta falla", () =>
        {
            var u = servicio.IniciarSesionOdontologo("12345678", "NuevaClave99");
            return Lanza<ArgumentException>(() => servicio.CambiarContrasena(u, "incorrecta1A", "OtraClave77"));
        });

        Caso("Los datos persisten al reabrir (repositorios nuevos)", () =>
        {
            var servicio2 = new ServicioUsuarios(
                new RepositorioJson<Odontologo>("odontologos.json"),
                new RepositorioJson<Secretario>("secretarios.json"));
            return servicio2.IniciarSesionOdontologo("12345678", "NuevaClave99") != null;
        });

        Caso("Misma contraseña, hashes distintos (sal)", () =>
            NuevoOdontologo("33333333").HashContrasena != NuevoOdontologo("44444444").HashContrasena);

        Caso("El JSON no guarda contraseñas ni datos calculados", () =>
        {
            string json = File.ReadAllText(rutaOdontologos);
            return !json.Contains("Clave1234") && !json.Contains("NuevaClave99")
                && json.Contains("HashContrasena")
                && !json.Contains("\"Rol\"") && !json.Contains("NombreCompleto");
        });

        Caso("Correo inválido lanza ArgumentException", () => Lanza<ArgumentException>(() => new Odontologo().Correo = "mal"));
        Caso("Contraseña débil lanza ArgumentException", () => Lanza<ArgumentException>(() => new Odontologo().EstablecerContrasena("abc")));

        // ---------- TURNOS ----------
        _informe.AppendLine("--- TURNOS ---");
        var repoT = new RepositorioJson<Turno>("turnos.json");
        DateTime manana10 = DateTime.Today.AddDays(1).AddHours(10);

        Caso("Guardar y releer turno (estado como texto)", () =>
        {
            var t = NuevoTurno(1, manana10, 30);
            t.TratamientosIds.Add(1);
            t.Cancelar();
            repoT.Agregar(t);

            var leidos = new RepositorioJson<Turno>("turnos.json").ObtenerTodos();
            string json = File.ReadAllText(Path.Combine(Rutas.CarpetaDatos, "turnos.json"));
            return leidos.Count == 1
                && leidos[0].Estado == EstadoTurno.Cancelado
                && leidos[0].TratamientosIds.Count == 1
                && leidos[0].Inicio == manana10
                && json.Contains("\"Cancelado\"");
        });

        Caso("Duración de 10 minutos falla", () => Lanza<ArgumentException>(() => NuevoTurno(1, manana10, 10)));
        Caso("Duración de 241 minutos falla", () => Lanza<ArgumentException>(() => NuevoTurno(1, manana10, 241)));

        var a = NuevoTurno(1, manana10, 30);                  // 10:00 a 10:30
        var b = NuevoTurno(1, manana10.AddMinutes(15), 30);   // 10:15 a 10:45
        var c = NuevoTurno(1, manana10.AddMinutes(30), 30);   // 10:30 a 11:00
        var d = NuevoTurno(2, manana10, 30);                  // otro odontólogo
        Caso("Superposición: turnos que se pisan", () => a.SeSuperponeCon(b) && b.SeSuperponeCon(a));
        Caso("Superposición: turnos pegados NO se pisan", () => !a.SeSuperponeCon(c) && !c.SeSuperponeCon(a));
        Caso("Superposición: otro odontólogo NO se pisa", () => !a.SeSuperponeCon(d));

        Caso("OcupaHorario: pendiente sí, cancelado no", () =>
        {
            var t = NuevoTurno(1, manana10, 30);
            bool pendiente = t.OcupaHorario;
            t.Cancelar();
            return pendiente && !t.OcupaHorario;
        });

        Caso("Marcar asistencia antes del turno falla", () => Lanza<InvalidOperationException>(() => NuevoTurno(1, manana10, 30).MarcarAsistencia(true)));

        Caso("Marcar asistencia en turno pasado, y no repetible", () =>
        {
            var t = NuevoTurno(1, DateTime.Now.AddHours(-2), 30);
            t.MarcarAsistencia(true);
            return t.Estado == EstadoTurno.Asistio
                && Lanza<InvalidOperationException>(() => t.MarcarAsistencia(false));
        });

        // ---------- PACIENTE ----------
        _informe.AppendLine("--- PACIENTE ---");
        Caso("Guardar y releer paciente (edad calculada, no guardada)", () =>
        {
            var repoP = new RepositorioJson<Paciente>("pacientes.json");
            var p = new Paciente();
            p.Nombre = "Luis"; p.Apellido = "Gómez"; p.DNI = "30111222";
            p.Correo = "luis@mail.com"; p.Telefono = "1122334455";
            p.FechaNacimiento = DateOnly.FromDateTime(DateTime.Today).AddYears(-30);
            p.ObraSocial = "OSDE";
            repoP.Agregar(p);

            var leido = new RepositorioJson<Paciente>("pacientes.json").ObtenerTodos()[0];
            string json = File.ReadAllText(Path.Combine(Rutas.CarpetaDatos, "pacientes.json"));
            return leido.Edad == 30
                && leido.FechaNacimiento == p.FechaNacimiento
                && leido.ObraSocial == "OSDE"
                && !json.Contains("\"Edad\"");
        });
        Caso("Fecha de nacimiento futura falla", () => Lanza<ArgumentException>(() => new Paciente().FechaNacimiento = DateOnly.FromDateTime(DateTime.Today).AddDays(1)));

        // ---------- HISTORIA CLÍNICA ----------
        _informe.AppendLine("--- HISTORIA CLÍNICA ---");
        Caso("Historia con observación, estudio y consentimiento", () =>
        {
            var repoH = new RepositorioJson<HistoriaClinica>("historias.json");
            var h = new HistoriaClinica();
            h.PacienteId = 1; h.Alergias = "Penicilina";
            var obs = new Observacion(); obs.OdontologoId = 1; obs.Texto = "Control";
            h.Observaciones.Add(obs);
            var est = new Estudio(); est.Tipo = TipoEstudio.Tomografia; est.Enlace = "https://ejemplo.com/t"; est.NombreOriginal = "tomo";
            h.Estudios.Add(est);
            var con = new Consentimiento(); con.TratamientoId = 1; con.NombreOriginal = "c.pdf";
            h.Consentimientos.Add(con);
            h.RegistrarModificacion(1);
            repoH.Agregar(h);

            var leida = new RepositorioJson<HistoriaClinica>("historias.json").ObtenerTodos()[0];
            string json = File.ReadAllText(Path.Combine(Rutas.CarpetaDatos, "historias.json"));
            return leida.Observaciones.Count == 1
                && leida.Estudios[0].Tipo == TipoEstudio.Tomografia
                && leida.Estudios[0].EsEnlace
                && leida.Consentimientos[0].TratamientoId == 1
                && leida.UltimaModificacionPorId == 1
                && json.Contains("\"Tomografia\"");
        });

        // ---------- VALIDADOR ----------
        _informe.AppendLine("--- VALIDADOR ---");
        Caso("DNI", () => Validador.EsDniValido("12345678") && !Validador.EsDniValido("1234") && !Validador.EsDniValido("12a45678") && Validador.NormalizarDni("12.345.678") == "12345678");
        Caso("Correo", () => Validador.EsCorreoValido("a@b.com") && !Validador.EsCorreoValido("a@b") && !Validador.EsCorreoValido("a b@c.com"));
        Caso("Teléfono", () => Validador.EsTelefonoValido("+54 11 1234-5678") && !Validador.EsTelefonoValido("12345") && !Validador.EsTelefonoValido("11-abc-4567"));
        Caso("Contraseña", () => Validador.EsContrasenaValida("Clave1234") && !Validador.EsContrasenaValida("clave1234") && !Validador.EsContrasenaValida("CLAVE1234") && !Validador.EsContrasenaValida("Clave12") && !Validador.EsContrasenaValida("Clavecita"));
        Caso("Enlace", () => Validador.EsEnlaceValido("https://a.com/x") && !Validador.EsEnlaceValido("file:///C:/x") && !Validador.EsEnlaceValido("texto"));
        Caso("Fecha de nacimiento", () =>
        {
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            return Validador.EsFechaNacimientoValida(hoy) && !Validador.EsFechaNacimientoValida(hoy.AddDays(1)) && !Validador.EsFechaNacimientoValida(hoy.AddYears(-121));
        });

        // ---------- ARCHIVOS ----------
        _informe.AppendLine("--- ARCHIVOS ---");
        Caso("Guardar un .jpg (copia con nombre nuevo)", () =>
        {
            string temporal = Path.Combine(Path.GetTempPath(), "prueba.jpg");
            File.WriteAllText(temporal, "x");
            string relativa = ServicioArchivos.Guardar(temporal, 99);
            bool ok = File.Exists(Path.Combine(Rutas.CarpetaArchivos, relativa)) && relativa.EndsWith(".jpg") && !relativa.Contains("prueba");
            File.Delete(temporal);
            return ok;
        });
        Caso("Rechaza un .txt", () =>
        {
            string temporal = Path.Combine(Path.GetTempPath(), "prueba.txt");
            File.WriteAllText(temporal, "x");
            bool ok = Lanza<ArgumentException>(() => ServicioArchivos.Guardar(temporal, 99));
            File.Delete(temporal);
            return ok;
        });
        Caso("Rechaza un archivo que no existe", () => Lanza<FileNotFoundException>(() => ServicioArchivos.Guardar(@"C:\no\existe.jpg", 1)));

        // ---------- SERVICIO PACIENTES ----------
        _informe.AppendLine("--- SERVICIO PACIENTES ---");
        var servP = new ServicioPacientes(new RepositorioJson<Paciente>("pacientes_servicio.json"));

        Caso("Registrar paciente", () => { servP.Registrar(NuevoPaciente("40111222", "Ana", "Pérez")); return servP.ObtenerTodos().Count == 1; });
        Caso("DNI repetido (con puntos) falla", () => Lanza<InvalidOperationException>(() => servP.Registrar(NuevoPaciente("40.111.222", "Otra", "Persona"))));
        Caso("Registrar sin fecha de nacimiento falla", () => Lanza<InvalidOperationException>(() =>
        {
            var p = new Paciente();
            p.Nombre = "Sin"; p.Apellido = "Fecha"; p.DNI = "40999888";
            p.Correo = "s@mail.com"; p.Telefono = "1122334455";
            servP.Registrar(p);
        }));
        Caso("Registrar segundo paciente", () => { servP.Registrar(NuevoPaciente("40333444", "Luis", "Gómez")); return servP.ObtenerTodos().Count == 2; });
        Caso("BuscarPorDni con puntos, e inexistente -> null", () => servP.BuscarPorDni("40.111.222") != null && servP.BuscarPorDni("11111111") == null);
        Caso("BuscarPorNombre: por nombre, por DNI y vacío", () =>
            servP.BuscarPorNombre("ana").Count == 1
            && servP.BuscarPorNombre("333").Count == 1
            && servP.BuscarPorNombre("").Count == 2);
        Caso("Actualizar teléfono (no choca consigo mismo) y persiste", () =>
        {
            var p = servP.BuscarPorDni("40111222");
            p.Telefono = "1199998888";
            servP.Actualizar(p);
            var servP2 = new ServicioPacientes(new RepositorioJson<Paciente>("pacientes_servicio.json"));
            return servP2.BuscarPorDni("40111222").Telefono == "1199998888";
        });
        Caso("Actualizar con el DNI de otro paciente falla", () =>
        {
            var luis = servP.BuscarPorDni("40333444");
            luis.DNI = "40111222";
            bool lanzo = Lanza<InvalidOperationException>(() => servP.Actualizar(luis));
            luis.DNI = "40333444"; // se restaura porque el objeto en memoria quedó modificado
            return lanzo;
        });

        // ---------- SERVICIO TRATAMIENTOS ----------
        _informe.AppendLine("--- SERVICIO TRATAMIENTOS ---");
        var servT = new ServicioTratamientos(new RepositorioJson<Tratamiento>("tratamientos.json"));

        Caso("Agregar tratamiento", () => { servT.Agregar(NuevoTratamiento(1, "Limpieza")); return servT.ObtenerTodosDeOdontologo(1).Count == 1; });
        Caso("Mismo nombre (otras mayúsculas) falla", () => Lanza<InvalidOperationException>(() => servT.Agregar(NuevoTratamiento(1, "limpieza"))));
        Caso("Mismo nombre para otro odontólogo funciona", () => { servT.Agregar(NuevoTratamiento(2, "Limpieza")); return servT.ObtenerTodosDeOdontologo(2).Count == 1; });
        Caso("Sin odontólogo falla", () => Lanza<InvalidOperationException>(() => servT.Agregar(NuevoTratamiento(0, "Conducto"))));
        Caso("Sin nombre falla", () => Lanza<InvalidOperationException>(() =>
        {
            var t = new Tratamiento();
            t.OdontologoId = 1;
            servT.Agregar(t);
        }));
        Caso("Desactivar: no aparece en activos pero sigue existiendo", () =>
        {
            int id = servT.ObtenerTodosDeOdontologo(1).First(t => t.Nombre == "Limpieza").Id;
            servT.Desactivar(id);
            return servT.ObtenerActivosDeOdontologo(1).Count == 0
                && servT.ObtenerTodosDeOdontologo(1).Count == 1
                && servT.ObtenerPorId(id) != null
                && !servT.ObtenerPorId(id).Activo;
        });
        Caso("Reactivar: vuelve a aparecer", () =>
        {
            int id = servT.ObtenerTodosDeOdontologo(1).First(t => t.Nombre == "Limpieza").Id;
            servT.Reactivar(id);
            return servT.ObtenerActivosDeOdontologo(1).Count == 1;
        });
        Caso("Nombre de un tratamiento desactivado avisa que está desactivado", () =>
        {
            var t = servT.ObtenerTodosDeOdontologo(1).First(x => x.Nombre == "Limpieza");
            servT.Desactivar(t.Id);
            string mensaje = "";
            try { servT.Agregar(NuevoTratamiento(1, "Limpieza")); }
            catch (InvalidOperationException ex) { mensaje = ex.Message; }
            servT.Reactivar(t.Id);
            return mensaje.Contains("desactivado");
        });
        Caso("Actualizar duración (no choca consigo mismo)", () =>
        {
            var t = servT.ObtenerTodosDeOdontologo(1).First(x => x.Nombre == "Limpieza");
            t.DuracionMinutos = 45;
            servT.Actualizar(t);
            return servT.ObtenerPorId(t.Id).DuracionMinutos == 45;
        });
        Caso("ObtenerPorIds devuelve los tratamientos pedidos", () =>
        {
            servT.Agregar(NuevoTratamiento(1, "Extracción"));
            var ids = servT.ObtenerTodosDeOdontologo(1).Select(t => t.Id).ToList();
            return servT.ObtenerPorIds(ids).Count == 2;
        });
        Caso("Los tratamientos persisten al reabrir", () =>
        {
            var servT2 = new ServicioTratamientos(new RepositorioJson<Tratamiento>("tratamientos.json"));
            return servT2.ObtenerTodosDeOdontologo(1).Count == 2;
        });

        // ---------- SERVICIO TURNOS ----------
        _informe.AppendLine("--- SERVICIO TURNOS ---");
        var servTurnos = new ServicioTurnos(new RepositorioJson<Turno>("turnos_servicio.json"), servP, servT);

        int pacienteId = servP.BuscarPorDni("40111222").Id;
        int limpieza1 = servT.ObtenerTodosDeOdontologo(1).First(t => t.Nombre == "Limpieza").Id;
        int limpieza2 = servT.ObtenerTodosDeOdontologo(2).First(t => t.Nombre == "Limpieza").Id;
        int extraccion1 = servT.ObtenerTodosDeOdontologo(1).First(t => t.Nombre == "Extracción").Id;

        DateTime dia = DateTime.Today.AddDays(2);
        Func<int, int, DateTime> hora = (h, m) => dia.AddHours(h).AddMinutes(m);

        // arma un turno válido del odontólogo 1 con "Limpieza"
        Func<DateTime, int, Turno> crear = (inicio, minutos) =>
        {
            var t = new Turno();
            t.PacienteId = pacienteId; t.OdontologoId = 1;
            t.Inicio = inicio; t.DuracionMinutos = minutos;
            t.TratamientosIds.Add(limpieza1);
            return t;
        };

        Caso("Agendar un turno válido", () => { servTurnos.Agendar(crear(hora(10, 0), 30)); return servTurnos.ObtenerAgenda(1, dia).Count == 1; });
        Caso("Sin tratamientos falla", () => Lanza<InvalidOperationException>(() => { var t = crear(hora(12, 0), 30); t.TratamientosIds.Clear(); servTurnos.Agendar(t); }));
        Caso("Paciente inexistente falla", () => Lanza<InvalidOperationException>(() => { var t = crear(hora(12, 0), 30); t.PacienteId = 999; servTurnos.Agendar(t); }));
        Caso("Turno en el pasado falla", () => Lanza<InvalidOperationException>(() => servTurnos.Agendar(crear(DateTime.Now.AddHours(-1), 30))));
        Caso("A las 7:30 (antes de abrir) falla", () => Lanza<InvalidOperationException>(() => servTurnos.Agendar(crear(hora(7, 30), 30))));
        Caso("A las 20:45 por 30 min (termina 21:15) falla", () => Lanza<InvalidOperationException>(() => servTurnos.Agendar(crear(hora(20, 45), 30))));
        Caso("De 20:30 a 21:00 (justo en el límite) funciona", () => { servTurnos.Agendar(crear(hora(20, 30), 30)); return true; });
        Caso("Tratamiento de otro odontólogo falla", () => Lanza<InvalidOperationException>(() => { var t = crear(hora(12, 0), 30); t.TratamientosIds = new List<int> { limpieza2 }; servTurnos.Agendar(t); }));
        Caso("Tratamiento inexistente falla", () => Lanza<InvalidOperationException>(() => { var t = crear(hora(12, 0), 30); t.TratamientosIds.Add(9999); servTurnos.Agendar(t); }));
        Caso("Turno que se superpone falla", () => Lanza<InvalidOperationException>(() => servTurnos.Agendar(crear(hora(10, 15), 30))));
        Caso("Turno pegado al anterior funciona", () => { servTurnos.Agendar(crear(hora(10, 30), 30)); return true; });
        Caso("Otro odontólogo, mismo horario, funciona", () =>
        {
            var t = crear(hora(10, 0), 30);
            t.OdontologoId = 2; t.TratamientosIds = new List<int> { limpieza2 };
            servTurnos.Agendar(t);
            return servTurnos.ObtenerAgenda(2, dia).Count == 1;
        });
        Caso("Cancelar libera el horario", () =>
        {
            int id = servTurnos.ObtenerAgenda(1, dia).First(t => t.Inicio == hora(10, 30)).Id;
            servTurnos.Cancelar(id);
            servTurnos.Agendar(crear(hora(10, 30), 30));
            return servTurnos.ObtenerAgenda(1, dia).Count(t => t.Inicio == hora(10, 30)) == 1;
        });
        Caso("Cancelar un turno ya cancelado falla", () =>
        {
            int id = servTurnos.ObtenerTurnosDePaciente(pacienteId).First(t => t.Estado == EstadoTurno.Cancelado).Id;
            return Lanza<InvalidOperationException>(() => servTurnos.Cancelar(id));
        });
        Caso("Reprogramar: nuevo pendiente, el viejo queda Reprogramado y libera el horario", () =>
        {
            var original = servTurnos.ObtenerAgenda(1, dia).First(t => t.Inicio == hora(10, 0));
            Turno nuevo = servTurnos.Reprogramar(original.Id, hora(15, 0), 45);
            return nuevo.Estado == EstadoTurno.Pendiente
                && nuevo.TurnoOriginalId == original.Id
                && nuevo.DuracionMinutos == 45
                && original.Estado == EstadoTurno.Reprogramado
                && nuevo.TratamientosIds.Count == 1
                && !ReferenceEquals(nuevo.TratamientosIds, original.TratamientosIds)
                && !servTurnos.ObtenerAgenda(1, dia).Any(t => t.Inicio == hora(10, 0));
        });
        Caso("Reprogramar a un horario ocupado falla y el original sigue pendiente", () =>
        {
            var original = servTurnos.ObtenerAgenda(1, dia).First(t => t.Inicio == hora(20, 30));
            bool lanzo = Lanza<InvalidOperationException>(() => servTurnos.Reprogramar(original.Id, hora(15, 15), 30));
            return lanzo && original.Estado == EstadoTurno.Pendiente;
        });
        Caso("Reprogramar corriendo 15 minutos (no choca consigo mismo)", () =>
        {
            var original = servTurnos.ObtenerAgenda(1, dia).First(t => t.Inicio == hora(20, 30));
            Turno nuevo = servTurnos.Reprogramar(original.Id, hora(20, 15), 30);
            return nuevo.Inicio == hora(20, 15) && original.Estado == EstadoTurno.Reprogramado;
        });
        Caso("Reprogramar un turno que no está pendiente falla", () =>
        {
            int id = servTurnos.ObtenerTurnosDePaciente(pacienteId).First(t => t.Estado == EstadoTurno.Reprogramado).Id;
            return Lanza<InvalidOperationException>(() => servTurnos.Reprogramar(id, hora(17, 0), 30));
        });
        Caso("Marcar asistencia en un turno futuro falla", () =>
        {
            int id = servTurnos.ObtenerAgenda(1, dia).First(t => t.Inicio == hora(15, 0)).Id;
            return Lanza<InvalidOperationException>(() => servTurnos.MarcarAsistencia(id, true));
        });
        Caso("ObtenerAgenda: solo ese día y odontólogo, sin cancelados ni reprogramados", () =>
        {
            var agenda = servTurnos.ObtenerAgenda(1, dia);
            return agenda.Count == 3
                && servTurnos.ObtenerAgenda(2, dia).Count == 1
                && servTurnos.ObtenerAgenda(1, dia.AddDays(1)).Count == 0
                && agenda[0].Inicio < agenda[1].Inicio;
        });
        Caso("ObtenerTurnosDePaciente: todos los estados, del más reciente al más antiguo", () =>
        {
            var lista = servTurnos.ObtenerTurnosDePaciente(pacienteId);
            return lista.Count == 7
                && lista.Any(t => t.Estado == EstadoTurno.Cancelado)
                && lista[0].Inicio >= lista[lista.Count - 1].Inicio;
        });
        Caso("ObtenerTextoTratamientos une los nombres", () =>
        {
            var t = crear(hora(12, 0), 30);
            t.TratamientosIds.Add(extraccion1);
            string texto = servTurnos.ObtenerTextoTratamientos(t);
            return texto.Contains("Limpieza") && texto.Contains("Extracción") && texto.Contains(", ");
        });

        // ---------- RESULTADO ----------
        string informe = _informe.ToString();
        int fallos = informe.Split('\n').Count(l => l.StartsWith("FALLÓ") || l.StartsWith("ERROR"));
        Console.WriteLine(informe);
        Console.WriteLine($"TOTAL con problemas: {fallos}");

        LimpiarDatos();
    }
}