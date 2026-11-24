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
            ConfigurarMenu();
            MostrarMisTratamientos(); // vista por defecto al abrir
        }

        private void ConfigurarMenu()
        {
            Label[] opciones = { labelTratamientos, labelCambiarContrasena, labelMisDatos, labelMisHorarios, labelGestionSecreta };
            foreach (var lbl in opciones)
            {
                lbl.Cursor = Cursors.Hand;
                lbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            // Enganchamos los eventos que no estaban conectados en el Designer
            labelMisDatos.Click += (s, e) => { MarcarActivo(labelMisDatos); MostrarMisDatos(); };
            labelMisHorarios.Click += (s, e) => { MarcarActivo(labelMisHorarios); MostrarMisHorarios(); };
            labelGestionSecreta.Click += (s, e) => { MarcarActivo(labelGestionSecreta); MostrarGestionSecretarios(); };

            MarcarActivo(labelTratamientos);
        }

        private void MarcarActivo(Label activo)
        {
            Label[] opciones = { labelTratamientos, labelCambiarContrasena, labelMisDatos, labelMisHorarios, labelGestionSecreta };
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

        // Eventos ya vinculados en el Designer
        private void label1_Click(object sender, EventArgs e)
        {
            MarcarActivo(labelTratamientos);
            MostrarMisTratamientos();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            MarcarActivo(labelCambiarContrasena);
            MostrarCambiarContrasena();
        }

        private void labelMisHorarios_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }

        // =========================================================
        // 1. MIS TRATAMIENTOS (CRUD con ServicioTratamientos)
        // =========================================================
        private void MostrarMisTratamientos()
        {
            LimpiarPanelContenido();
            var odontologo = Sesion.OdontologoActual;
            if (odontologo == null) return;

            var lblTitulo = new Label { Text = "Mis Tratamientos", Font = new Font("Segoe UI", 13F, FontStyle.Bold), Left = 15, Top = 10, AutoSize = true };
            var lblNombre = new Label { Text = "Nombre:", Left = 15, Top = 50, AutoSize = true };
            var txtNombre = new TextBox { Left = 85, Top = 47, Width = 200 };
            var lblDuracion = new Label { Text = "Duración (min):", Left = 300, Top = 50, AutoSize = true };
            var numDuracion = new NumericUpDown { Left = 405, Top = 47, Width = 65, Minimum = Turno.DuracionMinima, Maximum = Turno.DuracionMaxima, Increment = 15, Value = 30 };
            var btnAgregar = new Button { Text = "Agregar", Left = 485, Top = 45, Width = 85, Height = 27 };

            var dgv = new DataGridView
            {
                Left = 15,
                Top = 90,
                Width = 555,
                Height = 275,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            var btnAlternarEstado = new Button { Text = "Activar / Desactivar seleccionado", Left = 15, Top = 378, Width = 230, Height = 30 };

            void RecargarGrilla()
            {
                dgv.DataSource = null;
                dgv.DataSource = Servicios.Tratamientos.ObtenerTodosDeOdontologo(odontologo.Id);
                if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
                if (dgv.Columns["OdontologoId"] != null) dgv.Columns["OdontologoId"].Visible = false;
            }

            btnAgregar.Click += (s, e) =>
            {
                try
                {
                    var nuevo = new Tratamiento
                    {
                        OdontologoId = odontologo.Id,
                        Nombre = txtNombre.Text,
                        DuracionMinutos = (int)numDuracion.Value
                    };
                    Servicios.Tratamientos.Agregar(nuevo);
                    txtNombre.Clear();
                    numDuracion.Value = 30;
                    RecargarGrilla();
                }
                catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnAlternarEstado.Click += (s, e) =>
            {
                if (dgv.CurrentRow?.DataBoundItem is not Tratamiento seleccionado)
                {
                    MessageBox.Show("Seleccioná un tratamiento de la lista.");
                    return;
                }

                if (seleccionado.Activo) Servicios.Tratamientos.Desactivar(seleccionado.Id);
                else Servicios.Tratamientos.Reactivar(seleccionado.Id);
                RecargarGrilla();
            };

            panelContenidoConf.Controls.AddRange(new Control[] { lblTitulo, lblNombre, txtNombre, lblDuracion, numDuracion, btnAgregar, dgv, btnAlternarEstado });
            RecargarGrilla();
        }

        // =========================================================
        // 2. CAMBIAR CONTRASEÑA
        // =========================================================
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

        // =========================================================
        // 3. MIS DATOS
        // =========================================================
        private void MostrarMisDatos()
        {
            LimpiarPanelContenido();
            var usuario = Sesion.Actual;
            if (usuario == null) return;

            var lblTitulo = new Label { Text = "Mis Datos Personales", Font = new Font("Segoe UI", 13F, FontStyle.Bold), Left = 15, Top = 10, AutoSize = true };
            var lblInfo = new Label { Text = $"Odontólogo: {usuario.NombreCompleto}  |  DNI: {usuario.DNI}", Left = 15, Top = 50, AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };

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

        // =========================================================
        // 4. MIS HORARIOS
        // =========================================================
        private void MostrarMisHorarios()
        {
            LimpiarPanelContenido();
            var lblTitulo = new Label { Text = "Horarios de Atención del Consultorio", Font = new Font("Segoe UI", 13F, FontStyle.Bold), Left = 15, Top = 10, AutoSize = true };
            var lblDetalle = new Label
            {
                Text = "Franja horaria habilitada para turnos:\n\n• Apertura: 08:00 hs\n• Cierre: 21:00 hs\n• Duración mínima por turno: 15 minutos",
                Left = 15,
                Top = 55,
                AutoSize = true,
                Font = new Font("Segoe UI", 10.5F)
            };
            panelContenidoConf.Controls.AddRange(new Control[] { lblTitulo, lblDetalle });
        }

        // =========================================================
        // 5. GESTIÓN DE SECRETARIOS
        // =========================================================
        private void MostrarGestionSecretarios()
        {
            LimpiarPanelContenido();
            var lblTitulo = new Label { Text = "Gestión de Secretarios", Font = new Font("Segoe UI", 13F, FontStyle.Bold), Left = 15, Top = 10, AutoSize = true };

            var txtNombre = new TextBox { PlaceholderText = "Nombre", Left = 15, Top = 45, Width = 130 };
            var txtApellido = new TextBox { PlaceholderText = "Apellido", Left = 155, Top = 45, Width = 130 };
            var txtDni = new TextBox { PlaceholderText = "DNI", Left = 295, Top = 45, Width = 110 };
            var txtCorreo = new TextBox { PlaceholderText = "Correo", Left = 15, Top = 80, Width = 190 };
            var txtTel = new TextBox { PlaceholderText = "Teléfono", Left = 215, Top = 80, Width = 130 };
            var txtPass = new TextBox { PlaceholderText = "Contraseña inicial", Left = 355, Top = 80, Width = 140, UseSystemPasswordChar = true };
            var btnRegistrar = new Button { Text = "Registrar", Left = 505, Top = 45, Width = 75, Height = 62 };

            var dgv = new DataGridView
            {
                Left = 15,
                Top = 120,
                Width = 565,
                Height = 245,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            var btnEstado = new Button { Text = "Activar / Dar de baja secretario", Left = 15, Top = 378, Width = 230, Height = 30 };

            void RecargarSecretarios()
            {
                dgv.DataSource = null;
                dgv.DataSource = Servicios.Usuarios.ObtenerSecretarios()
                    .Select(s => new { s.Id, s.NombreCompleto, s.DNI, s.Correo, s.Telefono, Estado = s.Activo ? "Activo" : "Inactivo" })
                    .ToList();
                if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
            }

            btnRegistrar.Click += (s, e) =>
            {
                try
                {
                    var nuevo = new Secretario
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        DNI = txtDni.Text,
                        Correo = txtCorreo.Text,
                        Telefono = txtTel.Text
                    };
                    nuevo.EstablecerContrasena(txtPass.Text);
                    Servicios.Usuarios.Registrar(nuevo);

                    txtNombre.Clear(); txtApellido.Clear(); txtDni.Clear();
                    txtCorreo.Clear(); txtTel.Clear(); txtPass.Clear();
                    RecargarSecretarios();
                    MessageBox.Show("Secretario registrado correctamente.");
                }
                catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    MessageBox.Show(ex.Message, "No se pudo registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnEstado.Click += (s, e) =>
            {
                if (dgv.CurrentRow == null) return;
                int id = (int)dgv.CurrentRow.Cells["Id"].Value;
                bool estaActivo = dgv.CurrentRow.Cells["Estado"].Value?.ToString() == "Activo";
                Servicios.Usuarios.CambiarEstadoSecretario(id, !estaActivo);
                RecargarSecretarios();
            };

            panelContenidoConf.Controls.AddRange(new Control[] { lblTitulo, txtNombre, txtApellido, txtDni, txtCorreo, txtTel, txtPass, btnRegistrar, dgv, btnEstado });
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