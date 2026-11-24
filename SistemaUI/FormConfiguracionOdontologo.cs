using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormConfiguracionOdontologo : Form
    {
        public FormConfiguracionOdontologo()
        {
            InitializeComponent();
        }

        private void FormConfiguracionOdontologo_Load(object sender, EventArgs e)
        {
            CentrarControles();
            MostrarSeccion(labelTratamientos, panelTratamientos);
            RecargarTratamientos();
        }

        private void MostrarSeccion(Label labelActivo, Panel panelActivo)
        {
            Label[] opciones = { labelTratamientos, labelCambiarContrasena, labelMisDatos, labelMisHorarios, labelGestionSecreta };
            foreach (var lbl in opciones)
            {
                lbl.ForeColor = lbl == labelActivo ? Color.MediumPurple : Color.Black;
                lbl.Font = new Font("Segoe UI", 10F, lbl == labelActivo ? FontStyle.Bold : FontStyle.Regular);
            }
            panelActivo.BringToFront();
        }

        // Navegación del menú
        private void labelTratamientos_Click(object sender, EventArgs e)
        {
            MostrarSeccion(labelTratamientos, panelTratamientos);
            RecargarTratamientos();
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
                lblInfoUsuario.Text = $"Odontólogo: {Sesion.Actual.NombreCompleto}  |  DNI: {Sesion.Actual.DNI}";
                txtCorreo.Text = Sesion.Actual.Correo;
                txtTelefono.Text = Sesion.Actual.Telefono;
            }
        }

        private void labelMisHorarios_Click(object sender, EventArgs e)
        {
            MostrarSeccion(labelMisHorarios, panelHorarios);
        }

        private void labelGestionSecreta_Click(object sender, EventArgs e)
        {
            MostrarSeccion(labelGestionSecreta, panelSecretarios);
            RecargarSecretarios();
        }

        // 1. Tratamientos
        private void RecargarTratamientos()
        {
            var odontologo = Sesion.OdontologoActual;
            if (odontologo == null) return;

            dgvTratamientos.DataSource = null;
            dgvTratamientos.DataSource = Servicios.Tratamientos.ObtenerTodosDeOdontologo(odontologo.Id);
            if (dgvTratamientos.Columns["Id"] != null) dgvTratamientos.Columns["Id"].Visible = false;
            if (dgvTratamientos.Columns["OdontologoId"] != null) dgvTratamientos.Columns["OdontologoId"].Visible = false;
        }

        private void btnAgregarTratamiento_Click(object sender, EventArgs e)
        {
            var odontologo = Sesion.OdontologoActual;
            if (odontologo == null) return;

            try
            {
                var nuevo = new Tratamiento
                {
                    OdontologoId = odontologo.Id,
                    Nombre = txtNombreTratamiento.Text,
                    DuracionMinutos = (int)numDuracionTratamiento.Value
                };
                Servicios.Tratamientos.Agregar(nuevo);
                txtNombreTratamiento.Clear();
                numDuracionTratamiento.Value = 30;
                RecargarTratamientos();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAlternarEstadoTratamiento_Click(object sender, EventArgs e)
        {
            if (dgvTratamientos.CurrentRow?.DataBoundItem is not Tratamiento seleccionado)
            {
                MessageBox.Show("Seleccioná un tratamiento de la lista.");
                return;
            }

            if (seleccionado.Activo) Servicios.Tratamientos.Desactivar(seleccionado.Id);
            else Servicios.Tratamientos.Reactivar(seleccionado.Id);
            RecargarTratamientos();
        }

        // 2. Cambiar contraseña
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

        // 3. Mis datos
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

        // 5. Gestión de secretarios
        private void RecargarSecretarios()
        {
            dgvSecretarios.DataSource = null;
            dgvSecretarios.DataSource = Servicios.Usuarios.ObtenerSecretarios()
                .Select(s => new { s.Id, s.NombreCompleto, s.DNI, s.Correo, s.Telefono, Estado = s.Activo ? "Activo" : "Inactivo" })
                .ToList();
            if (dgvSecretarios.Columns["Id"] != null) dgvSecretarios.Columns["Id"].Visible = false;
        }

        private void btnRegistrarSecretario_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevo = new Secretario
                {
                    Nombre = txtSecNombre.Text,
                    Apellido = txtSecApellido.Text,
                    DNI = txtSecDni.Text,
                    Correo = txtSecCorreo.Text,
                    Telefono = txtSecTel.Text
                };
                nuevo.EstablecerContrasena(txtSecPass.Text);
                Servicios.Usuarios.Registrar(nuevo);

                txtSecNombre.Clear(); txtSecApellido.Clear(); txtSecDni.Clear();
                txtSecCorreo.Clear(); txtSecTel.Clear(); txtSecPass.Clear();
                RecargarSecretarios();
                MessageBox.Show("Secretario registrado correctamente.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "No se pudo registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEstadoSecretario_Click(object sender, EventArgs e)
        {
            if (dgvSecretarios.CurrentRow == null) return;
            int id = (int)dgvSecretarios.CurrentRow.Cells["Id"].Value;
            bool estaActivo = dgvSecretarios.CurrentRow.Cells["Estado"].Value?.ToString() == "Activo";
            Servicios.Usuarios.CambiarEstadoSecretario(id, !estaActivo);
            RecargarSecretarios();
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