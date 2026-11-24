using Sistema_Odontológico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace SistemaUI
{
    public partial class FormAgregarTurno : Form
    {
        public FormAgregarTurno()
        {
            InitializeComponent();
        }

        private Paciente pacienteActual;

        private void FormAgregarTurno_Load(object sender, EventArgs e)
        {
            //para centar los controles
            CentrarControles();
            comboBoxOdontologo.DataSource = Servicios.Usuarios.ObtenerOdontologos();
            comboBoxOdontologo.DisplayMember = "NombreCompleto";
            if (Sesion.Actual is Odontologo yo)
            {
                comboBoxOdontologo.SelectedValue = yo.Id;   // si no anda, buscá el ítem por Id
                comboBoxOdontologo.Enabled = false;
            }
        }

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

        private void textDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            var turnos = Parent.FindForm() as FormTurnos;
            BeginInvoke(new Action(() => turnos?.VolverAlMenu()));
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            bool hayDatos = textDNI.Text.Trim() != "" || textNombre.Text.Trim() != "";

            if (hayDatos)
            {
                var respuesta = MessageBox.Show("¿Descartar los datos cargados?", "Cancelar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes) return;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (pacienteActual == null)
                {
                    var p = new Paciente
                    {
                        Nombre = textNombre.Text,
                        Apellido = textApellido.Text,
                        DNI = textDNI2.Text,
                        Telefono = textTelefono.Text,
                        Correo = textCorreo.Text,
                        FechaNacimiento = DateOnly.FromDateTime(dateTimePicker1.Value)
                    };
                    Servicios.Pacientes.Registrar(p);      // Registrar completa p.Id
                    Servicios.Historias.ObtenerOCrear(p.Id);
                    pacienteActual = p;
                }

                if (comboBoxOdontologo.SelectedItem is not Odontologo odontologo)
                    throw new InvalidOperationException("Elegí un odontólogo.");

                var turno = new Turno
                {
                    PacienteId = pacienteActual.Id,
                    OdontologoId = odontologo.Id,
                    Inicio = dateTimePickerFechaTurno.Value.Date + dateTimePickerHora.Value.TimeOfDay,
                    DuracionMinutos = (int)numDuracion.Value,
                    // Detalle = textDetalle.Text.Trim()
                };
                foreach (Tratamiento t in checkedListBoxTratamientos.CheckedItems)
                    turno.TratamientosIds.Add(t.Id);

                Servicios.Turnos.Agendar(turno);
                MessageBox.Show("Turno agendado.");
                buttonVolver_Click(sender, e);
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            {
                MessageBox.Show(ex.Message, "No se pudo agendar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panelAltaRapida_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_2(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxOdontologo_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxTratamientos.Items.Clear();
            //    if (comboBoxOdontologo.SelectedItem is Odontologo o)
            //        checkedListBoxTratamientos.Items.AddRange(
            //    Servicio.Tratamientos.ObtenerActivosDeOdontologo(o.Id).ToArray());
        }

        private void checkedListBoxTratamientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                int total = checkedListBoxTratamientos.CheckedItems.Cast<Tratamiento>().Sum(t => t.DuracionMinutos);
                numDuracion.Value = Math.Clamp(total, Turno.DuracionMinima, Turno.DuracionMaxima);
            }));
        }

        private void dateTimePickerFechaTurno_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
