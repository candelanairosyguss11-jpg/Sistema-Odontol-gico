namespace SistemaUI
{
    partial class FormReprogramarTurno
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
            textDNI = new TextBox();
            buttonBuscarDNI = new Button();
            panelReprogramar = new Panel();
            buttonReprogramar = new Button();
            panelReprogramar.SuspendLayout();
            SuspendLayout();
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(23, 12);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(136, 36);
            buttonVolver.TabIndex = 6;
            buttonVolver.Text = "← Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
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
            buttonBuscarDNI.Click += buttonBuscarDNI_Click;
            // 
            // panelReprogramar
            // 
            panelReprogramar.Controls.Add(buttonReprogramar);
            panelReprogramar.Controls.Add(textDNI);
            panelReprogramar.Controls.Add(buttonBuscarDNI);
            panelReprogramar.Location = new Point(180, 52);
            panelReprogramar.Name = "panelReprogramar";
            panelReprogramar.Size = new Size(906, 552);
            panelReprogramar.TabIndex = 8;
            panelReprogramar.Paint += panel1_Paint;
            // 
            // buttonReprogramar
            // 
            buttonReprogramar.Location = new Point(617, 506);
            buttonReprogramar.Name = "buttonReprogramar";
            buttonReprogramar.Size = new Size(258, 29);
            buttonReprogramar.TabIndex = 13;
            buttonReprogramar.Text = "Reprogramar";
            buttonReprogramar.UseVisualStyleBackColor = true;
            buttonReprogramar.Click += buttonReprogramar_Click;
            // 
            // FormReprogramarTurno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 984);
            Controls.Add(panelReprogramar);
            Controls.Add(buttonVolver);
            Name = "FormReprogramarTurno";
            Text = "FormReprogramarTurno";
            Load += FormReprogramarTurno_Load;
            panelReprogramar.ResumeLayout(false);
            panelReprogramar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonVolver;
        private TextBox textDNI;
        private Button buttonBuscarDNI;
        private Panel panelReprogramar;
        private Button buttonReprogramar;
    }
}