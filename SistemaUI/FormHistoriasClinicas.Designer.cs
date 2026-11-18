namespace SistemaUI
{
    partial class FormHistoriasClinicas
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
            MenuHistoriasC = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            MenuHistoriasC.SuspendLayout();
            SuspendLayout();
            // 
            // MenuHistoriasC
            // 
            MenuHistoriasC.Controls.Add(button5);
            MenuHistoriasC.Controls.Add(button4);
            MenuHistoriasC.Controls.Add(button3);
            MenuHistoriasC.Controls.Add(button2);
            MenuHistoriasC.Controls.Add(button1);
            MenuHistoriasC.Dock = DockStyle.Left;
            MenuHistoriasC.Location = new Point(0, 0);
            MenuHistoriasC.Name = "MenuHistoriasC";
            MenuHistoriasC.Size = new Size(133, 450);
            MenuHistoriasC.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new Point(3, 368);
            button5.Name = "button5";
            button5.Size = new Size(123, 82);
            button5.TabIndex = 4;
            button5.Text = "Observaciones";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(3, 276);
            button4.Name = "button4";
            button4.Size = new Size(123, 86);
            button4.TabIndex = 3;
            button4.Text = "Consentimiento Informado";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(3, 191);
            button3.Name = "button3";
            button3.Size = new Size(123, 79);
            button3.TabIndex = 2;
            button3.Text = "Estudios";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(3, 98);
            button2.Name = "button2";
            button2.Size = new Size(123, 87);
            button2.TabIndex = 1;
            button2.Text = "Odontograma";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(3, 0);
            button1.Name = "button1";
            button1.Size = new Size(123, 92);
            button1.TabIndex = 0;
            button1.Text = "Datos";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormHistoriasClinicas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(MenuHistoriasC);
            Name = "FormHistoriasClinicas";
            Text = "Historias Clínicas";
            Load += FormHistoriasClinicas_Load;
            MenuHistoriasC.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MenuHistoriasC;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}