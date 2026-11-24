using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormInicio : Form
    {
        private const int HoraInicio = 8, HoraFin = 21;
        private readonly CultureInfo cultura = new CultureInfo("es-AR");
        private readonly Odontologo odontologoFijo;
        private DateTime semanaInicio;

        public FormInicio() : this(null)
        {
        }

        public FormInicio(Odontologo odontologo)
        {
            InitializeComponent();
            this.odontologoFijo = odontologo;

            // Si es Secretario y entró a "Inicio" (sin seleccionar una agenda específica del menú)
            if (Sesion.EsSecretario && odontologoFijo == null)
            {
                MostrarResumenSecretario();
            }
            else
            {
                panelInicioSecretario.Visible = false;
                ConfigurarGrilla();
                IrASemana(DateTime.Today);
            }
        }

        private void MostrarResumenSecretario()
        {
            barra.Visible = false;
            grilla.Visible = false;
            panelInicioSecretario.Visible = true;
            panelInicioSecretario.BringToFront();

            if (Sesion.Actual != null)
                lblBienvenida.Text = $"Bienvenido/a, {Sesion.Actual.NombreCompleto}";

            lblSubtituloHoy.Text = $"Turnos de hoy ({DateTime.Today:dddd dd 'de' MMMM}) — Seleccioná una agenda en el menú lateral para ver la semana completa:";

            var odontologos = Servicios.Usuarios.ObtenerOdontologos();
            var turnosHoy = odontologos
                .SelectMany(o => Servicios.Turnos.ObtenerAgenda(o.Id, DateTime.Today))
                .OrderBy(t => t.Inicio)
                .Select(t =>
                {
                    var paciente = Servicios.Pacientes.ObtenerPorId(t.PacienteId);
                    var odontologo = odontologos.FirstOrDefault(o => o.Id == t.OdontologoId);
                    return new
                    {
                        Horario = $"{t.Inicio:HH:mm} - {t.Fin:HH:mm}",
                        Odontologo = odontologo?.NombreCompleto ?? "-",
                        Paciente = paciente?.NombreCompleto ?? $"Paciente #{t.PacienteId}",
                        DNI = paciente?.DNI ?? "-",
                        Tratamientos = Servicios.Turnos.ObtenerTextoTratamientos(t),
                        Estado = t.Estado.ToString()
                    };
                }).ToList();

            dgvTurnosHoy.DataSource = turnosHoy;
        }

        private void ConfigurarGrilla()
        {
            grilla.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            grilla.Columns.Clear();
            for (int i = 0; i < 7; i++)
                grilla.Columns.Add(new DataGridViewTextBoxColumn
                { SortMode = DataGridViewColumnSortMode.NotSortable });

            grilla.Rows.Clear();
            for (int h = HoraInicio; h <= HoraFin; h++)
            {
                int idx = grilla.Rows.Add();
                grilla.Rows[idx].Height = 50;
                grilla.Rows[idx].HeaderCell.Value = $"{h}:00";
            }
        }

        private int ObtenerOdontologoSeleccionadoId()
        {
            if (odontologoFijo != null)
                return odontologoFijo.Id;

            if (Sesion.OdontologoActual != null)
                return Sesion.OdontologoActual.Id;

            return 0;
        }

        private void IrASemana(DateTime fecha)
        {
            semanaInicio = fecha.Date.AddDays(-(int)fecha.DayOfWeek);
            string tituloMes = cultura.TextInfo.ToTitleCase(semanaInicio.AddDays(3).ToString("MMMM yyyy", cultura));
            lblMes.Text = odontologoFijo != null
                ? $"{tituloMes}  —  Agenda de {odontologoFijo.NombreCompleto}"
                : tituloMes;

            for (int i = 0; i < 7; i++)
            {
                DateTime dia = semanaInicio.AddDays(i);
                var col = grilla.Columns[i];
                col.HeaderText = $"{dia.ToString("ddd", cultura)}\n{dia.Day}";
                bool esHoy = dia == DateTime.Today;
                col.HeaderCell.Style.BackColor = esHoy ? Color.MediumPurple : Color.WhiteSmoke;
                col.HeaderCell.Style.ForeColor = esHoy ? Color.White : Color.Black;
            }
            CargarTurnos();
        }

        private void CargarTurnos()
        {
            foreach (DataGridViewRow fila in grilla.Rows)
                foreach (DataGridViewCell c in fila.Cells)
                {
                    c.Value = null;
                    c.Tag = null;
                    c.Style.BackColor = Color.White;
                }

            int odontologoId = ObtenerOdontologoSeleccionadoId();
            if (odontologoId <= 0) return;

            for (int i = 0; i < 7; i++)
            {
                DateTime dia = semanaInicio.AddDays(i);
                var turnosDelDia = Servicios.Turnos.ObtenerAgenda(odontologoId, dia);

                foreach (var turno in turnosDelDia)
                {
                    var paciente = Servicios.Pacientes.ObtenerPorId(turno.PacienteId);
                    string nombrePaciente = paciente != null ? paciente.NombreCompleto : $"Paciente #{turno.PacienteId}";
                    string tratamientos = Servicios.Turnos.ObtenerTextoTratamientos(turno);
                    string texto = $"{turno.Inicio:HH:mm} - {nombrePaciente}\n({tratamientos})";

                    Color color = turno.Estado switch
                    {
                        EstadoTurno.Asistio => Color.LightGreen,
                        EstadoTurno.NoAsistio => Color.LightCoral,
                        _ => Color.LightSkyBlue
                    };

                    MostrarTurno(turno, texto, color);
                }
            }
        }

        private void MostrarTurno(Turno turno, string texto, Color color)
        {
            int col = (int)turno.Inicio.DayOfWeek;
            int filaInicio = turno.Inicio.Hour - HoraInicio;
            int bloques = Math.Max(1, (int)Math.Ceiling(turno.DuracionMinutos / 60.0));

            for (int b = 0; b < bloques; b++)
            {
                int fila = filaInicio + b;
                if (fila < 0 || fila >= grilla.Rows.Count) continue;

                var celda = grilla.Rows[fila].Cells[col];
                celda.Value = b == 0 ? texto : "↳ (continúa)";
                celda.Tag = turno;
                celda.Style.BackColor = color;
            }
        }

        private void btnAnt_Click(object sender, EventArgs e) => IrASemana(semanaInicio.AddDays(-7));
        private void btnHoy_Click(object sender, EventArgs e) => IrASemana(DateTime.Today);
        private void btnSig_Click(object sender, EventArgs e) => IrASemana(semanaInicio.AddDays(7));

        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (grilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag is not Turno turno) return;

            if (turno.Estado != EstadoTurno.Pendiente)
            {
                MessageBox.Show($"Este turno ya figura como: {turno.Estado}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                "¿El paciente asistió al turno?\n\n• Sí: Marcar como Asistió\n• No: Marcar como No Asistió\n• Cancelar: Salir sin cambios",
                "Registrar asistencia",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Cancel) return;

            try
            {
                Servicios.Turnos.MarcarAsistencia(turno.Id, respuesta == DialogResult.Yes);
                CargarTurnos();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormInicio_Load(object sender, EventArgs e) { }
    }
}