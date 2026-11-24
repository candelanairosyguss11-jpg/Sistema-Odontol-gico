using Sistema_Odontológico;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormCancelarTurno : Form
    {
        private Paciente paciente;

        public FormCancelarTurno()
        {
            InitializeComponent();
        }

        private void FormCancelarTurno_Load(object sender, EventArgs e)
        {
            CentrarControles();
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

            dgvTurnos.DataSource = pendientes;
            if (dgvTurnos.Columns["Id"] != null)
                dgvTurnos.Columns["Id"].Visible = false;
        }

        private void buttonBuscarDNI_Click(object sender, EventArgs e)
        {
            paciente = Servicios.Pacientes.BuscarPorDni(textDNI.Text);
            if (paciente == null)
            {
                lblPacienteInfo.Text = string.Empty;
                dgvTurnos.DataSource = null;
                MessageBox.Show("No existe un paciente con ese DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblPacienteInfo.Text = $"Paciente: {paciente.NombreCompleto}";
            CargarTurnos();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná el turno que querés cancelar.");
                return;
            }

            var confirmar = MessageBox.Show("¿Confirmás la cancelación de este turno?", "Cancelar Turno",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            int id = (int)dgvTurnos.CurrentRow.Cells["Id"].Value;

            try
            {
                Servicios.Turnos.Cancelar(id);
                MessageBox.Show("Turno cancelado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTurnos();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            var turnos = Parent?.FindForm() as FormTurnos;
            BeginInvoke(new Action(() => turnos?.VolverAlMenu()));
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