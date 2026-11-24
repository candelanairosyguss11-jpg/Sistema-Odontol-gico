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
            buttonBuscarDNI = new Button();
            textDNI = new TextBox();
            buttonReprogramar = new Button();
            panelReprogramar = new DataGridView();
            dateTimePickerHora = new DateTimePicker();
            labelDuracion = new Label();
            numDuracion = new NumericUpDown();
            label7 = new Label();
            labelFechaTurno = new Label();
            dateTimePickerFechaTurno = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)panelReprogramar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
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
            // buttonBuscarDNI
            // 
            buttonBuscarDNI.Location = new Point(162, 62);
            buttonBuscarDNI.Name = "buttonBuscarDNI";
            buttonBuscarDNI.Size = new Size(94, 29);
            buttonBuscarDNI.TabIndex = 11;
            buttonBuscarDNI.Text = "Buscar DNI";
            buttonBuscarDNI.UseVisualStyleBackColor = true;
            buttonBuscarDNI.Click += buttonBuscarDNI_Click;
            // 
            // textDNI
            // 
            textDNI.Location = new Point(271, 62);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(145, 27);
            textDNI.TabIndex = 12;
            // 
            // buttonReprogramar
            // 
            buttonReprogramar.Location = new Point(804, 606);
            buttonReprogramar.Name = "buttonReprogramar";
            buttonReprogramar.Size = new Size(258, 29);
            buttonReprogramar.TabIndex = 13;
            buttonReprogramar.Text = "Reprogramar";
            buttonReprogramar.UseVisualStyleBackColor = true;
            buttonReprogramar.Click += buttonReprogramar_Click;
            // 
            // panelReprogramar
            // 
            panelReprogramar.BackgroundColor = SystemColors.ButtonHighlight;
            panelReprogramar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            panelReprogramar.Location = new Point(162, 97);
            panelReprogramar.Name = "panelReprogramar";
            panelReprogramar.RowHeadersWidth = 51;
            panelReprogramar.Size = new Size(829, 299);
            panelReprogramar.TabIndex = 14;
            // 
            // dateTimePickerHora
            // 
            dateTimePickerHora.Format = DateTimePickerFormat.Time;
            dateTimePickerHora.Location = new Point(553, 478);
            dateTimePickerHora.Name = "dateTimePickerHora";
            dateTimePickerHora.ShowUpDown = true;
            dateTimePickerHora.Size = new Size(250, 27);
            dateTimePickerHora.TabIndex = 30;
            // 
            // labelDuracion
            // 
            labelDuracion.AutoSize = true;
            labelDuracion.Location = new Point(464, 521);
            labelDuracion.Name = "labelDuracion";
            labelDuracion.Size = new Size(72, 20);
            labelDuracion.TabIndex = 29;
            labelDuracion.Text = "Duración:";
            // 
            // numDuracion
            // 
            numDuracion.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            numDuracion.Location = new Point(553, 519);
            numDuracion.Maximum = new decimal(new int[] { 240, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(150, 27);
            numDuracion.TabIndex = 28;
            numDuracion.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(489, 478);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 27;
            label7.Text = "Hora:";
            // 
            // labelFechaTurno
            // 
            labelFechaTurno.AutoSize = true;
            labelFechaTurno.Location = new Point(423, 432);
            labelFechaTurno.Name = "labelFechaTurno";
            labelFechaTurno.Size = new Size(113, 20);
            labelFechaTurno.TabIndex = 26;
            labelFechaTurno.Text = "Fecha de Turno:";
            // 
            // dateTimePickerFechaTurno
            // 
            dateTimePickerFechaTurno.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaTurno.Location = new Point(553, 432);
            dateTimePickerFechaTurno.Name = "dateTimePickerFechaTurno";
            dateTimePickerFechaTurno.Size = new Size(250, 27);
            dateTimePickerFechaTurno.TabIndex = 25;
            // 
            // FormReprogramarTurno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 984);
            Controls.Add(dateTimePickerHora);
            Controls.Add(labelDuracion);
            Controls.Add(numDuracion);
            Controls.Add(label7);
            Controls.Add(labelFechaTurno);
            Controls.Add(dateTimePickerFechaTurno);
            Controls.Add(panelReprogramar);
            Controls.Add(textDNI);
            Controls.Add(buttonReprogramar);
            Controls.Add(buttonBuscarDNI);
            Controls.Add(buttonVolver);
            Name = "FormReprogramarTurno";
            Text = "FormReprogramarTurno";
            Load += FormReprogramarTurno_Load;
            ((System.ComponentModel.ISupportInitialize)panelReprogramar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonVolver;
        private Button buttonBuscarDNI;
        private TextBox textDNI;
        private Button buttonReprogramar;
        private DataGridView panelReprogramar;
        private DateTimePicker dateTimePickerHora;
        private Label labelDuracion;
        private NumericUpDown numDuracion;
        private Label label7;
        private Label labelFechaTurno;
        private DateTimePicker dateTimePickerFechaTurno;
    }
}