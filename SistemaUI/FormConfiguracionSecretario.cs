using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormConfiguracionSecretario : Form
    {
        public FormConfiguracionSecretario()
        {
            InitializeComponent();
        }

        private void FormConfiguracionSecretario_Load(object sender, EventArgs e)
        {
            CentrarControles();
            MostrarSeccion(labelCambiarContrasena, panelContrasena);
        }

        private void MostrarSeccion(Label labelActivo, Panel panelActivo)
        {
            Label[] opciones = { labelCambiarContrasena, labelMisDatos };
            foreach (var lbl in opciones)
            {
                lbl.ForeColor = lbl == labelActivo ? Color.MediumPurple : Color.Black;
                lbl.Font = new Font("Segoe UI", 10F, lbl == labelActivo ? FontStyle.Bold : FontStyle.Regular);
            }
            panelActivo.BringToFront();
        }

        private void labelCambiarContrasena_Click(object sender, EventArgs e)
        {
            MostrarSeccion(labelCambiarContrasena, panelContrasena);
        }

        private void labelMisDatos_Click(object sender, EventArgs e)
        {
            MostrarSeccion(labelMisDatos, panelDatos);
            if (Sesion.Actual != null)
            {
                lblInfoUsuario.Text = $"Secretario/a: {Sesion.Actual.NombreCompleto}  |  DNI: {Sesion.Actual.DNI}";
                txtCorreo.Text = Sesion.Actual.Correo;
                txtTelefono.Text = Sesion.Actual.Telefono;
            }
        }

        private void btnGuardarContrasena_Click(object sender, EventArgs e)
        {
            if (txtPassNueva.Text != txtPassConfirmar.Text)
            {
                MessageBox.Show("La confirmación no coincide con la nueva contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Servicios.Usuarios.CambiarContrasena(Sesion.Actual, txtPassActual.Text, txtPassNueva.Text);
                MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassActual.Clear();
                txtPassNueva.Clear();
                txtPassConfirmar.Clear();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            var usuario = Sesion.Actual;
            if (usuario == null) return;

            try
            {
                usuario.Correo = txtCorreo.Text;
                usuario.Telefono = txtTelefono.Text;
                Servicios.Usuarios.ActualizarDatos(usuario);
                MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CentrarControles()
        {
            if (this.Controls.Count == 0) return;

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;

            foreach (Control c in this.Controls)
            {
                if (!c.Visible) continue;
                if (c.Left < minX) minX = c.Left;
                if (c.Top < minY) minY = c.Top;
                if (c.Right > maxX) maxX = c.Right;
                if (c.Bottom > maxY) maxY = c.Bottom;
            }

            int nuevoInicioX = (this.ClientSize.Width - (maxX - minX)) / 2;
            int nuevoInicioY = (this.ClientSize.Height - (maxY - minY)) / 2;

            this.SuspendLayout();
            foreach (Control c in this.Controls)
            {
                c.Left += nuevoInicioX - minX;
                c.Top += nuevoInicioY - minY;
            }
            this.ResumeLayout();
        }
    }
}