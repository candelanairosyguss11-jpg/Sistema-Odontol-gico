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

        // ---------- RESULTADO ----------
        string informe = _informe.ToString();
        int fallos = informe.Split('\n').Count(l => l.StartsWith("FALLÓ") || l.StartsWith("ERROR"));
        Console.WriteLine(informe);
        Console.WriteLine($"TOTAL con problemas: {fallos}");

        LimpiarDatos();
    }
}