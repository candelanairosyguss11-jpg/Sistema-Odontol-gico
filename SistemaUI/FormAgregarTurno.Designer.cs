namespace SistemaUI
{
    partial class FormAgregarTurno
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
            textDNI = new TextBox();
            panelAltaRapida = new Panel();
            label8 = new Label();
            dateTimePickerHora = new DateTimePicker();
            labelDuracion = new Label();
            numDuracion = new NumericUpDown();
            label7 = new Label();
            buttonBuscarDNI = new Button();
            labelFechaTurno = new Label();
            dateTimePickerFechaTurno = new DateTimePicker();
            labelTratamiento = new Label();
            checkedListBoxTratamientos = new CheckedListBox();
            comboBoxOdontologo = new ComboBox();
            labelOdontologo = new Label();
            buttonCancelar = new Button();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            buttonGuardar = new Button();
            textCorreo = new TextBox();
            label4 = new Label();
            textTelefono = new TextBox();
            label3 = new Label();
            textDNI2 = new TextBox();
            label2 = new Label();
            textApellido = new TextBox();
            label1 = new Label();
            textNombre = new TextBox();
            labelPaciente = new Label();
            ButtonVolver = new Button();
            panelAltaRapida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            SuspendLayout();
            // 
            // textDNI
            // 
            textDNI.Location = new Point(108, 417);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(145, 27);
            textDNI.TabIndex = 10;
            textDNI.TextChanged += textDNI_TextChanged;
            // 
            // panelAltaRapida
            // 
            panelAltaRapida.Controls.Add(label8);
            panelAltaRapida.Controls.Add(dateTimePickerHora);
            panelAltaRapida.Controls.Add(labelDuracion);
            panelAltaRapida.Controls.Add(textDNI);
            panelAltaRapida.Controls.Add(numDuracion);
            panelAltaRapida.Controls.Add(label7);
            panelAltaRapida.Controls.Add(buttonBuscarDNI);
            panelAltaRapida.Controls.Add(labelFechaTurno);
            panelAltaRapida.Controls.Add(dateTimePickerFechaTurno);
            panelAltaRapida.Controls.Add(labelTratamiento);
            panelAltaRapida.Controls.Add(checkedListBoxTratamientos);
            panelAltaRapida.Controls.Add(comboBoxOdontologo);
            panelAltaRapida.Controls.Add(labelOdontologo);
            panelAltaRapida.Controls.Add(buttonCancelar);
            panelAltaRapida.Controls.Add(dateTimePicker1);
            panelAltaRapida.Controls.Add(label6);
            panelAltaRapida.Controls.Add(label5);
            panelAltaRapida.Controls.Add(buttonGuardar);
            panelAltaRapida.Controls.Add(textCorreo);
            panelAltaRapida.Controls.Add(label4);
            panelAltaRapida.Controls.Add(textTelefono);
            panelAltaRapida.Controls.Add(label3);
            panelAltaRapida.Controls.Add(textDNI2);
            panelAltaRapida.Controls.Add(label2);
            panelAltaRapida.Controls.Add(textApellido);
            panelAltaRapida.Controls.Add(label1);
            panelAltaRapida.Controls.Add(textNombre);
            panelAltaRapida.Controls.Add(labelPaciente);
            panelAltaRapida.Location = new Point(12, 54);
            panelAltaRapida.Name = "panelAltaRapida";
            panelAltaRapida.Size = new Size(809, 783);
            panelAltaRapida.TabIndex = 9;
            panelAltaRapida.Paint += panelAltaRapida_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.LightBlue;
            label8.Location = new Point(4, 20);
            label8.Name = "label8";
            label8.Size = new Size(156, 20);
            label8.TabIndex = 25;
            label8.Text = "Información del Turno";
            // 
            // dateTimePickerHora
            // 
            dateTimePickerHora.Format = DateTimePickerFormat.Time;
            dateTimePickerHora.Location = new Point(137, 285);
            dateTimePickerHora.Name = "dateTimePickerHora";
            dateTimePickerHora.ShowUpDown = true;
            dateTimePickerHora.Size = new Size(250, 27);
            dateTimePickerHora.TabIndex = 24;
            // 
            // labelDuracion
            // 
            labelDuracion.AutoSize = true;
            labelDuracion.Location = new Point(48, 328);
            labelDuracion.Name = "labelDuracion";
            labelDuracion.Size = new Size(72, 20);
            labelDuracion.TabIndex = 23;
            labelDuracion.Text = "Duración:";
            labelDuracion.Click += label8_Click;
            // 
            // numDuracion
            // 
            numDuracion.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            numDuracion.Location = new Point(137, 326);
            numDuracion.Maximum = new decimal(new int[] { 240, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(150, 27);
            numDuracion.TabIndex = 22;
            numDuracion.Value = new decimal(new int[] { 30, 0, 0, 0 });
            numDuracion.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 285);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 21;
            label7.Text = "Hora:";
            label7.Click += label7_Click_2;
            // 
            // buttonBuscarDNI
            // 
            buttonBuscarDNI.Location = new Point(6, 415);
            buttonBuscarDNI.Name = "buttonBuscarDNI";
            buttonBuscarDNI.Size = new Size(94, 29);
            buttonBuscarDNI.TabIndex = 8;
            buttonBuscarDNI.Text = "Buscar DNI";
            buttonBuscarDNI.UseVisualStyleBackColor = true;
            // 
            // labelFechaTurno
            // 
            labelFechaTurno.AutoSize = true;
            labelFechaTurno.Location = new Point(7, 239);
            labelFechaTurno.Name = "labelFechaTurno";
            labelFechaTurno.Size = new Size(113, 20);
            labelFechaTurno.TabIndex = 20;
            labelFechaTurno.Text = "Fecha de Turno:";
            // 
            // dateTimePickerFechaTurno
            // 
            dateTimePickerFechaTurno.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaTurno.Location = new Point(137, 239);
            dateTimePickerFechaTurno.Name = "dateTimePickerFechaTurno";
            dateTimePickerFechaTurno.Size = new Size(250, 27);
            dateTimePickerFechaTurno.TabIndex = 19;
            dateTimePickerFechaTurno.ValueChanged += dateTimePickerFechaTurno_ValueChanged;
            // 
            // labelTratamiento
            // 
            labelTratamiento.AutoSize = true;
            labelTratamiento.Location = new Point(26, 110);
            labelTratamiento.Name = "labelTratamiento";
            labelTratamiento.Size = new Size(92, 20);
            labelTratamiento.TabIndex = 18;
            labelTratamiento.Text = "Tratamiento:";
            labelTratamiento.Click += label7_Click_1;
            // 
            // checkedListBoxTratamientos
            // 
            checkedListBoxTratamientos.FormattingEnabled = true;
            checkedListBoxTratamientos.Location = new Point(137, 101);
            checkedListBoxTratamientos.Name = "checkedListBoxTratamientos";
            checkedListBoxTratamientos.Size = new Size(172, 114);
            checkedListBoxTratamientos.TabIndex = 17;
            checkedListBoxTratamientos.SelectedIndexChanged += checkedListBoxTratamientos_SelectedIndexChanged;
            // 
            // comboBoxOdontologo
            // 
            comboBoxOdontologo.FormattingEnabled = true;
            comboBoxOdontologo.Location = new Point(137, 55);
            comboBoxOdontologo.Name = "comboBoxOdontologo";
            comboBoxOdontologo.Size = new Size(172, 28);
            comboBoxOdontologo.TabIndex = 16;
            comboBoxOdontologo.SelectedIndexChanged += comboBoxOdontologo_SelectedIndexChanged;
            // 
            // labelOdontologo
            // 
            labelOdontologo.AutoSize = true;
            labelOdontologo.Location = new Point(26, 55);
            labelOdontologo.Name = "labelOdontologo";
            labelOdontologo.Size = new Size(94, 20);
            labelOdontologo.TabIndex = 15;
            labelOdontologo.Text = "Odontólogo:";
            labelOdontologo.Click += label7_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(563, 714);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(94, 29);
            buttonCancelar.TabIndex = 14;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(213, 687);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 687);
            label6.Name = "label6";
            label6.Size = new Size(152, 20);
            label6.TabIndex = 12;
            label6.Text = "Fecha de Nacimiento:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(118, 646);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 10;
            label5.Text = "Correo:";
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(693, 714);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(94, 29);
            buttonGuardar.TabIndex = 1;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(213, 643);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(207, 27);
            textCorreo.TabIndex = 9;
            textCorreo.TextChanged += textCorreo_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 606);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 8;
            label4.Text = "Teléfono:";
            // 
            // textTelefono
            // 
            textTelefono.Location = new Point(213, 599);
            textTelefono.Name = "textTelefono";
            textTelefono.Size = new Size(207, 27);
            textTelefono.TabIndex = 7;
            textTelefono.TextChanged += textTelefono_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(137, 556);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 6;
            label3.Text = "DNI:";
            // 
            // textDNI2
            // 
            textDNI2.Location = new Point(213, 549);
            textDNI2.Name = "textDNI2";
            textDNI2.Size = new Size(208, 27);
            textDNI2.TabIndex = 5;
            textDNI2.TextChanged += textDNI2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 512);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 4;
            label2.Text = "Apellido:";
            label2.Click += label2_Click;
            // 
            // textApellido
            // 
            textApellido.Location = new Point(213, 505);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(208, 27);
            textApellido.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 462);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 2;
            label1.Text = "Nombre:";
            // 
            // textNombre
            // 
            textNombre.Location = new Point(213, 462);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(207, 27);
            textNombre.TabIndex = 1;
            // 
            // labelPaciente
            // 
            labelPaciente.AutoSize = true;
            labelPaciente.BackColor = Color.LightBlue;
            labelPaciente.Location = new Point(6, 377);
            labelPaciente.Name = "labelPaciente";
            labelPaciente.Size = new Size(132, 20);
            labelPaciente.TabIndex = 0;
            labelPaciente.Text = "Datos del Paciente";
            labelPaciente.Click += labelPaciente_Click;
            // 
            // ButtonVolver
            // 
            ButtonVolver.Location = new Point(12, 12);
            ButtonVolver.Name = "ButtonVolver";
            ButtonVolver.Size = new Size(136, 36);
            ButtonVolver.TabIndex = 11;
            ButtonVolver.Text = "← Volver";
            ButtonVolver.UseVisualStyleBackColor = true;
            ButtonVolver.Click += buttonVolver_Click;
            // 
            // FormAgregarTurno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 849);
            Controls.Add(ButtonVolver);
            Controls.Add(panelAltaRapida);
            Name = "FormAgregarTurno";
            Text = "FormAgregarTurno";
            Load += FormAgregarTurno_Load;
            panelAltaRapida.ResumeLayout(false);
            panelAltaRapida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textDNI;
        private Panel panelAltaRapida;
        private Button buttonCancelar;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private Label label5;
        private Button buttonGuardar;
        private TextBox textCorreo;
        private Label label4;
        private TextBox textTelefono;
        private Label label3;
        private TextBox textDNI2;
        private Label label2;
        private TextBox textApellido;
        private Label label1;
        private TextBox textNombre;
        private Label labelPaciente;
        private Button buttonBuscarDNI;
        private Button ButtonVolver;
        private Label labelOdontologo;
        private Label labelTratamiento;
        private CheckedListBox checkedListBoxTratamientos;
        private ComboBox comboBoxOdontologo;
        private Label labelFechaTurno;
        private DateTimePicker dateTimePickerFechaTurno;
        private Label label7;
        private Label labelDuracion;
        private NumericUpDown numDuracion;
        private DateTimePicker dateTimePickerHora;
        private Label label8;
    }
}