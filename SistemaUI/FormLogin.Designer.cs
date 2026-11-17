namespace SistemaUI
{
    partial class FormLogin
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
            titulo = new Label();
            DNI = new Label();
            Contraseña = new Label();
            textDNI = new TextBox();
            txtContrasena = new TextBox();
            checkMostar = new CheckBox();
            Rol = new Label();
            comboRol = new ComboBox();
            buttonIngresar = new Button();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Segoe UI", 14F);
            titulo.Location = new Point(256, 21);
            titulo.Name = "titulo";
            titulo.Size = new Size(240, 32);
            titulo.TabIndex = 0;
            titulo.Text = "Centro Odontológico";
            titulo.UseWaitCursor = true;
            titulo.Click += titulo_Click;
            // 
            // DNI
            // 
            DNI.AutoSize = true;
            DNI.Location = new Point(286, 67);
            DNI.Name = "DNI";
            DNI.Size = new Size(92, 20);
            DNI.TabIndex = 1;
            DNI.Text = "Ingresar DNI";
            DNI.Click += label2_Click;
            // 
            // Contraseña
            // 
            Contraseña.AutoSize = true;
            Contraseña.Location = new Point(287, 137);
            Contraseña.Name = "Contraseña";
            Contraseña.Size = new Size(83, 20);
            Contraseña.TabIndex = 2;
            Contraseña.Text = "Contraseña";
            // 
            // textDNI
            // 
            textDNI.Location = new Point(286, 90);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(164, 27);
            textDNI.TabIndex = 3;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(286, 160);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(164, 27);
            txtContrasena.TabIndex = 4;
            txtContrasena.UseSystemPasswordChar = true;
            txtContrasena.TextChanged += textContraseña_TextChanged;
            // 
            // checkMostar
            // 
            checkMostar.AutoSize = true;
            checkMostar.Location = new Point(286, 193);
            checkMostar.Name = "checkMostar";
            checkMostar.Size = new Size(153, 24);
            checkMostar.TabIndex = 5;
            checkMostar.Text = "Mostar contraseña";
            checkMostar.UseVisualStyleBackColor = true;
            checkMostar.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Rol
            // 
            Rol.AutoSize = true;
            Rol.Location = new Point(287, 220);
            Rol.Name = "Rol";
            Rol.Size = new Size(31, 20);
            Rol.TabIndex = 6;
            Rol.Text = "Rol";
            Rol.Click += label4_Click;
            // 
            // comboRol
            // 
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRol.FormattingEnabled = true;
            comboRol.Location = new Point(286, 243);
            comboRol.Name = "comboRol";
            comboRol.Size = new Size(164, 28);
            comboRol.TabIndex = 7;
            comboRol.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // buttonIngresar
            // 
            buttonIngresar.Location = new Point(267, 305);
            buttonIngresar.Name = "buttonIngresar";
            buttonIngresar.Size = new Size(94, 29);
            buttonIngresar.TabIndex = 8;
            buttonIngresar.Text = "Ingresar";
            buttonIngresar.UseVisualStyleBackColor = true;
            buttonIngresar.Click += buttonIngresar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(392, 305);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(94, 29);
            buttonCancelar.TabIndex = 9;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonIngresar);
            Controls.Add(comboRol);
            Controls.Add(Rol);
            Controls.Add(checkMostar);
            Controls.Add(txtContrasena);
            Controls.Add(textDNI);
            Controls.Add(Contraseña);
            Controls.Add(DNI);
            Controls.Add(titulo);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titulo;
        private Label DNI;
        private Label Contraseña;
        private TextBox textDNI;
        private TextBox txtContrasena;
        private CheckBox checkMostar;
        private Label Rol;
        private ComboBox comboRol;
        private Button buttonIngresar;
        private Button buttonCancelar;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Aquí va la validación de usuario y contraseña.

            FormPrincipal principal = new FormPrincipal();

            principal.Show();

            this.Hide();
        }
    }
}