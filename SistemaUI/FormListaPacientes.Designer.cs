namespace SistemaUI
{
    partial class FormListaPacientes
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
            ListadePacientes = new Label();
            textBuscarPaciente = new TextBox();
            dataGridViewPacientes = new DataGridView();
            button1 = new Button();
            panelMenu = new Panel();
            panelContenido = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPacientes).BeginInit();
            panelMenu.SuspendLayout();
            panelContenido.SuspendLayout();
            SuspendLayout();
            // 
            // ListadePacientes
            // 
            ListadePacientes.AutoSize = true;
            ListadePacientes.Font = new Font("Segoe UI", 20F);
            ListadePacientes.Location = new Point(0, 0);
            ListadePacientes.Name = "ListadePacientes";
            ListadePacientes.Size = new Size(283, 46);
            ListadePacientes.TabIndex = 0;
            ListadePacientes.Text = "Lista de Pacientes";
            ListadePacientes.Click += ListadePacientes_Click;
            // 
            // textBuscarPaciente
            // 
            textBuscarPaciente.Location = new Point(527, 13);
            textBuscarPaciente.Name = "textBuscarPaciente";
            textBuscarPaciente.PlaceholderText = "🔍︎ Buscar paciente";
            textBuscarPaciente.Size = new Size(304, 27);
            textBuscarPaciente.TabIndex = 1;
            textBuscarPaciente.TextChanged += textBuscarPaciente_TextChanged;
            // 
            // dataGridViewPacientes
            // 
            dataGridViewPacientes.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPacientes.Location = new Point(0, 0);
            dataGridViewPacientes.Name = "dataGridViewPacientes";
            dataGridViewPacientes.RowHeadersWidth = 51;
            dataGridViewPacientes.Size = new Size(1401, 278);
            dataGridViewPacientes.TabIndex = 2;
            dataGridViewPacientes.CellContentClick += dataGridViewPacientes_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(1244, 16);
            button1.Name = "button1";
            button1.Size = new Size(157, 29);
            button1.TabIndex = 3;
            button1.Text = "Crear Historia Clinica";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(ListadePacientes);
            panelMenu.Controls.Add(button1);
            panelMenu.Controls.Add(textBuscarPaciente);
            panelMenu.Location = new Point(0, -1);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1401, 53);
            panelMenu.TabIndex = 4;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dataGridViewPacientes);
            panelContenido.Location = new Point(0, 50);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(1407, 295);
            panelContenido.TabIndex = 4;
            panelContenido.Paint += panelContenido_Paint_2;
            // 
            // FormListaPacientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1513, 450);
            Controls.Add(panelContenido);
            Controls.Add(panelMenu);
            Name = "FormListaPacientes";
            Text = "FormListaPaciente";
            WindowState = FormWindowState.Maximized;
            Load += FormListaPaciente_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPacientes).EndInit();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelContenido.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label ListadePacientes;
        private TextBox textBuscarPaciente;
        private DataGridView dataGridViewPacientes;
        private Button button1;
        private Panel panelMenu;
        private Panel panelContenido;
    }
}