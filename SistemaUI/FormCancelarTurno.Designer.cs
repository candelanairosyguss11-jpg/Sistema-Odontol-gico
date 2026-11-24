namespace SistemaUI
{
    partial class FormCancelarTurno
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
            buttonVolver = new Button();
            panelCancelar = new Panel();
            textDNI = new TextBox();
            buttonBuscarDNI = new Button();
            Button button = new();
            buttonCancelar = button;
            panelCancelar.SuspendLayout();
            SuspendLayout();
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(12, 12);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(136, 36);
            buttonVolver.TabIndex = 6;
            buttonVolver.Text = "← Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // panelCancelar
            // 
            panelCancelar.Controls.Add(buttonCancelar);
            panelCancelar.Controls.Add(textDNI);
            panelCancelar.Controls.Add(buttonBuscarDNI);
            panelCancelar.Location = new Point(153, 64);
            panelCancelar.Name = "panelCancelar";
            panelCancelar.Size = new Size(906, 552);
            panelCancelar.TabIndex = 7;
            // 
            // textDNI
            // 
            textDNI.Location = new Point(115, 20);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(145, 27);
            textDNI.TabIndex = 12;
            // 
            // buttonBuscarDNI
            // 
            buttonBuscarDNI.Location = new Point(15, 17);
            buttonBuscarDNI.Name = "buttonBuscarDNI";
            buttonBuscarDNI.Size = new Size(94, 29);
            buttonBuscarDNI.TabIndex = 11;
            buttonBuscarDNI.Text = "Buscar DNI";
            buttonBuscarDNI.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(686, 509);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(185, 29);
            buttonCancelar.TabIndex = 13;
            buttonCancelar.Text = "Cancelar Turno";
            buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // FormCancelarTurno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1901, 1033);
            Controls.Add(panelCancelar);
            Controls.Add(buttonVolver);
            Name = "FormCancelarTurno";
            Text = "FormCancelarTurno";
            Load += FormCancelarTurno_Load;
            panelCancelar.ResumeLayout(false);
            panelCancelar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonVolver;
        private Panel panelCancelar;
        private TextBox textDNI;
        private Button buttonBuscarDNI;
        private Button buttonCancelar;
    }
}