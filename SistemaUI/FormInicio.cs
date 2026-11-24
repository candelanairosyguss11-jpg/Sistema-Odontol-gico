using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormInicio : Form
    {
        private const int HoraInicio = 8, HoraFin = 21;
        private readonly CultureInfo cultura = new CultureInfo("es-AR");
        private readonly DataGridView grilla = new DataGridView();
        private readonly Label lblMes = new Label();
        private readonly ComboBox comboOdontologo = new ComboBox();
        private DateTime semanaInicio;

        public FormInicio()
        {
            InitializeComponent();
            ConstruirCalendario();
            IrASemana(DateTime.Today);
        }

        private void ConstruirCalendario()
        {
            var barra = new Panel { Dock = DockStyle.Top, Height = 50 };
            var btnAnt = new Button { Text = "‹", Width = 40, Left = 10, Top = 10 };
            var btnHoy = new Button { Text = "Hoy", Width = 60, Left = 55, Top = 10 };
            var btnSig = new Button { Text = "›", Width = 40, Left = 120, Top = 10 };
            lblMes.Left = 175; lblMes.Top = 14; lblMes.AutoSize = true;
            lblMes.Font = new Font("Segoe UI", 14F);

            btnAnt.Click += (s, e) => IrASemana(semanaInicio.AddDays(-7));
            btnSig.Click += (s, e) => IrASemana(semanaInicio.AddDays(7));
            btnHoy.Click += (s, e) => IrASemana(DateTime.Today);
            barra.Controls.AddRange(new Control[] { btnAnt, btnHoy, btnSig, lblMes });

            // Si es Secretario, mostramos selector de Odontólogo a la derecha
            if (Sesion.EsSecretario)
            {
                var lblFiltro = new Label { Text = "Odontólogo:", Left = 390, Top = 16, AutoSize = true };
                comboOdontologo.Left = 480;
                comboOdontologo.Top = 12;
                comboOdontologo.Width = 220;
                comboOdontologo.DropDownStyle = ComboBoxStyle.DropDownList;
                comboOdontologo.DataSource = Servicios.Usuarios.ObtenerOdontologos();
                comboOdontologo.DisplayMember = "NombreCompleto";
                comboOdontologo.ValueMember = "Id";
                comboOdontologo.SelectedIndexChanged += (s, e) => CargarTurnos();
                barra.Controls.AddRange(new Control[] { lblFiltro, comboOdontologo });
            }

            grilla.Dock = DockStyle.Fill;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.AllowUserToResizeRows = false;
            grilla.ReadOnly = true;
            grilla.EnableHeadersVisualStyles = false;
            grilla.BackgroundColor = Color.White;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grilla.ColumnHeadersHeight = 55;
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grilla.RowHeadersWidth = 70;
            grilla.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grilla.CellDoubleClick += Grilla_CellDoubleClick;

            for (int i = 0; i < 7; i++)
                grilla.Columns.Add(new DataGridViewTextBoxColumn
                { SortMode = DataGridViewColumnSortMode.NotSortable });

            for (int h = HoraInicio; h <= HoraFin; h++)
            {
                int idx = grilla.Rows.Add();
                grilla.Rows[idx].Height = 50;
                grilla.Rows[idx].HeaderCell.Value = $"{h}:00";
            }

            Controls.Add(grilla);
            Controls.Add(barra);
        }

        private int ObtenerOdontologoSeleccionadoId()
        {
            if (Sesion.OdontologoActual != null)
                return Sesion.OdontologoActual.Id;

            if (comboOdontologo.SelectedItem is Odontologo seleccionado)
                return seleccionado.Id;

            return 0;
        }

        private void IrASemana(DateTime fecha)
        {
            semanaInicio = fecha.Date.AddDays(-(int)fecha.DayOfWeek);
            lblMes.Text = cultura.TextInfo.ToTitleCase(
                semanaInicio.AddDays(3).ToString("MMMM yyyy", cultura));

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

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CentrarControles();
        }

        private void CentrarControles()
        {
            if (this.Controls.Count == 0) return;

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;

            foreach (Control c in this.Controls)
            {
                if (!c.Visible) continue;
                if (c.Left < minX) minX = c.Left;
                if (c.Top < minY) minY = c.Top;
                if (c.Right > maxX) maxX = c.Right;
                if (c.Bottom > maxY) maxY = c.Bottom;
            }

            int nuevoInicioX = (this.ClientSize.Width - (maxX - minX)) / 2;
            int nuevoInicioY = (this.ClientSize.Height - (maxY - minY)) / 2;

            this.SuspendLayout();
            foreach (Control c in this.Controls)
            {
                c.Left += nuevoInicioX - minX;
                c.Top += nuevoInicioY - minY;
            }
            this.ResumeLayout();
        }
    }
}