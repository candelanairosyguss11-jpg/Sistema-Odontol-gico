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
            SuspendLayout();
            // 
            // labelTratamientos
            // 
            labelTratamientos.AutoSize = true;
            labelTratamientos.Location = new Point(19, 22);
            labelTratamientos.Name = "labelTratamientos";
            labelTratamientos.Size = new Size(120, 20);
            labelTratamientos.TabIndex = 0;
            labelTratamientos.Text = "Mis tratamientos";
            labelTratamientos.Click += label1_Click;
            // 
            // labelCambiarContrasena
            // 
            labelCambiarContrasena.AutoSize = true;
            labelCambiarContrasena.Location = new Point(19, 63);
            labelCambiarContrasena.Name = "labelCambiarContrasena";
            labelCambiarContrasena.Size = new Size(143, 20);
            labelCambiarContrasena.TabIndex = 1;
            labelCambiarContrasena.Text = "Cambiar Contraseña";
            labelCambiarContrasena.Click += label1_Click_1;
            // 
            // labelMisDatos
            // 
            labelMisDatos.AutoSize = true;
            labelMisDatos.Location = new Point(19, 101);
            labelMisDatos.Name = "labelMisDatos";
            labelMisDatos.Size = new Size(75, 20);
            labelMisDatos.TabIndex = 2;
            labelMisDatos.Text = "Mis Datos";
            // 
            // labelMisHorarios
            // 
            labelMisHorarios.AutoSize = true;
            labelMisHorarios.Location = new Point(19, 140);
            labelMisHorarios.Name = "labelMisHorarios";
            labelMisHorarios.Size = new Size(93, 20);
            labelMisHorarios.TabIndex = 3;
            labelMisHorarios.Text = "Mis Horarios";
            // 
            // labelGestionSecreta
            // 
            labelGestionSecreta.AutoSize = true;
            labelGestionSecreta.Location = new Point(19, 176);
            labelGestionSecreta.Name = "labelGestionSecreta";
            labelGestionSecreta.Size = new Size(157, 20);
            labelGestionSecreta.TabIndex = 4;
            labelGestionSecreta.Text = "Gestión de Secretarios";
            // 
            // FormConfiguracionOdontologo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelGestionSecreta);
            Controls.Add(labelMisHorarios);
            Controls.Add(labelMisDatos);
            Controls.Add(labelCambiarContrasena);
            Controls.Add(labelTratamientos);
            Name = "FormConfiguracionOdontologo";
            Text = "FormConfiguracionOdontologo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTratamientos;
        private Label labelCambiarContrasena;
        private Label labelMisDatos;
        private Label labelMisHorarios;
        private Label labelGestionSecreta;
    }
}