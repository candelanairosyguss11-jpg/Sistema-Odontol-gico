namespace SistemaUI
{
    partial class FormTurnos
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
            buttonAgregarturno = new Button();
            buttonreprogramarTurno = new Button();
            buttonCancelarTurno = new Button();
            panelMenuTurno = new Panel();
            buttonVolver = new Button();
            panelTurnos = new Panel();
            panelMenuTurno.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAgregarturno
            // 
            buttonAgregarturno.Location = new Point(0, 47);
            buttonAgregarturno.Name = "buttonAgregarturno";
            buttonAgregarturno.Size = new Size(204, 54);
            buttonAgregarturno.TabIndex = 0;
            buttonAgregarturno.Text = "+Agendar";
            buttonAgregarturno.UseVisualStyleBackColor = true;
            buttonAgregarturno.Click += button1_Click;
            // 
            // buttonreprogramarTurno
            // 
            buttonreprogramarTurno.Location = new Point(0, 107);
            buttonreprogramarTurno.Name = "buttonreprogramarTurno";
            buttonreprogramarTurno.Size = new Size(204, 54);
            buttonreprogramarTurno.TabIndex = 1;
            buttonreprogramarTurno.Text = "Reprogramar";
            buttonreprogramarTurno.UseVisualStyleBackColor = true;
            buttonreprogramarTurno.Click += button2_Click;
            // 
            // buttonCancelarTurno
            // 
            buttonCancelarTurno.Location = new Point(0, 167);
            buttonCancelarTurno.Name = "buttonCancelarTurno";
            buttonCancelarTurno.Size = new Size(204, 54);
            buttonCancelarTurno.TabIndex = 2;
            buttonCancelarTurno.Text = "Cancelar";
            buttonCancelarTurno.UseVisualStyleBackColor = true;
            buttonCancelarTurno.Click += buttonCancelarTurno_Click;
            // 
            // panelMenuTurno
            // 
            panelMenuTurno.BackColor = Color.LightSkyBlue;
            panelMenuTurno.Controls.Add(buttonVolver);
            panelMenuTurno.Controls.Add(buttonCancelarTurno);
            panelMenuTurno.Controls.Add(buttonreprogramarTurno);
            panelMenuTurno.Controls.Add(buttonAgregarturno);
            panelMenuTurno.Dock = DockStyle.Left;
            panelMenuTurno.Location = new Point(0, 0);
            panelMenuTurno.Name = "panelMenuTurno";
            panelMenuTurno.Size = new Size(204, 450);
            panelMenuTurno.TabIndex = 3;
            panelMenuTurno.Paint += panel1_Paint;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(12, 5);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(173, 36);
            buttonVolver.TabIndex = 6;
            buttonVolver.Text = "← Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // panelTurnos
            // 
            panelTurnos.Dock = DockStyle.Fill;
            panelTurnos.Location = new Point(204, 0);
            panelTurnos.Name = "panelTurnos";
            panelTurnos.Size = new Size(596, 450);
            panelTurnos.TabIndex = 4;
            panelTurnos.Paint += panelTurnos_Paint;
            // 
            // FormTurnos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(panelTurnos);
            Controls.Add(panelMenuTurno);
            Name = "FormTurnos";
            Text = "Turnos";
            Load += FormTurnos_Load;
            panelMenuTurno.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAgregarturno;
        private Button buttonreprogramarTurno;
        private Button buttonCancelarTurno;
        private Panel panelMenuTurno;
        private Panel panelTurnos;
        private Button buttonVolver;
    }
}