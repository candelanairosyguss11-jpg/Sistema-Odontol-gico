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
    public partial class FormConsentimiento : Form
    {
        public FormConsentimiento()
        {
            //InitializeComponent();
        }

        private void FormConsentimiento_Load(object sender, EventArgs e)
        {

        }
        private readonly Paciente paciente;
        public FormConsentimiento(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
            
        }
    }
}
