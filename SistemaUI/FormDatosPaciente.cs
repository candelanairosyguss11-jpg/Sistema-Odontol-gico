using Sistema_Odontológico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormDatosPaciente : Form
    {
        public FormDatosPaciente()
        {
            //InitializeComponent();
        }

        private void FormDatosPaciente_Load(object sender, EventArgs e)
        {

        }
        private readonly Paciente paciente;
        public FormDatosPaciente(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
