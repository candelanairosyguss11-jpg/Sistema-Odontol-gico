namespace SistemaUI
{
    partial class FormConfiguracionOdontologo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTratamientos = new Label();
            labelCambiarContrasena = new Label();
            labelMisDatos = new Label();
            labelMisHorarios = new Label();
            labelGestionSecreta = new Label();
            panelContenidoConf = new Panel();
            panelMenuConf = new Panel();
            panelMenuConf.SuspendLayout();
            SuspendLayout();
            // 
            // labelTratamientos
            // 
            labelTratamientos.AutoSize = true;
            labelTratamientos.Location = new Point(7, 18);
            labelTratamientos.Name = "labelTratamientos";
            labelTratamientos.Size = new Size(120, 20);
            labelTratamientos.TabIndex = 0;
            labelTratamientos.Text = "Mis tratamientos";
            labelTratamientos.Click += label1_Click;
            // 
            // labelCambiarContrasena
            // 
            labelCambiarContrasena.AutoSize = true;
            labelCambiarContrasena.Location = new Point(7, 60);
            labelCambiarContrasena.Name = "labelCambiarContrasena";
            labelCambiarContrasena.Size = new Size(143, 20);
            labelCambiarContrasena.TabIndex = 1;
            labelCambiarContrasena.Text = "Cambiar Contraseña";
            labelCambiarContrasena.Click += label1_Click_1;
            // 
            // labelMisDatos
            // 
            labelMisDatos.AutoSize = true;
            labelMisDatos.Location = new Point(7, 106);
            labelMisDatos.Name = "labelMisDatos";
            labelMisDatos.Size = new Size(75, 20);
            labelMisDatos.TabIndex = 2;
            labelMisDatos.Text = "Mis Datos";
            // 
            // labelMisHorarios
            // 
            labelMisHorarios.AutoSize = true;
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
            labelGestionSecreta.Location = new Point(7, 192);
            labelGestionSecreta.Name = "labelGestionSecreta";
            labelGestionSecreta.Size = new Size(157, 20);
            labelGestionSecreta.TabIndex = 4;
            labelGestionSecreta.Text = "Gestión de Secretarios";
            // 
            // panelContenidoConf
            // 
            panelContenidoConf.Location = new Point(199, 12);
            panelContenidoConf.Name = "panelContenidoConf";
            panelContenidoConf.Size = new Size(589, 426);
            panelContenidoConf.TabIndex = 5;
            // 
            // panelMenuConf
            // 
            panelMenuConf.Controls.Add(labelTratamientos);
            panelMenuConf.Controls.Add(labelCambiarContrasena);
            panelMenuConf.Controls.Add(labelGestionSecreta);
            panelMenuConf.Controls.Add(labelMisDatos);
            panelMenuConf.Controls.Add(labelMisHorarios);
            panelMenuConf.Location = new Point(12, 12);
            panelMenuConf.Name = "panelMenuConf";
            panelMenuConf.Size = new Size(181, 351);
            panelMenuConf.TabIndex = 6;
            panelMenuConf.Paint += panel2_Paint;
            // 
            // FormConfiguracionOdontologo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMenuConf);
            Controls.Add(panelContenidoConf);
            Name = "FormConfiguracionOdontologo";
            Text = "FormConfiguracionOdontologo";
            Load += FormConfiguracionOdontologo_Load;
            panelMenuConf.ResumeLayout(false);
            panelMenuConf.PerformLayout();
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
    }
}