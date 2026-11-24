using Sistema_Odontológico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormListaPacientes : Form
    {

        private List<Paciente> pacientes = new();


        public FormListaPacientes()
        {
            InitializeComponent();
        }

        private void FormListaPaciente_Load(object sender, EventArgs e)
        {
            dataGridViewPacientes.ReadOnly = true;
            dataGridViewPacientes.AllowUserToAddRows = false;
            dataGridViewPacientes.MultiSelect = false;
            dataGridViewPacientes.RowHeadersVisible = false;
            dataGridViewPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //para centar los controles
            CentrarControles();

            pacientes = Servicios.Pacientes.ObtenerTodos();
            MostrarPacientes(pacientes);
            // como hacer para hacer la lista de los pacientes y
            pacientes = new List<Paciente>
            {
                new Paciente { Id = 1, Apellido = "Pérez", Nombre = "Juan", DNI = "30111222" },
                new Paciente { Id = 2, Apellido = "Gómez", Nombre = "María", DNI = "28999888" }
            };
            MostrarPacientes(pacientes);//prueba
        }

        private void MostrarPacientes(List<Paciente> lista)
        {
            dataGridViewPacientes.DataSource = null;
            dataGridViewPacientes.DataSource = lista;
            dataGridViewPacientes.Columns["Id"].Visible = false;
            dataGridViewPacientes.Columns["Apellido"].Visible = false;
            dataGridViewPacientes.Columns["Nombre"].Visible = false;
            // quedan visibles NombreCompleto y DNI
        }

        private void ListadePacientes_Click(object sender, EventArgs e)
        {
            string filtro = textBuscarPaciente.Text.Trim();
            var filtrados = pacientes.Where(p => p.NombreCompleto.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
            MostrarPacientes(filtrados);
        }

        private void dataGridViewPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var paciente = (Paciente)dataGridViewPacientes.Rows[e.RowIndex].DataBoundItem;
            var principal = Parent.FindForm() as FormPrincipalOdontologo;

            // BeginInvoke: AbrirFormulario destruye este form, así que lo hacemos
            // cuando el evento ya terminó
            BeginInvoke(new Action(() => principal?.AbrirFormulario(new FormHistoriasClinicas(paciente))));
        }

        private void textBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBuscarPaciente.Text.Trim();
            var filtrados = pacientes
                .Where(p => p.NombreCompleto.Contains(filtro, StringComparison.OrdinalIgnoreCase)
                         || p.DNI.Contains(filtro))
                .ToList();
            MostrarPacientes(filtrados);
        }

        public void AbrirFormulario(Form formulario)
        {
            // El menú principal se oculta cuando se abre la sección de turnos
            panelMenu.Visible = !(formulario is FormHistoriasClinicas);
            foreach (Control control in panelContenido.Controls)
            {
                control.Dispose();
            }

            panelContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);
            formulario.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewPacientes.CurrentRow?.DataBoundItem is not Paciente paciente)
            {
                MessageBox.Show("Elegí un paciente de la lista.");
                return;
            }

            try
            {
                // si el paciente no tiene historia, se crea; si ya tiene, se abre la existente
                if (Servicios.Historias.ObtenerPorPaciente(paciente.Id) == null)
                {
                    var historia = new HistoriaClinica { PacienteId = paciente.Id };
                    Servicios.Historias.Crear(historia, Sesion.OdontologoActual);
                }
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var principal = Parent.FindForm() as FormPrincipalOdontologo;
            BeginInvoke(new Action(() => principal?.AbrirFormulario(new FormCrearHistoriaClinica())));
        }
        

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenido_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelContenido_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}



