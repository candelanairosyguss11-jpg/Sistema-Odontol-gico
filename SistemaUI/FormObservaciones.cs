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
            //para centar los controles
            CentrarControles();
            historia = Servicios.Historias.ObtenerPorPaciente(paciente.Id);
        }
        private readonly Paciente paciente;
        private HistoriaClinica historia;
        public FormObservaciones(Paciente paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
        }


        //
        private void CentrarControles()
        {
            if (this.Controls.Count == 0) return;

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;

            // 1. Obtener los límites del bloque de controles
            foreach (Control c in this.Controls)
            {
                if (!c.Visible) continue;
                if (c.Left < minX) minX = c.Left;
                if (c.Top < minY) minY = c.Top;
                if (c.Right > maxX) maxX = c.Right;
                if (c.Bottom > maxY) maxY = c.Bottom;
            }

            int anchoBloque = maxX - minX;
            int altoBloque = maxY - minY;

            // 2. Calcular la nueva posición inicial centrada
            int nuevoInicioX = (this.ClientSize.Width - anchoBloque) / 2;
            int nuevoInicioY = (this.ClientSize.Height - altoBloque) / 2;

            // 3. Calcular cuánto debe moverse cada control
            int desplazamientoX = nuevoInicioX - minX;
            int desplazamientoY = nuevoInicioY - minY;

            // 4. Mover todos los controles manteniendo su posición relativa
            this.SuspendLayout();
            foreach (Control c in this.Controls)
            {
                c.Left += desplazamientoX;
                c.Top += desplazamientoY;
            }
            this.ResumeLayout();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Servicios.Historias.AgregarObservacion(historia.Id, Sesion.OdontologoActual, textNuevaObservacion.Text, null);
            //    textNuevaObservacion.Clear();
            //    MostrarObservaciones();
            //}
            //catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
