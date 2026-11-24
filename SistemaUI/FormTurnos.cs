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
    public partial class FormTurnos : Form
    {
        public FormTurnos()
        {
            InitializeComponent();

        }

        private DataGridView dgvTurnos;
        private void FormTurnos_Load(object sender, EventArgs e)
        {
            //para centar los controles
            //CentrarControles();
        }


        public void AbrirFormulario(Form formulario)
        {
            // El menú principal se oculta cuando se abre la sección de agregar, reprogramar y cancelar turnos
            panelMenuTurno.Visible = !(formulario is FormAgregarTurno || formulario is FormReprogramarTurno || formulario is FormCancelarTurno);

            foreach (Control control in panelTurnos.Controls)
            {
                control.Dispose();
            }

            panelTurnos.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelTurnos.Controls.Add(formulario);
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
            AbrirFormulario(new FormAgregarTurno());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReprogramarTurno());
        }

        private void buttonCancelarTurno_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCancelarTurno());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void VolverAlMenu()
        {
            panelMenuTurno.Visible = true;

            foreach (Control c in panelTurnos.Controls.Cast<Control>().ToList())
                c.Dispose();
            panelTurnos.Controls.Clear();
        }
        private void buttonVolver_Click(object sender, EventArgs e)
        {
            Form principal = Parent?.FindForm();

            BeginInvoke(new Action(() =>
            {
                if (principal is FormPrincipalSecretario secretario)
                    secretario.AbrirFormulario(new FormInicio());
                else if (principal is FormPrincipalOdontologo odontologo)
                    odontologo.AbrirFormulario(new FormInicio());
            }));
        }

        private void panelTurnos_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
