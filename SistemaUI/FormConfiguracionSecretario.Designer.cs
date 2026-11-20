namespace SistemaUI
{
    partial class FormConfiguracionSecretario
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
            labelMisDatos = new Label();
            labelCambiarContrasena = new Label();
            SuspendLayout();
            // 
            // labelMisDatos
            // 
            labelMisDatos.AutoSize = true;
            labelMisDatos.Location = new Point(12, 62);
            labelMisDatos.Name = "labelMisDatos";
            labelMisDatos.Size = new Size(75, 20);
            labelMisDatos.TabIndex = 4;
            labelMisDatos.Text = "Mis Datos";
            // 
            // labelCambiarContrasena
            // 
            labelCambiarContrasena.AutoSize = true;
            labelCambiarContrasena.Location = new Point(12, 24);
            labelCambiarContrasena.Name = "labelCambiarContrasena";
            labelCambiarContrasena.Size = new Size(143, 20);
            labelCambiarContrasena.TabIndex = 3;
            labelCambiarContrasena.Text = "Cambiar Contraseña";
            // 
            // FormConfiguracionSecretario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelMisDatos);
            Controls.Add(labelCambiarContrasena);
            Name = "FormConfiguracionSecretario";
            Text = "FormConfiguracionSecretario";
            Load += FormConfiguracionSecretario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMisDatos;
        private Label labelCambiarContrasena;
    }
}