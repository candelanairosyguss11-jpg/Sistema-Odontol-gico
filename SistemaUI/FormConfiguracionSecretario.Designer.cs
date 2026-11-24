namespace SistemaUI
{
    partial class FormConfiguracionSecretario
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
            panelMenuConf = new Panel();
            labelCambiarContrasena = new Label();
            labelMisDatos = new Label();
            panelContenidoConf = new Panel();

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

            panelMenuConf.SuspendLayout();
            panelContenidoConf.SuspendLayout();
            panelContrasena.SuspendLayout();
            panelDatos.SuspendLayout();
            SuspendLayout();

            // 
            // panelMenuConf
            // 
            panelMenuConf.Controls.Add(labelCambiarContrasena);
            panelMenuConf.Controls.Add(labelMisDatos);
            panelMenuConf.Location = new Point(12, 12);
            panelMenuConf.Name = "panelMenuConf";
            panelMenuConf.Size = new Size(181, 426);
            panelMenuConf.TabIndex = 0;

            labelCambiarContrasena.AutoSize = true;
            labelCambiarContrasena.Cursor = Cursors.Hand;
            labelCambiarContrasena.Location = new Point(7, 24);
            labelCambiarContrasena.Name = "labelCambiarContrasena";
            labelCambiarContrasena.Size = new Size(143, 20);
            labelCambiarContrasena.Text = "Cambiar Contraseña";
            labelCambiarContrasena.Click += labelCambiarContrasena_Click;

            labelMisDatos.AutoSize = true;
            labelMisDatos.Cursor = Cursors.Hand;
            labelMisDatos.Location = new Point(7, 66);
            labelMisDatos.Name = "labelMisDatos";
            labelMisDatos.Size = new Size(75, 20);
            labelMisDatos.Text = "Mis Datos";
            labelMisDatos.Click += labelMisDatos_Click;

            // 
            // panelContenidoConf
            // 
            panelContenidoConf.Controls.Add(panelContrasena);
            panelContenidoConf.Controls.Add(panelDatos);
            panelContenidoConf.Location = new Point(199, 12);
            panelContenidoConf.Name = "panelContenidoConf";
            panelContenidoConf.Size = new Size(589, 426);
            panelContenidoConf.TabIndex = 1;

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

            lblTituloContrasena.AutoSize = true;
            lblTituloContrasena.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloContrasena.Location = new Point(15, 10);
            lblTituloContrasena.Name = "lblTituloContrasena";
            lblTituloContrasena.Text = "Cambiar Contraseña";

            lblPassActual.AutoSize = true;
            lblPassActual.Location = new Point(15, 62);
            lblPassActual.Name = "lblPassActual";
            lblPassActual.Text = "Contraseña actual:";

            txtPassActual.Location = new Point(180, 59);
            txtPassActual.Name = "txtPassActual";
            txtPassActual.Size = new Size(220, 27);
            txtPassActual.UseSystemPasswordChar = true;

            lblPassNueva.AutoSize = true;
            lblPassNueva.Location = new Point(15, 107);
            lblPassNueva.Name = "lblPassNueva";
            lblPassNueva.Text = "Nueva contraseña:";

            txtPassNueva.Location = new Point(180, 104);
            txtPassNueva.Name = "txtPassNueva";
            txtPassNueva.Size = new Size(220, 27);
            txtPassNueva.UseSystemPasswordChar = true;

            lblPassConfirmar.AutoSize = true;
            lblPassConfirmar.Location = new Point(15, 152);
            lblPassConfirmar.Name = "lblPassConfirmar";
            lblPassConfirmar.Text = "Confirmar nueva:";

            txtPassConfirmar.Location = new Point(180, 149);
            txtPassConfirmar.Name = "txtPassConfirmar";
            txtPassConfirmar.Size = new Size(220, 27);
            txtPassConfirmar.UseSystemPasswordChar = true;

            btnGuardarContrasena.Location = new Point(180, 198);
            btnGuardarContrasena.Name = "btnGuardarContrasena";
            btnGuardarContrasena.Size = new Size(220, 34);
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

            lblTituloDatos.AutoSize = true;
            lblTituloDatos.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloDatos.Location = new Point(15, 10);
            lblTituloDatos.Name = "lblTituloDatos";
            lblTituloDatos.Text = "Mis Datos Personales";

            lblInfoUsuario.AutoSize = true;
            lblInfoUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfoUsuario.Location = new Point(15, 52);
            lblInfoUsuario.Name = "lblInfoUsuario";
            lblInfoUsuario.Text = "Secretario/a: - | DNI: -";

            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(15, 97);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Text = "Correo:";

            txtCorreo.Location = new Point(110, 94);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(260, 27);

            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(15, 142);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Text = "Teléfono:";

            txtTelefono.Location = new Point(110, 139);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(260, 27);

            btnGuardarDatos.Location = new Point(110, 188);
            btnGuardarDatos.Name = "btnGuardarDatos";
            btnGuardarDatos.Size = new Size(165, 34);
            btnGuardarDatos.Text = "Guardar cambios";
            btnGuardarDatos.Click += btnGuardarDatos_Click;

            panelContrasena.BringToFront();

            // 
            // FormConfiguracionSecretario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMenuConf);
            Controls.Add(panelContenidoConf);
            Name = "FormConfiguracionSecretario";
            Text = "Configuración - Secretario";
            Load += FormConfiguracionSecretario_Load;

            panelMenuConf.ResumeLayout(false);
            panelMenuConf.PerformLayout();
            panelContenidoConf.ResumeLayout(false);
            panelContrasena.ResumeLayout(false);
            panelContrasena.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuConf;
        private Label labelCambiarContrasena;
        private Label labelMisDatos;
        private Panel panelContenidoConf;

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
    }
}