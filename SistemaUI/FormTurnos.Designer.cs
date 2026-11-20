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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panelMenuTurno = new Panel();
            buttonVolver = new Button();
            panelTurnos = new Panel();
            panelMenuTurno.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 47);
            button1.Name = "button1";
            button1.Size = new Size(204, 54);
            button1.TabIndex = 0;
            button1.Text = "+Agregar nuevo turno";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(0, 107);
            button2.Name = "button2";
            button2.Size = new Size(204, 54);
            button2.TabIndex = 1;
            button2.Text = "Reprogramar turno";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(0, 167);
            button3.Name = "button3";
            button3.Size = new Size(204, 54);
            button3.TabIndex = 2;
            button3.Text = "Cancelar Turno";
            button3.UseVisualStyleBackColor = true;
            // 
            // panelMenuTurno
            // 
            panelMenuTurno.BackColor = Color.LightSkyBlue;
            panelMenuTurno.Controls.Add(buttonVolver);
            panelMenuTurno.Controls.Add(button3);
            panelMenuTurno.Controls.Add(button2);
            panelMenuTurno.Controls.Add(button1);
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

        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panelMenuTurno;
        private Panel panelTurnos;
        private Button buttonVolver;
    }
}