namespace SistemaUI
{
    partial class FormConfiguracionOdontologo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTratamientos = new Label();
            labelCambiarContrasena = new Label();
            labelMisDatos = new Label();
            labelMisHorarios = new Label();
            labelGestionSecreta = new Label();
            panelMenuConf = new Panel();
            panelContenidoConf = new Panel();
            panelTratamientos = new Panel();
            lblTituloTratamientos = new Label();
            lblNombreTratamiento = new Label();
            txtNombreTratamiento = new TextBox();
            lblDuracionTratamiento = new Label();
            numDuracionTratamiento = new NumericUpDown();
            btnAgregarTratamiento = new Button();
            dgvTratamientos = new DataGridView();
            btnAlternarEstadoTratamiento = new Button();
            panelContrasena = new Panel();
            lblTituloContrasena = new Label();
            lblPassActual = new Label();
            txtPassActual = new TextBox();
            lblPassNueva = new Label();
            txtPassNueva = new TextBox();
            lblPassConfirmar = new Label();
            txtPassConfirmar = new TextBox();
            btnGuardarContrasena = new Button();
            panelDatos = new Panel();
            lblTituloDatos = new Label();
            lblInfoUsuario = new Label();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            btnGuardarDatos = new Button();
            panelHorarios = new Panel();
            lblTituloHorarios = new Label();
            lblDetalleHorarios = new Label();
            panelSecretarios = new Panel();
            lblTituloSecretarios = new Label();
            txtSecNombre = new TextBox();
            txtSecApellido = new TextBox();
            txtSecDni = new TextBox();
            txtSecCorreo = new TextBox();
            txtSecTel = new TextBox();
            txtSecPass = new TextBox();
            btnRegistrarSecretario = new Button();
            dgvSecretarios = new DataGridView();
            btnEstadoSecretario = new Button();
            panelMenuConf.SuspendLayout();
            panelContenidoConf.SuspendLayout();
            panelTratamientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracionTratamiento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTratamientos).BeginInit();
            panelContrasena.SuspendLayout();
            panelDatos.SuspendLayout();
            panelHorarios.SuspendLayout();
            panelSecretarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSecretarios).BeginInit();
            SuspendLayout();
            // 
            // labelTratamientos
            // 
            labelTratamientos.AutoSize = true;
            labelTratamientos.Cursor = Cursors.Hand;
            labelTratamientos.Location = new Point(7, 18);
            labelTratamientos.Name = "labelTratamientos";
            labelTratamientos.Size = new Size(120, 20);
            labelTratamientos.TabIndex = 0;
            labelTratamientos.Text = "Mis tratamientos";
            labelTratamientos.Click += labelTratamientos_Click;
            // 
            // labelCambiarContrasena
            // 
            labelCambiarContrasena.AutoSize = true;
            labelCambiarContrasena.Cursor = Cursors.Hand;
            labelCambiarContrasena.Location = new Point(7, 60);
            labelCambiarContrasena.Name = "labelCambiarContrasena";
            labelCambiarContrasena.Size = new Size(143, 20);
            labelCambiarContrasena.TabIndex = 1;
            labelCambiarContrasena.Text = "Cambiar Contraseña";
            labelCambiarContrasena.Click += labelCambiarContrasena_Click;
            // 
            // labelMisDatos
            // 
            labelMisDatos.AutoSize = true;
            labelMisDatos.Cursor = Cursors.Hand;
            labelMisDatos.Location = new Point(7, 106);
            labelMisDatos.Name = "labelMisDatos";
            labelMisDatos.Size = new Size(75, 20);
            labelMisDatos.TabIndex = 2;
            labelMisDatos.Text = "Mis Datos";
            labelMisDatos.Click += labelMisDatos_Click;
            // 
            // labelMisHorarios
            // 
            labelMisHorarios.AutoSize = true;
            labelMisHorarios.Cursor = Cursors.Hand;
            labelMisHorarios.Location = new Point(7, 149);
            labelMisHorarios.Name = "labelMisHorarios";
            labelMisHorarios.Size = new Size(93, 20);
            labelMisHorarios.TabIndex = 3;
            labelMisHorarios.Text = "Mis Horarios";
            labelMisHorarios.Click += labelMisHorarios_Click;
            // 
            // labelGestionSecreta
            // 
            labelGestionSecreta.AutoSize = true;
            labelGestionSecreta.Cursor = Cursors.Hand;
            labelGestionSecreta.Location = new Point(7, 192);
            labelGestionSecreta.Name = "labelGestionSecreta";
            labelGestionSecreta.Size = new Size(157, 20);
            labelGestionSecreta.TabIndex = 4;
            labelGestionSecreta.Text = "Gestión de Secretarios";
            labelGestionSecreta.Click += labelGestionSecreta_Click;
            // 
            // panelMenuConf
            // 
            panelMenuConf.Controls.Add(labelTratamientos);
            panelMenuConf.Controls.Add(labelCambiarContrasena);
            panelMenuConf.Controls.Add(labelMisDatos);
            panelMenuConf.Controls.Add(labelMisHorarios);
            panelMenuConf.Controls.Add(labelGestionSecreta);
            panelMenuConf.Location = new Point(12, 12);
            panelMenuConf.Name = "panelMenuConf";
            panelMenuConf.Size = new Size(181, 426);
            panelMenuConf.TabIndex = 0;
            // 
            // panelContenidoConf
            // 
            panelContenidoConf.Controls.Add(panelTratamientos);
            panelContenidoConf.Controls.Add(panelContrasena);
            panelContenidoConf.Controls.Add(panelDatos);
            panelContenidoConf.Controls.Add(panelHorarios);
            panelContenidoConf.Controls.Add(panelSecretarios);
            panelContenidoConf.Location = new Point(199, 12);
            panelContenidoConf.Name = "panelContenidoConf";
            panelContenidoConf.Size = new Size(589, 426);
            panelContenidoConf.TabIndex = 1;
            // 
            // panelTratamientos
            // 
            panelTratamientos.Controls.Add(lblTituloTratamientos);
            panelTratamientos.Controls.Add(lblNombreTratamiento);
            panelTratamientos.Controls.Add(txtNombreTratamiento);
            panelTratamientos.Controls.Add(lblDuracionTratamiento);
            panelTratamientos.Controls.Add(numDuracionTratamiento);
            panelTratamientos.Controls.Add(btnAgregarTratamiento);
            panelTratamientos.Controls.Add(dgvTratamientos);
            panelTratamientos.Controls.Add(btnAlternarEstadoTratamiento);
            panelTratamientos.Dock = DockStyle.Fill;
            panelTratamientos.Location = new Point(0, 0);
            panelTratamientos.Name = "panelTratamientos";
            panelTratamientos.Size = new Size(589, 426);
            panelTratamientos.TabIndex = 0;
            // 
            // lblTituloTratamientos
            // 
            lblTituloTratamientos.AutoSize = true;
            lblTituloTratamientos.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloTratamientos.Location = new Point(15, 10);
            lblTituloTratamientos.Name = "lblTituloTratamientos";
            lblTituloTratamientos.Size = new Size(192, 30);
            lblTituloTratamientos.TabIndex = 0;
            lblTituloTratamientos.Text = "Mis Tratamientos";
            // 
            // lblNombreTratamiento
            // 
            lblNombreTratamiento.AutoSize = true;
            lblNombreTratamiento.Location = new Point(15, 52);
            lblNombreTratamiento.Name = "lblNombreTratamiento";
            lblNombreTratamiento.Size = new Size(67, 20);
            lblNombreTratamiento.TabIndex = 1;
            lblNombreTratamiento.Text = "Nombre:";
            // 
            // txtNombreTratamiento
            // 
            txtNombreTratamiento.Location = new Point(82, 49);
            txtNombreTratamiento.Name = "txtNombreTratamiento";
            txtNombreTratamiento.Size = new Size(195, 27);
            txtNombreTratamiento.TabIndex = 2;
            // 
            // lblDuracionTratamiento
            // 
            lblDuracionTratamiento.AutoSize = true;
            lblDuracionTratamiento.Location = new Point(290, 52);
            lblDuracionTratamiento.Name = "lblDuracionTratamiento";
            lblDuracionTratamiento.Size = new Size(111, 20);
            lblDuracionTratamiento.TabIndex = 3;
            lblDuracionTratamiento.Text = "Duración (min):";
            // 
            // numDuracionTratamiento
            // 
            numDuracionTratamiento.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            numDuracionTratamiento.Location = new Point(405, 49);
            numDuracionTratamiento.Maximum = new decimal(new int[] { 240, 0, 0, 0 });
            numDuracionTratamiento.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numDuracionTratamiento.Name = "numDuracionTratamiento";
            numDuracionTratamiento.Size = new Size(65, 27);
            numDuracionTratamiento.TabIndex = 4;
            numDuracionTratamiento.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // btnAgregarTratamiento
            // 
            btnAgregarTratamiento.Location = new Point(485, 47);
            btnAgregarTratamiento.Name = "btnAgregarTratamiento";
            btnAgregarTratamiento.Size = new Size(88, 29);
            btnAgregarTratamiento.TabIndex = 5;
            btnAgregarTratamiento.Text = "Agregar";
            btnAgregarTratamiento.Click += btnAgregarTratamiento_Click;
            // 
            // dgvTratamientos
            // 
            dgvTratamientos.AllowUserToAddRows = false;
            dgvTratamientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTratamientos.BackgroundColor = Color.White;
            dgvTratamientos.ColumnHeadersHeight = 29;
            dgvTratamientos.Location = new Point(15, 90);
            dgvTratamientos.MultiSelect = false;
            dgvTratamientos.Name = "dgvTratamientos";
            dgvTratamientos.ReadOnly = true;
            dgvTratamientos.RowHeadersVisible = false;
            dgvTratamientos.RowHeadersWidth = 51;
            dgvTratamientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTratamientos.Size = new Size(558, 275);
            dgvTratamientos.TabIndex = 6;
            // 
            // btnAlternarEstadoTratamiento
            // 
            btnAlternarEstadoTratamiento.Location = new Point(15, 378);
            btnAlternarEstadoTratamiento.Name = "btnAlternarEstadoTratamiento";
            btnAlternarEstadoTratamiento.Size = new Size(240, 32);
            btnAlternarEstadoTratamiento.TabIndex = 7;
            btnAlternarEstadoTratamiento.Text = "Activar / Desactivar seleccionado";
            btnAlternarEstadoTratamiento.Click += btnAlternarEstadoTratamiento_Click;
            // 
            // panelContrasena
            // 
            panelContrasena.Controls.Add(lblTituloContrasena);
            panelContrasena.Controls.Add(lblPassActual);
            panelContrasena.Controls.Add(txtPassActual);
            panelContrasena.Controls.Add(lblPassNueva);
            panelContrasena.Controls.Add(txtPassNueva);
            panelContrasena.Controls.Add(lblPassConfirmar);
            panelContrasena.Controls.Add(txtPassConfirmar);
            panelContrasena.Controls.Add(btnGuardarContrasena);
            panelContrasena.Dock = DockStyle.Fill;
            panelContrasena.Location = new Point(0, 0);
            panelContrasena.Name = "panelContrasena";
            panelContrasena.Size = new Size(589, 426);
            panelContrasena.TabIndex = 1;
            // 
            // lblTituloContrasena
            // 
            lblTituloContrasena.AutoSize = true;
            lblTituloContrasena.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloContrasena.Location = new Point(15, 10);
            lblTituloContrasena.Name = "lblTituloContrasena";
            lblTituloContrasena.Size = new Size(223, 30);
            lblTituloContrasena.TabIndex = 0;
            lblTituloContrasena.Text = "Cambiar Contraseña";
            // 
            // lblPassActual
            // 
            lblPassActual.AutoSize = true;
            lblPassActual.Location = new Point(15, 62);
            lblPassActual.Name = "lblPassActual";
            lblPassActual.Size = new Size(130, 20);
            lblPassActual.TabIndex = 1;
            lblPassActual.Text = "Contraseña actual:";
            // 
            // txtPassActual
            // 
            txtPassActual.Location = new Point(180, 59);
            txtPassActual.Name = "txtPassActual";
            txtPassActual.Size = new Size(220, 27);
            txtPassActual.TabIndex = 2;
            txtPassActual.UseSystemPasswordChar = true;
            // 
            // lblPassNueva
            // 
            lblPassNueva.AutoSize = true;
            lblPassNueva.Location = new Point(15, 107);
            lblPassNueva.Name = "lblPassNueva";
            lblPassNueva.Size = new Size(130, 20);
            lblPassNueva.TabIndex = 3;
            lblPassNueva.Text = "Nueva contraseña:";
            // 
            // txtPassNueva
            // 
            txtPassNueva.Location = new Point(180, 104);
            txtPassNueva.Name = "txtPassNueva";
            txtPassNueva.Size = new Size(220, 27);
            txtPassNueva.TabIndex = 4;
            txtPassNueva.UseSystemPasswordChar = true;
            // 
            // lblPassConfirmar
            // 
            lblPassConfirmar.AutoSize = true;
            lblPassConfirmar.Location = new Point(15, 152);
            lblPassConfirmar.Name = "lblPassConfirmar";
            lblPassConfirmar.Size = new Size(121, 20);
            lblPassConfirmar.TabIndex = 5;
            lblPassConfirmar.Text = "Confirmar nueva:";
            // 
            // txtPassConfirmar
            // 
            txtPassConfirmar.Location = new Point(180, 149);
            txtPassConfirmar.Name = "txtPassConfirmar";
            txtPassConfirmar.Size = new Size(220, 27);
            txtPassConfirmar.TabIndex = 6;
            txtPassConfirmar.UseSystemPasswordChar = true;
            // 
            // btnGuardarContrasena
            // 
            btnGuardarContrasena.Location = new Point(180, 198);
            btnGuardarContrasena.Name = "btnGuardarContrasena";
            btnGuardarContrasena.Size = new Size(220, 34);
            btnGuardarContrasena.TabIndex = 7;
            btnGuardarContrasena.Text = "Actualizar contraseña";
            btnGuardarContrasena.Click += btnGuardarContrasena_Click;
            // 
            // panelDatos
            // 
            panelDatos.Controls.Add(lblTituloDatos);
            panelDatos.Controls.Add(lblInfoUsuario);
            panelDatos.Controls.Add(lblCorreo);
            panelDatos.Controls.Add(txtCorreo);
            panelDatos.Controls.Add(lblTelefono);
            panelDatos.Controls.Add(txtTelefono);
            panelDatos.Controls.Add(btnGuardarDatos);
            panelDatos.Dock = DockStyle.Fill;
            panelDatos.Location = new Point(0, 0);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(589, 426);
            panelDatos.TabIndex = 2;
            // 
            // lblTituloDatos
            // 
            lblTituloDatos.AutoSize = true;
            lblTituloDatos.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloDatos.Location = new Point(15, 10);
            lblTituloDatos.Name = "lblTituloDatos";
            lblTituloDatos.Size = new Size(232, 30);
            lblTituloDatos.TabIndex = 0;
            lblTituloDatos.Text = "Mis Datos Personales";
            // 
            // lblInfoUsuario
            // 
            lblInfoUsuario.AutoSize = true;
            lblInfoUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfoUsuario.Location = new Point(15, 52);
            lblInfoUsuario.Name = "lblInfoUsuario";
            lblInfoUsuario.Size = new Size(188, 23);
            lblInfoUsuario.TabIndex = 1;
            lblInfoUsuario.Text = "Odontólogo: - | DNI: -";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(15, 97);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(57, 20);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(110, 94);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(260, 27);
            txtCorreo.TabIndex = 3;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(15, 142);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(70, 20);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(110, 139);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(260, 27);
            txtTelefono.TabIndex = 5;
            // 
            // btnGuardarDatos
            // 
            btnGuardarDatos.Location = new Point(110, 188);
            btnGuardarDatos.Name = "btnGuardarDatos";
            btnGuardarDatos.Size = new Size(165, 34);
            btnGuardarDatos.TabIndex = 6;
            btnGuardarDatos.Text = "Guardar cambios";
            btnGuardarDatos.Click += btnGuardarDatos_Click;
            // 
            // panelHorarios
            // 
            panelHorarios.Controls.Add(lblTituloHorarios);
            panelHorarios.Controls.Add(lblDetalleHorarios);
            panelHorarios.Dock = DockStyle.Fill;
            panelHorarios.Location = new Point(0, 0);
            panelHorarios.Name = "panelHorarios";
            panelHorarios.Size = new Size(589, 426);
            panelHorarios.TabIndex = 3;
            // 
            // lblTituloHorarios
            // 
            lblTituloHorarios.AutoSize = true;
            lblTituloHorarios.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloHorarios.Location = new Point(15, 10);
            lblTituloHorarios.Name = "lblTituloHorarios";
            lblTituloHorarios.Size = new Size(395, 30);
            lblTituloHorarios.TabIndex = 0;
            lblTituloHorarios.Text = "Horarios de Atención del Consultorio";
            // 
            // lblDetalleHorarios
            // 
            lblDetalleHorarios.AutoSize = true;
            lblDetalleHorarios.Font = new Font("Segoe UI", 10.5F);
            lblDetalleHorarios.Location = new Point(15, 58);
            lblDetalleHorarios.Name = "lblDetalleHorarios";
            lblDetalleHorarios.Size = new Size(339, 125);
            lblDetalleHorarios.TabIndex = 1;
            lblDetalleHorarios.Text = "Franja horaria habilitada para turnos:\r\n\r\n• Apertura: 08:00 hs\r\n• Cierre: 21:00 hs\r\n• Duración mínima por turno: 15 minutos";
            // 
            // panelSecretarios
            // 
            panelSecretarios.Controls.Add(lblTituloSecretarios);
            panelSecretarios.Controls.Add(txtSecNombre);
            panelSecretarios.Controls.Add(txtSecApellido);
            panelSecretarios.Controls.Add(txtSecDni);
            panelSecretarios.Controls.Add(txtSecCorreo);
            panelSecretarios.Controls.Add(txtSecTel);
            panelSecretarios.Controls.Add(txtSecPass);
            panelSecretarios.Controls.Add(btnRegistrarSecretario);
            panelSecretarios.Controls.Add(dgvSecretarios);
            panelSecretarios.Controls.Add(btnEstadoSecretario);
            panelSecretarios.Dock = DockStyle.Fill;
            panelSecretarios.Location = new Point(0, 0);
            panelSecretarios.Name = "panelSecretarios";
            panelSecretarios.Size = new Size(589, 426);
            panelSecretarios.TabIndex = 4;
            // 
            // lblTituloSecretarios
            // 
            lblTituloSecretarios.AutoSize = true;
            lblTituloSecretarios.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloSecretarios.Location = new Point(15, 10);
            lblTituloSecretarios.Name = "lblTituloSecretarios";
            lblTituloSecretarios.Size = new Size(245, 30);
            lblTituloSecretarios.TabIndex = 0;
            lblTituloSecretarios.Text = "Gestión de Secretarios";
            // 
            // txtSecNombre
            // 
            txtSecNombre.Location = new Point(15, 45);
            txtSecNombre.Name = "txtSecNombre";
            txtSecNombre.PlaceholderText = "Nombre";
            txtSecNombre.Size = new Size(130, 27);
            txtSecNombre.TabIndex = 1;
            // 
            // txtSecApellido
            // 
            txtSecApellido.Location = new Point(155, 45);
            txtSecApellido.Name = "txtSecApellido";
            txtSecApellido.PlaceholderText = "Apellido";
            txtSecApellido.Size = new Size(130, 27);
            txtSecApellido.TabIndex = 2;
            // 
            // txtSecDni
            // 
            txtSecDni.Location = new Point(295, 45);
            txtSecDni.Name = "txtSecDni";
            txtSecDni.PlaceholderText = "DNI";
            txtSecDni.Size = new Size(110, 27);
            txtSecDni.TabIndex = 3;
            // 
            // txtSecCorreo
            // 
            txtSecCorreo.Location = new Point(15, 80);
            txtSecCorreo.Name = "txtSecCorreo";
            txtSecCorreo.PlaceholderText = "Correo";
            txtSecCorreo.Size = new Size(185, 27);
            txtSecCorreo.TabIndex = 4;
            // 
            // txtSecTel
            // 
            txtSecTel.Location = new Point(210, 80);
            txtSecTel.Name = "txtSecTel";
            txtSecTel.PlaceholderText = "Teléfono";
            txtSecTel.Size = new Size(130, 27);
            txtSecTel.TabIndex = 5;
            // 
            // txtSecPass
            // 
            txtSecPass.Location = new Point(350, 80);
            txtSecPass.Name = "txtSecPass";
            txtSecPass.PlaceholderText = "Contraseña";
            txtSecPass.Size = new Size(140, 27);
            txtSecPass.TabIndex = 6;
            txtSecPass.UseSystemPasswordChar = true;
            // 
            // btnRegistrarSecretario
            // 
            btnRegistrarSecretario.Location = new Point(496, 41);
            btnRegistrarSecretario.Name = "btnRegistrarSecretario";
            btnRegistrarSecretario.Size = new Size(79, 35);
            btnRegistrarSecretario.TabIndex = 7;
            btnRegistrarSecretario.Text = "Registrar";
            btnRegistrarSecretario.Click += btnRegistrarSecretario_Click;
            // 
            // dgvSecretarios
            // 
            dgvSecretarios.AllowUserToAddRows = false;
            dgvSecretarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSecretarios.BackgroundColor = Color.White;
            dgvSecretarios.ColumnHeadersHeight = 29;
            dgvSecretarios.Location = new Point(15, 120);
            dgvSecretarios.MultiSelect = false;
            dgvSecretarios.Name = "dgvSecretarios";
            dgvSecretarios.ReadOnly = true;
            dgvSecretarios.RowHeadersVisible = false;
            dgvSecretarios.RowHeadersWidth = 51;
            dgvSecretarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSecretarios.Size = new Size(560, 245);
            dgvSecretarios.TabIndex = 8;
            // 
            // btnEstadoSecretario
            // 
            btnEstadoSecretario.Location = new Point(15, 378);
            btnEstadoSecretario.Name = "btnEstadoSecretario";
            btnEstadoSecretario.Size = new Size(240, 32);
            btnEstadoSecretario.TabIndex = 9;
            btnEstadoSecretario.Text = "Activar / Dar de baja secretario";
            btnEstadoSecretario.Click += btnEstadoSecretario_Click;
            // 
            // FormConfiguracionOdontologo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMenuConf);
            Controls.Add(panelContenidoConf);
            Name = "FormConfiguracionOdontologo";
            Text = "Configuración - Odontólogo";
            Load += FormConfiguracionOdontologo_Load;
            panelMenuConf.ResumeLayout(false);
            panelMenuConf.PerformLayout();
            panelContenidoConf.ResumeLayout(false);
            panelTratamientos.ResumeLayout(false);
            panelTratamientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracionTratamiento).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTratamientos).EndInit();
            panelContrasena.ResumeLayout(false);
            panelContrasena.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelHorarios.ResumeLayout(false);
            panelHorarios.PerformLayout();
            panelSecretarios.ResumeLayout(false);
            panelSecretarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSecretarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelTratamientos;
        private Label labelCambiarContrasena;
        private Label labelMisDatos;
        private Label labelMisHorarios;
        private Label labelGestionSecreta;
        private Panel panelContenidoConf;
        private Panel panelMenuConf;

        private Panel panelTratamientos;
        private Label lblTituloTratamientos;
        private Label lblNombreTratamiento;
        private TextBox txtNombreTratamiento;
        private Label lblDuracionTratamiento;
        private NumericUpDown numDuracionTratamiento;
        private Button btnAgregarTratamiento;
        private DataGridView dgvTratamientos;
        private Button btnAlternarEstadoTratamiento;

        private Panel panelContrasena;
        private Label lblTituloContrasena;
        private Label lblPassActual;
        private TextBox txtPassActual;
        private Label lblPassNueva;
        private TextBox txtPassNueva;
        private Label lblPassConfirmar;
        private TextBox txtPassConfirmar;
        private Button btnGuardarContrasena;

        private Panel panelDatos;
        private Label lblTituloDatos;
        private Label lblInfoUsuario;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Button btnGuardarDatos;

        private Panel panelHorarios;
        private Label lblTituloHorarios;
        private Label lblDetalleHorarios;

        private Panel panelSecretarios;
        private Label lblTituloSecretarios;
        private TextBox txtSecNombre;
        private TextBox txtSecApellido;
        private TextBox txtSecDni;
        private TextBox txtSecCorreo;
        private TextBox txtSecTel;
        private TextBox txtSecPass;
        private Button btnRegistrarSecretario;
        private DataGridView dgvSecretarios;
        private Button btnEstadoSecretario;
    }
}