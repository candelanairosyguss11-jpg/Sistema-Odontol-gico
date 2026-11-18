using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormPrincipalSecretario : Form
    {
        public FormPrincipalSecretario()
        {
            InitializeComponent();
        }
        private void AbrirFormulario(Form formulario)
        {
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

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInicio());
        }

        private void buttonTurnos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormTurnos());
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
