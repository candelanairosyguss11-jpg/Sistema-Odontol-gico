using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaUI
{
    partial class FormInicio
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
            barra = new Panel();
            lblMes = new Label();
            btnSig = new Button();
            btnHoy = new Button();
            btnAnt = new Button();
            grilla = new DataGridView();
            panelInicioSecretario = new Panel();
            dgvTurnosHoy = new DataGridView();
            lblSubtituloHoy = new Label();
            lblBienvenida = new Label();
            barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grilla).BeginInit();
            panelInicioSecretario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnosHoy).BeginInit();
            SuspendLayout();
            // 
            // barra
            // 
            barra.Controls.Add(lblMes);
            barra.Controls.Add(btnSig);
            barra.Controls.Add(btnHoy);
            barra.Controls.Add(btnAnt);
            barra.Dock = DockStyle.Top;
            barra.Location = new Point(0, 0);
            barra.Name = "barra";
            barra.Size = new Size(950, 50);
            barra.TabIndex = 0;
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.Font = new System.Drawing.Font("Segoe UI", 14F);
            lblMes.Location = new Point(175, 11);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(109, 32);
            lblMes.TabIndex = 3;
            lblMes.Text = "Mes Año";
            // 
            // btnSig
            // 
            btnSig.Location = new Point(120, 10);
            btnSig.Name = "btnSig";
            btnSig.Size = new Size(40, 29);
            btnSig.TabIndex = 2;
            btnSig.Text = "›";
            btnSig.UseVisualStyleBackColor = true;
            btnSig.Click += btnSig_Click;
            // 
            // btnHoy
            // 
            btnHoy.Location = new Point(55, 10);
            btnHoy.Name = "btnHoy";
            btnHoy.Size = new Size(60, 29);
            btnHoy.TabIndex = 1;
            btnHoy.Text = "Hoy";
            btnHoy.UseVisualStyleBackColor = true;
            btnHoy.Click += btnHoy_Click;
            // 
            // btnAnt
            // 
            btnAnt.Location = new Point(10, 10);
            btnAnt.Name = "btnAnt";
            btnAnt.Size = new Size(40, 29);
            btnAnt.TabIndex = 0;
            btnAnt.Text = "‹";
            btnAnt.UseVisualStyleBackColor = true;
            btnAnt.Click += btnAnt_Click;
            // 
            // grilla
            // 
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.AllowUserToResizeRows = false;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grilla.BackgroundColor = Color.White;
            grilla.ColumnHeadersHeight = 55;
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grilla.Dock = DockStyle.Fill;
            grilla.EnableHeadersVisualStyles = false;
            grilla.Location = new Point(0, 50);
            grilla.Name = "grilla";
            grilla.ReadOnly = true;
            grilla.RowHeadersWidth = 70;
            grilla.Size = new Size(950, 500);
            grilla.TabIndex = 1;
            grilla.CellDoubleClick += Grilla_CellDoubleClick;
            // 
            // panelInicioSecretario
            // 
            panelInicioSecretario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelInicioSecretario.BackColor = Color.WhiteSmoke;
            panelInicioSecretario.Controls.Add(dgvTurnosHoy);
            panelInicioSecretario.Controls.Add(lblSubtituloHoy);
            panelInicioSecretario.Controls.Add(lblBienvenida);
            panelInicioSecretario.Location = new Point(0, 0);
            panelInicioSecretario.Name = "panelInicioSecretario";
            panelInicioSecretario.Size = new Size(950, 550);
            panelInicioSecretario.TabIndex = 2;
            panelInicioSecretario.Visible = false;
            // 
            // dgvTurnosHoy
            // 
            dgvTurnosHoy.AllowUserToAddRows = false;
            dgvTurnosHoy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTurnosHoy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnosHoy.BackgroundColor = Color.White;
            dgvTurnosHoy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnosHoy.Location = new Point(25, 105);
            dgvTurnosHoy.MultiSelect = false;
            dgvTurnosHoy.Name = "dgvTurnosHoy";
            dgvTurnosHoy.ReadOnly = true;
            dgvTurnosHoy.RowHeadersVisible = false;
            dgvTurnosHoy.RowHeadersWidth = 51;
            dgvTurnosHoy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnosHoy.Size = new Size(895, 465);
            dgvTurnosHoy.TabIndex = 2;
            // 
            // lblSubtituloHoy
            // 
            lblSubtituloHoy.AutoSize = true;
            lblSubtituloHoy.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtituloHoy.Location = new Point(25, 68);
            lblSubtituloHoy.Name = "lblSubtituloHoy";
            lblSubtituloHoy.Size = new Size(271, 25);
            lblSubtituloHoy.TabIndex = 1;
            lblSubtituloHoy.Text = "Turnos programados para hoy:";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.MidnightBlue;
            lblBienvenida.Location = new Point(25, 22);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(262, 37);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Panel de Secretaría";
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 550);
            Controls.Add(panelInicioSecretario);
            Controls.Add(grilla);
            Controls.Add(barra);
            Name = "FormInicio";
            Text = "Inicio";
            Load += FormInicio_Load;
            barra.ResumeLayout(false);
            barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grilla).EndInit();
            panelInicioSecretario.ResumeLayout(false);
            panelInicioSecretario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnosHoy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel barra;
        private Button btnAnt;
        private Button btnHoy;
        private Button btnSig;
        private Label lblMes;
        private DataGridView grilla;
        private Panel panelInicioSecretario;
        private Label lblBienvenida;
        private Label lblSubtituloHoy;
        private DataGridView dgvTurnosHoy;
    }
}