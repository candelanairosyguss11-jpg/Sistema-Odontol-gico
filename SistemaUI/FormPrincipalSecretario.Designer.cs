namespace SistemaUI
{
    partial class FormPrincipalSecretario
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
            panelMenu = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            buttonCerrar = new Button();
            buttonTurnos = new Button();
            buttonInicio = new Button();
            panelContenido = new Panel();
            button4 = new Button();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.LightSkyBlue;
            panelMenu.Controls.Add(button4);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(button2);
            panelMenu.Controls.Add(button1);
            panelMenu.Controls.Add(buttonCerrar);
            panelMenu.Controls.Add(buttonTurnos);
            panelMenu.Controls.Add(buttonInicio);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(250, 450);
            panelMenu.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.MidnightBlue;
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderColor = Color.MidnightBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 230);
            button3.Name = "button3";
            button3.Size = new Size(250, 67);
            button3.TabIndex = 9;
            button3.Text = "📒Agenda Viviana";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.MidnightBlue;
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderColor = Color.MidnightBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(0, 163);
            button2.Name = "button2";
            button2.Size = new Size(250, 67);
            button2.TabIndex = 8;
            button2.Text = "📒Agenda Christian";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderColor = Color.MidnightBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 96);
            button1.Name = "button1";
            button1.Size = new Size(250, 67);
            button1.TabIndex = 7;
            button1.Text = "📒Agenda Ariel";
            button1.UseVisualStyleBackColor = false;
            // 
            // buttonCerrar
            // 
            buttonCerrar.BackColor = Color.MidnightBlue;
            buttonCerrar.Dock = DockStyle.Bottom;
            buttonCerrar.FlatAppearance.BorderColor = Color.MediumBlue;
            buttonCerrar.FlatStyle = FlatStyle.Flat;
            buttonCerrar.ForeColor = Color.White;
            buttonCerrar.Location = new Point(0, 421);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(250, 29);
            buttonCerrar.TabIndex = 6;
            buttonCerrar.Text = "↩ Cerrar sesión";
            buttonCerrar.UseVisualStyleBackColor = false;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // buttonTurnos
            // 
            buttonTurnos.BackColor = Color.MidnightBlue;
            buttonTurnos.Dock = DockStyle.Top;
            buttonTurnos.FlatAppearance.BorderColor = Color.MidnightBlue;
            buttonTurnos.FlatStyle = FlatStyle.Flat;
            buttonTurnos.ForeColor = Color.White;
            buttonTurnos.Location = new Point(0, 29);
            buttonTurnos.Name = "buttonTurnos";
            buttonTurnos.Size = new Size(250, 67);
            buttonTurnos.TabIndex = 5;
            buttonTurnos.Text = "🗓️Turnos";
            buttonTurnos.UseVisualStyleBackColor = false;
            buttonTurnos.Click += buttonTurnos_Click;
            // 
            // buttonInicio
            // 
            buttonInicio.BackColor = Color.MidnightBlue;
            buttonInicio.Dock = DockStyle.Top;
            buttonInicio.FlatAppearance.BorderColor = Color.MidnightBlue;
            buttonInicio.FlatAppearance.BorderSize = 0;
            buttonInicio.FlatStyle = FlatStyle.Flat;
            buttonInicio.ForeColor = Color.White;
            buttonInicio.Location = new Point(0, 0);
            buttonInicio.Name = "buttonInicio";
            buttonInicio.Size = new Size(250, 29);
            buttonInicio.TabIndex = 1;
            buttonInicio.Text = "ℹ️Inicio";
            buttonInicio.UseVisualStyleBackColor = false;
            buttonInicio.Click += buttonInicio_Click;
            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.BackColor = Color.WhiteSmoke;
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(250, 0);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(550, 450);
            panelContenido.TabIndex = 8;
            panelContenido.Paint += panelContenido_Paint;
            // 
            // button4
            // 
            button4.BackColor = Color.MidnightBlue;
            button4.Dock = DockStyle.Bottom;
            button4.FlatAppearance.BorderColor = Color.MediumBlue;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 392);
            button4.Name = "button4";
            button4.Size = new Size(250, 29);
            button4.TabIndex = 10;
            button4.Text = "☰ Configuración";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // FormPrincipalSecretario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenido);
            Controls.Add(panelMenu);
            Name = "FormPrincipalSecretario";
            Text = "FormPrincipalSecretaria";
            WindowState = FormWindowState.Maximized;
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        public Panel panelMenu;
        private Button buttonInicio;
        private Button buttonTurnos;
        private Button buttonCerrar;
        private Panel panelContenido;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button4;
    }
}