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

            // como hacer para hacer la lista de los pacientes
            pacientes = new List<Paciente>
            {
                new Paciente { Id = 1, Apellido = "Pérez", Nombre = "Juan", DNI = "30111222" },
                new Paciente { Id = 2, Apellido = "Gómez", Nombre = "María", DNI = "28999888" }
            };
            MostrarPacientes(pacientes);//prueba, pero aunque cambie de dia sigue el turno 
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

        }
    }
}



