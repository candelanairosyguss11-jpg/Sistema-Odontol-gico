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
            //para centar los controles
            CentrarControles();
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


        private void FormHistoriasClinicas_Resize(object sender, EventArgs e)
        {
            CentrarControles();
        }

        private void MenuHistoriasC_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
