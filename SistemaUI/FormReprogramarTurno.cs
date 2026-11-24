using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema_Odontológico;

namespace SistemaUI
{
    public partial class FormReprogramarTurno : Form
    {
        public FormReprogramarTurno()
        {
            InitializeComponent();
            dgvTurnos = new Panel();
        }

        private Paciente paciente;

        private void FormReprogramarTurno_Load(object sender, EventArgs e)
        {
            //para centar los controles
            CentrarControles();
        }

        private void CargarTurnos()
        {
            var odontologos = Servicios.Usuarios.ObtenerOdontologos();
            panelReprogramar.DataSource = Servicios.Turnos.ObtenerTurnosDePaciente(paciente.Id)
                .Where(t => t.Estado == EstadoTurno.Pendiente)
                .Select(t => new
                {
                    t.Id,
                    Fecha = t.Inicio.ToString("dd/MM/yyyy HH:mm"),
                    Odontologo = odontologos.FirstOrDefault(o => o.Id == t.OdontologoId)?.NombreCompleto,
                    Tratamientos = Servicios.Turnos.ObtenerTextoTratamientos(t)
                }).ToList();
            panelReprogramar.Columns["Id"].Visible = false;
        }
        private Panel dgvTurnos;
        //
        private void CentrarControles()
        {
            if (this.Controls.Count == 0) return;

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;

            // 1. Obtener los límites del bloque de controles
            foreach (Control c in this.Controls)
            {
                if (!c.Visible) continue;
                if (c.Left < minX) minX = c.Left;
                if (c.Top < minY) minY = c.Top;
                if (c.Right > maxX) maxX = c.Right;
                if (c.Bottom > maxY) maxY = c.Bottom;
            }

            int anchoBloque = maxX - minX;
            int altoBloque = maxY - minY;

            // 2. Calcular la nueva posición inicial centrada
            int nuevoInicioX = (this.ClientSize.Width - anchoBloque) / 2;
            int nuevoInicioY = (this.ClientSize.Height - altoBloque) / 2;

            // 3. Calcular cuánto debe moverse cada control
            int desplazamientoX = nuevoInicioX - minX;
            int desplazamientoY = nuevoInicioY - minY;

            // 4. Mover todos los controles manteniendo su posición relativa
            this.SuspendLayout();
            foreach (Control c in this.Controls)
            {
                c.Left += desplazamientoX;
                c.Top += desplazamientoY;
            }
            this.ResumeLayout();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            var turnos = Parent.FindForm() as FormTurnos;
            BeginInvoke(new Action(() => turnos?.VolverAlMenu()));
        }

        private void buttonBuscarDNI_Click(object sender, EventArgs e)
        {
            paciente = Servicios.Pacientes.BuscarPorDni(textDNI.Text);
            if (paciente == null) { MessageBox.Show("No existe un paciente con ese DNI."); return; }
            CargarTurnos();
        }

        private void buttonReprogramar_Click(object sender, EventArgs e)
        {
            if (panelReprogramar.CurrentRow == null) { MessageBox.Show("Elegí un turno."); return; }
            int id = (int)panelReprogramar.CurrentRow.Cells["Id"].Value;

            try
            {
                var nuevoInicio = dateTimePickerFechaTurno.Value.Date + dateTimePickerHora.Value.TimeOfDay;
                Servicios.Turnos.Reprogramar(id, nuevoInicio, (int)numDuracion.Value);
                MessageBox.Show("Turno reprogramado.");
                CargarTurnos();
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            { MessageBox.Show(ex.Message); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
