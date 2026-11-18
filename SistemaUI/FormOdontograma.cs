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
    public partial class FormOdontograma : Form
    {
        public FormOdontograma()
        {
            InitializeComponent();
        }

        private void FormOdontograma_Load(object sender, EventArgs e)
        {

        }
        private readonly Paciente paciente;
        public FormOdontograma(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
        }
    }
}
