using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormAgregarTurno : Form
    {
        private Paciente pacienteActual;

        public FormAgregarTurno()
        {
            InitializeComponent();
        }

        private void FormAgregarTurno_Load(object sender, EventArgs e)
        {
            CentrarControles();

            // Vincular evento del botón Buscar DNI que no estaba en el Designer
            buttonBuscarDNI.Click += buttonBuscarDNI_Click;

            comboBoxOdontologo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOdontologo.DataSource = Servicios.Usuarios.ObtenerOdontologos();
            comboBoxOdontologo.DisplayMember = "NombreCompleto";
            comboBoxOdontologo.ValueMember = "Id";

            if (Sesion.OdontologoActual != null)
            {
                comboBoxOdontologo.SelectedValue = Sesion.OdontologoActual.Id;
                comboBoxOdontologo.Enabled = false;
            }

            CargarTratamientosDelOdontologo();
            dateTimePickerFechaTurno.MinDate = DateTime.Today;
        }

        private void CargarTratamientosDelOdontologo()
        {
            checkedListBoxTratamientos.Items.Clear();
            if (comboBoxOdontologo.SelectedItem is Odontologo o)
            {
                var activos = Servicios.Tratamientos.ObtenerActivosDeOdontologo(o.Id);
                checkedListBoxTratamientos.Items.AddRange(activos.ToArray());
            }
        }

        private void comboBoxOdontologo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTratamientosDelOdontologo();
        }

        private void checkedListBoxTratamientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                int total = checkedListBoxTratamientos.CheckedItems.Cast<Tratamiento>().Sum(t => t.DuracionMinutos);
                if (total > 0)
                {
                    numDuracion.Value = Math.Clamp(total, Turno.DuracionMinima, Turno.DuracionMaxima);
                }
            }));
        }

        private void buttonBuscarDNI_Click(object sender, EventArgs e)
        {
            string dni = textDNI.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Ingresá un DNI para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pacienteActual = Servicios.Pacientes.BuscarPorDni(dni);

            if (pacienteActual != null)
            {
                textNombre.Text = pacienteActual.Nombre;
                textApellido.Text = pacienteActual.Apellido;
                textDNI2.Text = pacienteActual.DNI;
                textTelefono.Text = pacienteActual.Telefono;
                textCorreo.Text = pacienteActual.Correo;
                dateTimePicker1.Value = pacienteActual.FechaNacimiento.ToDateTime(TimeOnly.MinValue);

                HabilitarCamposPaciente(false);
                MessageBox.Show($"Paciente encontrado: {pacienteActual.NombreCompleto}", "Paciente existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LimpiarCamposPaciente();
                textDNI2.Text = Validador.NormalizarDni(dni);
                HabilitarCamposPaciente(true);
                MessageBox.Show("No se encontró un paciente con ese DNI. Completá los datos de alta rápida.", "Nuevo paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HabilitarCamposPaciente(bool habilitar)
        {
            textNombre.Enabled = habilitar;
            textApellido.Enabled = habilitar;
            textDNI2.Enabled = habilitar;
            textTelefono.Enabled = habilitar;
            textCorreo.Enabled = habilitar;
            dateTimePicker1.Enabled = habilitar;
        }

        private void LimpiarCamposPaciente()
        {
            pacienteActual = null;
            textNombre.Clear();
            textApellido.Clear();
            textDNI2.Clear();
            textTelefono.Clear();
            textCorreo.Clear();
            dateTimePicker1.Value = DateTime.Today.AddYears(-25);
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
                    Servicios.Pacientes.Registrar(p);
                    pacienteActual = p;
                }

                if (comboBoxOdontologo.SelectedItem is not Odontologo odontologo)
                    throw new InvalidOperationException("Elegí un odontólogo.");

                var turno = new Turno
                {
                    PacienteId = pacienteActual.Id,
                    OdontologoId = odontologo.Id,
                    Inicio = dateTimePickerFechaTurno.Value.Date + dateTimePickerHora.Value.TimeOfDay,
                    DuracionMinutos = (int)numDuracion.Value
                };

                foreach (Tratamiento t in checkedListBoxTratamientos.CheckedItems)
                    turno.TratamientosIds.Add(t.Id);

                Servicios.Turnos.Agendar(turno);
                MessageBox.Show("Turno agendado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonVolver_Click(sender, e);
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            {
                MessageBox.Show(ex.Message, "No se pudo agendar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            bool hayDatos = !string.IsNullOrWhiteSpace(textDNI.Text) || !string.IsNullOrWhiteSpace(textNombre.Text);
            if (hayDatos)
            {
                var respuesta = MessageBox.Show("¿Descartar los datos cargados?", "Cancelar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes) return;
            }
            buttonVolver_Click(sender, e);
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            var turnos = Parent?.FindForm() as FormTurnos;
            BeginInvoke(new Action(() => turnos?.VolverAlMenu()));
        }

        private void textDNI_TextChanged(object sender, EventArgs e)
        {
            if (pacienteActual != null)
            {
                HabilitarCamposPaciente(true);
                pacienteActual = null;
            }
        }

        private void panelAltaRapida_Paint(object sender, PaintEventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label7_Click_1(object sender, EventArgs e) { }
        private void label7_Click_2(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void dateTimePickerFechaTurno_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }

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