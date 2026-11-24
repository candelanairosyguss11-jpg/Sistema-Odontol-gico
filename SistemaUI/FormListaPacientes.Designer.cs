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
            ((System.ComponentModel.ISupportInitialize)dataGridViewPacientes).BeginInit();
            SuspendLayout();
            // 
            // ListadePacientes
            // 
            ListadePacientes.AutoSize = true;
            ListadePacientes.Font = new Font("Segoe UI", 20F);
            ListadePacientes.Location = new Point(0, 9);
            ListadePacientes.Name = "ListadePacientes";
            ListadePacientes.Size = new Size(283, 46);
            ListadePacientes.TabIndex = 0;
            ListadePacientes.Text = "Lista de Pacientes";
            ListadePacientes.Click += ListadePacientes_Click;
            // 
            // textBuscarPaciente
            // 
            textBuscarPaciente.Location = new Point(484, 12);
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
            dataGridViewPacientes.Location = new Point(0, 58);
            dataGridViewPacientes.Name = "dataGridViewPacientes";
            dataGridViewPacientes.RowHeadersWidth = 51;
            dataGridViewPacientes.Size = new Size(1401, 582);
            dataGridViewPacientes.TabIndex = 2;
            dataGridViewPacientes.CellContentClick += dataGridViewPacientes_CellContentClick;
            // 
            // FormListaPacientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewPacientes);
            Controls.Add(textBuscarPaciente);
            Controls.Add(ListadePacientes);
            Name = "FormListaPacientes";
            Text = "FormListaPaciente";
            WindowState = FormWindowState.Maximized;
            Load += FormListaPaciente_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPacientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ListadePacientes;
        private TextBox textBuscarPaciente;
        private DataGridView dataGridViewPacientes;
    }
}