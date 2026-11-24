namespace SistemaUI
{
    partial class FormCancelarTurno
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            buttonVolver = new Button();
            panelCancelar = new Panel();
            lblPacienteInfo = new Label();
            dgvTurnos = new DataGridView();
            textDNI = new TextBox();
            buttonBuscarDNI = new Button();
            buttonCancelar = new Button();
            panelCancelar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
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
            panelCancelar.Controls.Add(lblPacienteInfo);
            panelCancelar.Controls.Add(dgvTurnos);
            panelCancelar.Controls.Add(buttonCancelar);
            panelCancelar.Controls.Add(textDNI);
            panelCancelar.Controls.Add(buttonBuscarDNI);
            panelCancelar.Location = new Point(153, 64);
            panelCancelar.Name = "panelCancelar";
            panelCancelar.Size = new Size(906, 552);
            panelCancelar.TabIndex = 7;
            // 
            // lblPacienteInfo
            // 
            lblPacienteInfo.AutoSize = true;
            lblPacienteInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPacienteInfo.Location = new Point(280, 23);
            lblPacienteInfo.Name = "lblPacienteInfo";
            lblPacienteInfo.Size = new Size(0, 23);
            lblPacienteInfo.TabIndex = 14;
            // 
            // dgvTurnos
            // 
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.BackgroundColor = Color.White;
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnos.Location = new Point(15, 65);
            dgvTurnos.MultiSelect = false;
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.ReadOnly = true;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.Size = new Size(856, 425);
            dgvTurnos.TabIndex = 15;
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
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(686, 509);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(185, 29);
            buttonCancelar.TabIndex = 13;
            buttonCancelar.Text = "Cancelar Turno";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
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
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonVolver;
        private Panel panelCancelar;
        private TextBox textDNI;
        private Button buttonBuscarDNI;
        private Button buttonCancelar;
        private DataGridView dgvTurnos;
        private Label lblPacienteInfo;
    }
}