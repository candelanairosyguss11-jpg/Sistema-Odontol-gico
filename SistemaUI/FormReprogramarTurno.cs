using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormReprogramarTurno : Form
    {
        private Paciente paciente;

        public FormReprogramarTurno()
        {
            InitializeComponent();
        }

        private void FormReprogramarTurno_Load(object sender, EventArgs e)
        {
            CentrarControles();
            panelReprogramar.ReadOnly = true;
            panelReprogramar.AllowUserToAddRows = false;
            panelReprogramar.MultiSelect = false;
            panelReprogramar.RowHeadersVisible = false;
            panelReprogramar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            panelReprogramar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dateTimePickerFechaTurno.MinDate = DateTime.Today;
        }

        private void CargarTurnos()
        {
            var odontologos = Servicios.Usuarios.ObtenerOdontologos();
            var pendientes = Servicios.Turnos.ObtenerTurnosDePaciente(paciente.Id)
                .Where(t => t.Estado == EstadoTurno.Pendiente)
                .Select(t => new
                {
                    t.Id,
                    Fecha = t.Inicio.ToString("dd/MM/yyyy HH:mm"),
                    Duracion = $"{t.DuracionMinutos} min",
                    Odontologo = odontologos.FirstOrDefault(o => o.Id == t.OdontologoId)?.NombreCompleto,
                    Tratamientos = Servicios.Turnos.ObtenerTextoTratamientos(t)
                }).ToList();

            panelReprogramar.DataSource = pendientes;
            if (panelReprogramar.Columns["Id"] != null)
                panelReprogramar.Columns["Id"].Visible = false;
        }

        private void buttonBuscarDNI_Click(object sender, EventArgs e)
        {
            paciente = Servicios.Pacientes.BuscarPorDni(textDNI.Text);
            if (paciente == null)
            {
                MessageBox.Show("No existe un paciente con ese DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                panelReprogramar.DataSource = null;
                return;
            }
            CargarTurnos();
        }

        private void buttonReprogramar_Click(object sender, EventArgs e)
        {
            if (panelReprogramar.CurrentRow == null)
            {
                MessageBox.Show("Elegí un turno de la lista.");
                return;
            }

            int id = (int)panelReprogramar.CurrentRow.Cells["Id"].Value;

            try
            {
                DateTime nuevoInicio = dateTimePickerFechaTurno.Value.Date + dateTimePickerHora.Value.TimeOfDay;
                Servicios.Turnos.Reprogramar(id, nuevoInicio, (int)numDuracion.Value);
                MessageBox.Show("Turno reprogramado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTurnos();
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            {
                MessageBox.Show(ex.Message, "No se pudo reprogramar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            var turnos = Parent?.FindForm() as FormTurnos;
            BeginInvoke(new Action(() => turnos?.VolverAlMenu()));
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

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