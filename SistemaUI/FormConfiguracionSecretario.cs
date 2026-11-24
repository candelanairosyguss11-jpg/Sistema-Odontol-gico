using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormConfiguracionSecretario : Form
    {
        private readonly Panel panelContenidoConf = new Panel();

        public FormConfiguracionSecretario()
        {
            InitializeComponent();
        }

        private void FormConfiguracionSecretario_Load(object sender, EventArgs e)
        {
            panelContenidoConf.Location = new Point(199, 12);
            panelContenidoConf.Size = new Size(589, 426);
            this.Controls.Add(panelContenidoConf);

            CentrarControles();

            labelCambiarContrasena.Cursor = Cursors.Hand;
            labelMisDatos.Cursor = Cursors.Hand;

            labelCambiarContrasena.Click += (s, ev) => { MarcarActivo(labelCambiarContrasena); MostrarCambiarContrasena(); };
            labelMisDatos.Click += (s, ev) => { MarcarActivo(labelMisDatos); MostrarMisDatos(); };

            MarcarActivo(labelCambiarContrasena);
            MostrarCambiarContrasena();
        }

        private void MarcarActivo(Label activo)
        {
            Label[] opciones = { labelCambiarContrasena, labelMisDatos };
            foreach (var lbl in opciones)
            {
                lbl.ForeColor = lbl == activo ? Color.MediumPurple : Color.Black;
                lbl.Font = new Font("Segoe UI", 10F, lbl == activo ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        private void LimpiarPanelContenido()
        {
            foreach (Control c in panelContenidoConf.Controls) c.Dispose();
            panelContenidoConf.Controls.Clear();
        }

        private void MostrarCambiarContrasena()
        {
            LimpiarPanelContenido();
            var lblTitulo = new Label { Text = "Cambiar Contraseña", Font = new Font("Segoe UI", 13F, FontStyle.Bold), Left = 15, Top = 10, AutoSize = true };

            var lblActual = new Label { Text = "Contraseña actual:", Left = 15, Top = 60, AutoSize = true };
            var txtActual = new TextBox { Left = 180, Top = 57, Width = 220, UseSystemPasswordChar = true };

            var lblNueva = new Label { Text = "Nueva contraseña:", Left = 15, Top = 105, AutoSize = true };
            var txtNueva = new TextBox { Left = 180, Top = 102, Width = 220, UseSystemPasswordChar = true };

            var lblConfirmar = new Label { Text = "Confirmar nueva:", Left = 15, Top = 150, AutoSize = true };
            var txtConfirmar = new TextBox { Left = 180, Top = 147, Width = 220, UseSystemPasswordChar = true };

            var btnGuardar = new Button { Text = "Actualizar contraseña", Left = 180, Top = 195, Width = 220, Height = 32 };

            btnGuardar.Click += (s, e) =>
            {
                if (txtNueva.Text != txtConfirmar.Text)
                {
                    MessageBox.Show("La confirmación no coincide con la nueva contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Servicios.Usuarios.CambiarContrasena(Sesion.Actual, txtActual.Text, txtNueva.Text);
                    MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtActual.Clear(); txtNueva.Clear(); txtConfirmar.Clear();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            panelContenidoConf.Controls.AddRange(new Control[] { lblTitulo, lblActual, txtActual, lblNueva, txtNueva, lblConfirmar, txtConfirmar, btnGuardar });
        }

        private void MostrarMisDatos()
        {
            LimpiarPanelContenido();
            var usuario = Sesion.Actual;
            if (usuario == null) return;

            var lblTitulo = new Label { Text = "Mis Datos Personales", Font = new Font("Segoe UI", 13F, FontStyle.Bold), Left = 15, Top = 10, AutoSize = true };
            var lblInfo = new Label { Text = $"Secretario/a: {usuario.NombreCompleto}  |  DNI: {usuario.DNI}", Left = 15, Top = 50, AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };

            var lblCorreo = new Label { Text = "Correo:", Left = 15, Top = 95, AutoSize = true };
            var txtCorreo = new TextBox { Left = 110, Top = 92, Width = 260, Text = usuario.Correo };

            var lblTel = new Label { Text = "Teléfono:", Left = 15, Top = 140, AutoSize = true };
            var txtTel = new TextBox { Left = 110, Top = 137, Width = 260, Text = usuario.Telefono };

            var btnGuardar = new Button { Text = "Guardar cambios", Left = 110, Top = 185, Width = 160, Height = 32 };

            btnGuardar.Click += (s, e) =>
            {
                try
                {
                    usuario.Correo = txtCorreo.Text;
                    usuario.Telefono = txtTel.Text;
                    Servicios.Usuarios.ActualizarDatos(usuario);
                    MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            panelContenidoConf.Controls.AddRange(new Control[] { lblTitulo, lblInfo, lblCorreo, txtCorreo, lblTel, txtTel, btnGuardar });
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