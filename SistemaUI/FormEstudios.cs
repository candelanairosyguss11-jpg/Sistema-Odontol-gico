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
    public partial class FormEstudios : Form
    {
        public FormEstudios()
        {
            InitializeComponent();
        }

        private void FormEstudios_Load(object sender, EventArgs e)
        {

        }
        private readonly Paciente paciente;
        public FormEstudios(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
        }
    }
}
