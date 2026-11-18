namespace SistemaUI
{
    partial class FormHistoriasClinicas
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
            MenuHistoriasC = new Panel();
            buttonVolver = new Button();
            buttonObservaciones = new Button();
            buttonConsentimientos = new Button();
            buttonEstudios = new Button();
            buttonOdontograma = new Button();
            buttonDatos = new Button();
            panelHC = new Panel();
            MenuHistoriasC.SuspendLayout();
            SuspendLayout();
            // 
            // MenuHistoriasC
            // 
            MenuHistoriasC.BackColor = Color.LightSkyBlue;
            MenuHistoriasC.Controls.Add(buttonVolver);
            MenuHistoriasC.Controls.Add(buttonObservaciones);
            MenuHistoriasC.Controls.Add(buttonConsentimientos);
            MenuHistoriasC.Controls.Add(buttonEstudios);
            MenuHistoriasC.Controls.Add(buttonOdontograma);
            MenuHistoriasC.Controls.Add(buttonDatos);
            MenuHistoriasC.Dock = DockStyle.Left;
            MenuHistoriasC.Location = new Point(0, 0);
            MenuHistoriasC.Name = "MenuHistoriasC";
            MenuHistoriasC.Size = new Size(133, 450);
            MenuHistoriasC.TabIndex = 0;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(3, 12);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(123, 36);
            buttonVolver.TabIndex = 5;
            buttonVolver.Text = "← Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // buttonObservaciones
            // 
            buttonObservaciones.Location = new Point(3, 382);
            buttonObservaciones.Name = "buttonObservaciones";
            buttonObservaciones.Size = new Size(123, 68);
            buttonObservaciones.TabIndex = 4;
            buttonObservaciones.Text = "Observaciones";
            buttonObservaciones.UseVisualStyleBackColor = true;
            buttonObservaciones.Click += buttonObservaciones_Click;
            // 
            // buttonConsentimientos
            // 
            buttonConsentimientos.Location = new Point(3, 308);
            buttonConsentimientos.Name = "buttonConsentimientos";
            buttonConsentimientos.Size = new Size(123, 68);
            buttonConsentimientos.TabIndex = 3;
            buttonConsentimientos.Text = "Consentimiento Informado";
            buttonConsentimientos.UseVisualStyleBackColor = true;
            buttonConsentimientos.Click += buttonConsentimientos_Click;
            // 
            // buttonEstudios
            // 
            buttonEstudios.Location = new Point(3, 232);
            buttonEstudios.Name = "buttonEstudios";
            buttonEstudios.Size = new Size(123, 70);
            buttonEstudios.TabIndex = 2;
            buttonEstudios.Text = "Estudios";
            buttonEstudios.UseVisualStyleBackColor = true;
            buttonEstudios.Click += buttonEstudios_Click;
            // 
            // buttonOdontograma
            // 
            buttonOdontograma.Location = new Point(3, 150);
            buttonOdontograma.Name = "buttonOdontograma";
            buttonOdontograma.Size = new Size(123, 76);
            buttonOdontograma.TabIndex = 1;
            buttonOdontograma.Text = "Odontograma";
            buttonOdontograma.UseVisualStyleBackColor = true;
            buttonOdontograma.Click += buttonOdontograma_Click;
            // 
            // buttonDatos
            // 
            buttonDatos.Location = new Point(3, 64);
            buttonDatos.Name = "buttonDatos";
            buttonDatos.Size = new Size(123, 80);
            buttonDatos.TabIndex = 0;
            buttonDatos.Text = "Datos";
            buttonDatos.UseVisualStyleBackColor = true;
            buttonDatos.Click += buttonDatos_Click;
            // 
            // panelHC
            // 
            panelHC.BackColor = SystemColors.GradientActiveCaption;
            panelHC.Dock = DockStyle.Fill;
            panelHC.Location = new Point(133, 0);
            panelHC.Name = "panelHC";
            panelHC.Size = new Size(667, 450);
            panelHC.TabIndex = 1;
            panelHC.Paint += panelHC_Paint;
            // 
            // FormHistoriasClinicas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(panelHC);
            Controls.Add(MenuHistoriasC);
            Name = "FormHistoriasClinicas";
            Text = "Historias Clínicas";
            Load += FormHistoriasClinicas_Load;
            MenuHistoriasC.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MenuHistoriasC;
        private Button buttonObservaciones;
        private Button buttonConsentimientos;
        private Button buttonEstudios;
        private Button buttonOdontograma;
        private Button buttonDatos;
        private Button buttonVolver;
        private Panel panelHC;
    }
}