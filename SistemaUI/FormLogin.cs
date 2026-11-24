using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Sistema_Odontológico;

namespace SistemaUI
{
    public partial class FormLogin : Form
    {
        private FormClosingEventHandler FormPrincipal_FormClosing;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !checkMostar.Checked;

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e) => Application.Exit();
        

        private void textContraseña_TextChanged(object sender, EventArgs e)
        {

        }


        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRol.Items.Clear();
            comboRol.Items.Add("Odontólogo");
            comboRol.Items.Add("Secretario");
            comboRol.SelectedIndex = -1;
            //para centar los controles
            CentrarControles();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            if (comboRol.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un rol.");
                return;
            }

            // falta validar DNI y contraseña 

            Form principal;
            switch (comboRol.SelectedItem.ToString())
            {
                case "Odontólogo": principal = new FormPrincipalOdontologo(); break;
                case "Secretario": principal = new FormPrincipalSecretario(); break;
                default: return;
            }

            // Cuando se cierra la sesión, vuelve a la pantalla de login 
            principal.FormClosed += (s, args) =>
            {
                textDNI.Clear();
                txtContrasena.Clear();
                comboRol.SelectedIndex = -1;
                this.Show();
            };

            principal.Show();
            this.Hide();

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

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
