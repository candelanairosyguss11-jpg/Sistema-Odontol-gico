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
    public partial class FormHistoriasClinicas : Form
    {
        private readonly Paciente paciente;

        public FormHistoriasClinicas(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
            // sin Show() acá
        }

        private void FormHistoriasClinicas_Load(object sender, EventArgs e)
        {
            AbrirEnPanel(new FormDatosPaciente(paciente));//para que en el panel al abrir la historia clinica parazca primero el formulario de datos del paciente
        }
        private void AbrirEnPanel(Form f)
        {
            foreach (Control c in panelHC.Controls) c.Dispose();
            panelHC.Controls.Clear();

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            panelHC.Controls.Add(f);
            f.Show();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            var principal = Parent.FindForm() as FormPrincipalOdontologo;
            BeginInvoke(new Action(() => principal?.AbrirFormulario(new FormListaPacientes())));
        }

        private void buttonDatos_Click(object sender, EventArgs e)
        {
            AbrirEnPanel(new FormDatosPaciente(paciente));
        }

        private void buttonOdontograma_Click(object sender, EventArgs e)
        {
            AbrirEnPanel(new FormOdontograma(paciente));
        }

        private void buttonEstudios_Click(object sender, EventArgs e)
        {
            AbrirEnPanel(new FormEstudios(paciente));
        }

        private void buttonConsentimientos_Click(object sender, EventArgs e)
        {
            AbrirEnPanel(new FormConsentimiento(paciente));
        }

        private void buttonObservaciones_Click(object sender, EventArgs e)
        {
            AbrirEnPanel(new FormObservaciones(paciente));
        }

        private void panelHC_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
