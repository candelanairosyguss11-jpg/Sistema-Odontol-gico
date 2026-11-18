using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormListaPaciente : Form
    {
        public FormListaPaciente()
        {
            InitializeComponent();
        }

        private void FormListaPaciente_Load(object sender, EventArgs e)
        {

        }
        
            private void FormListaPacientes_Load(object sender, EventArgs e)
            {
                dgvPacientes.ReadOnly = true;
                dgvPacientes.AllowUserToAddRows = false;
                dgvPacientes.MultiSelect = false;
                dgvPacientes.RowHeadersVisible = false;
                dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // TODO: traer los pacientes desde la capa Logica
                pacientes = new List<Paciente>
            {
                new Paciente { Id = 1, Apellido = "Pérez", Nombre = "Juan", DNI = "30111222" },
                new Paciente { Id = 2, Apellido = "Gómez", Nombre = "María", DNI = "28999888" }
            };
                MostrarPacientes(pacientes);
            }

            private void MostrarPacientes(List<Paciente> lista)
            {
                dgvPacientes.DataSource = null;
                dgvPacientes.DataSource = lista;
                dgvPacientes.Columns["Id"].Visible = false;
                dgvPacientes.Columns["Apellido"].Visible = false;
                dgvPacientes.Columns["Nombre"].Visible = false;
                // quedan visibles NombreCompleto y DNI
            }

            private void txtBuscar_TextChanged(object sender, EventArgs e)
            {
                string filtro = txtBuscar.Text.Trim();
                var filtrados = pacientes
                    .Where(p => p.NombreCompleto.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                MostrarPacientes(filtrados);
            }

            private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0) return;
                var paciente = (Paciente)dgvPacientes.Rows[e.RowIndex].DataBoundItem;
                var principal = Parent.FindForm() as FormPrincipalOdontologo;

                // BeginInvoke: AbrirFormulario destruye este form, así que lo hacemos
                // cuando el evento ya terminó
                BeginInvoke(new Action(() =>
                    principal?.AbrirFormulario(new FormHistoriasClinicas(paciente))));
            }
        }
    }
}
}
