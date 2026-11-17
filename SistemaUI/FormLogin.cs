using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboRol.Items.Add("Secretaria");
            //comboRol.Items.Add("Odontólogo");

            //comboRol.SelectedIndex = -1;

            comboRol.Items.Clear();
            comboRol.Items.Add("Odontólogo");
            comboRol.Items.Add("Secretaria");
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void buttonIngresar_Click(object sender, EventArgs e)
        {

            // validar usuario

            FormPrincipal principal = new FormPrincipal();

            principal.Show();
            this.Hide();

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["FormPrincipal"] != null)
            {
                Application.OpenForms["FormPrincipal"].FormClosing -= FormPrincipal_FormClosing;
            }

            this.Show();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FormLogin"].Show();
            this.Close();
        }

        private void textContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
