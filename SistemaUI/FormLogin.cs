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

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // comboRol.Items.Clear();
        //    //comboRol.Items.Add("Odontólogo");
        //    //comboRol.Items.Add("Secretaria");
            
        //}


        //private void buttonIngresar_Click(object sender, EventArgs e)
        //{

        //    // validar usuario

        //    FormPrincipalOdontologo principal = new FormPrincipalOdontologo();

        //    principal.Show();
        //    this.Hide();

        //}

        //private void FormLogin_Load(object sender, EventArgs e)
        //{
        //    comboRol.Items.Add("Odontólogo");
        //    comboRol.Items.Add("Secretaria");
        //    comboRol.SelectedIndex = -1;
        //    //comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        //}

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


        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRol.Items.Clear();
            comboRol.Items.Add("Odontólogo");
            comboRol.Items.Add("Secretaria");
            comboRol.SelectedIndex = -1;
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            if (comboRol.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un rol.");
                return;
            }

            // TODO: validar DNI y contraseña con la capa Logica

            Form principal;
            switch (comboRol.SelectedItem.ToString())
            {
                case "Odontólogo": principal = new FormPrincipalOdontologo(); break;
                case "Secretaria": principal = new FormPrincipalSecretario(); break;
                default: return;
            }

            // Cuando se cierra la sesión, vuelve el login limpio
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
    }
}
