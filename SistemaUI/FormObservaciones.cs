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
    public partial class FormObservaciones : Form
    {
        public FormObservaciones()
        {
            InitializeComponent();
        }

        private void FormObservaciones_Load(object sender, EventArgs e)
        {

        }
        private readonly Paciente paciente;
        public FormObservaciones(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
        }
    }
}
