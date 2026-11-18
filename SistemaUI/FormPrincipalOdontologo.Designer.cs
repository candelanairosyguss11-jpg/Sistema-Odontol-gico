namespace SistemaUI
{
    partial class FormPrincipalOdontologo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelContenido = new Panel();
            panelMenu = new Panel();
            buttonHistoriaC = new Button();
            buttonCerrar = new Button();
            buttonTurnos = new Button();
            buttonInicio = new Button();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.BackColor = Color.WhiteSmoke;
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(220, 0);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(580, 450);
            panelContenido.TabIndex = 1;
            panelContenido.Paint += PanelContenido_Paint_1;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(38, 54, 74);
            panelMenu.Controls.Add(buttonHistoriaC);
            panelMenu.Controls.Add(buttonCerrar);
            panelMenu.Controls.Add(buttonTurnos);
            panelMenu.Controls.Add(buttonInicio);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 450);
            panelMenu.TabIndex = 0;
            // 
            // buttonHistoriaC
            // 
            buttonHistoriaC.BackColor = Color.MidnightBlue;
            buttonHistoriaC.Dock = DockStyle.Top;
            buttonHistoriaC.FlatAppearance.BorderColor = Color.MidnightBlue;
            buttonHistoriaC.FlatStyle = FlatStyle.Flat;
            buttonHistoriaC.ForeColor = Color.White;
            buttonHistoriaC.Location = new Point(0, 96);
            buttonHistoriaC.Name = "buttonHistoriaC";
            buttonHistoriaC.Size = new Size(220, 67);
            buttonHistoriaC.TabIndex = 6;
            buttonHistoriaC.Text = "📋Historias Clínicas";
            buttonHistoriaC.UseVisualStyleBackColor = false;
            buttonHistoriaC.Click += Button3HC_Click_1;
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
            buttonCerrar.Size = new Size(220, 29);
            buttonCerrar.TabIndex = 5;
            buttonCerrar.Text = "↩ Cerrar sesión";
            buttonCerrar.UseVisualStyleBackColor = false;
            buttonCerrar.Click += buttonCerrar_Click_1;
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
            buttonTurnos.Size = new Size(220, 67);
            buttonTurnos.TabIndex = 4;
            buttonTurnos.Text = "🗓️Turnos";
            buttonTurnos.UseVisualStyleBackColor = false;
            buttonTurnos.Click += buttonTurnos_Click_1;
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
            buttonInicio.Size = new Size(220, 29);
            buttonInicio.TabIndex = 0;
            buttonInicio.Text = "ℹ️Inicio";
            buttonInicio.UseVisualStyleBackColor = false;
            buttonInicio.Click += buttonInicio_Click_1;
            // 
            // FormPrincipalOdontologo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenido);
            Controls.Add(panelMenu);
            Name = "FormPrincipalOdontologo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Odontológico";
            WindowState = FormWindowState.Maximized;
            Load += FormPrincipal_Load;
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelContenido;
        private Panel panelMenu;
        private Button buttonInicio;
        private Button buttonTurnos;
        private Button buttonHistoriaC;
        private Button buttonCerrar;
    }
}
