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
            buttonBuscarDNI = new Button();
            ButtonVolver = new Button();
            panelAltaRapida.SuspendLayout();
            SuspendLayout();
            // 
            // textDNI
            // 
            textDNI.Location = new Point(179, 69);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(145, 27);
            textDNI.TabIndex = 10;
            textDNI.TextChanged += textDNI_TextChanged;
            // 
            // panelAltaRapida
            // 
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
            panelAltaRapida.Location = new Point(179, 102);
            panelAltaRapida.Name = "panelAltaRapida";
            panelAltaRapida.Size = new Size(591, 397);
            panelAltaRapida.TabIndex = 9;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(356, 351);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(94, 29);
            buttonCancelar.TabIndex = 14;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(219, 290);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 295);
            label6.Name = "label6";
            label6.Size = new Size(152, 20);
            label6.TabIndex = 12;
            label6.Text = "Fecha de Nacimiento:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(61, 243);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 10;
            label5.Text = "Correo:";
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(471, 351);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(94, 29);
            buttonGuardar.TabIndex = 1;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(137, 243);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(207, 27);
            textCorreo.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 189);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 8;
            label4.Text = "Teléfono:";
            // 
            // textTelefono
            // 
            textTelefono.Location = new Point(137, 186);
            textTelefono.Name = "textTelefono";
            textTelefono.Size = new Size(207, 27);
            textTelefono.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 143);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 6;
            label3.Text = "DNI:";
            // 
            // textDNI2
            // 
            textDNI2.Location = new Point(136, 136);
            textDNI2.Name = "textDNI2";
            textDNI2.Size = new Size(208, 27);
            textDNI2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 97);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 4;
            label2.Text = "Apellido:";
            // 
            // textApellido
            // 
            textApellido.Location = new Point(136, 94);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(208, 27);
            textApellido.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 54);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 2;
            label1.Text = "Nombre:";
            // 
            // textNombre
            // 
            textNombre.Location = new Point(137, 51);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(207, 27);
            textNombre.TabIndex = 1;
            // 
            // labelPaciente
            // 
            labelPaciente.AutoSize = true;
            labelPaciente.Location = new Point(14, 13);
            labelPaciente.Name = "labelPaciente";
            labelPaciente.Size = new Size(64, 20);
            labelPaciente.TabIndex = 0;
            labelPaciente.Text = "Paciente";
            // 
            // buttonBuscarDNI
            // 
            buttonBuscarDNI.Location = new Point(79, 69);
            buttonBuscarDNI.Name = "buttonBuscarDNI";
            buttonBuscarDNI.Size = new Size(94, 29);
            buttonBuscarDNI.TabIndex = 8;
            buttonBuscarDNI.Text = "Buscar DNI";
            buttonBuscarDNI.UseVisualStyleBackColor = true;
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
            ClientSize = new Size(881, 511);
            Controls.Add(ButtonVolver);
            Controls.Add(textDNI);
            Controls.Add(panelAltaRapida);
            Controls.Add(buttonBuscarDNI);
            Name = "FormAgregarTurno";
            Text = "FormAgregarTurno";
            Load += FormAgregarTurno_Load;
            panelAltaRapida.ResumeLayout(false);
            panelAltaRapida.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
    }
}