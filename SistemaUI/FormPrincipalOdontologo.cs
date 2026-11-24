using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormPrincipalOdontologo : Form
    {
        public FormPrincipalOdontologo()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (Sesion.Actual != null)
                this.Text = $"Sistema Odontológico — {Sesion.Actual.NombreCompleto} (Odontología)";

            MarcarBotonActivo(buttonInicio);
            AbrirFormulario(new FormInicio());
        }

        private void MarcarBotonActivo(Button activo)
        {
            foreach (Button btn in panelMenu.Controls.OfType<Button>())
            {
                btn.BackColor = btn == activo ? Color.MediumBlue : Color.MidnightBlue;
            }
        }

        public void AbrirFormulario(Form formulario)
        {
            panelMenu.Visible = !(formulario is FormHistoriasClinicas || formulario is FormTurnos);

            foreach (Control control in panelContenido.Controls)
            {
                control.Dispose();
            }
            panelContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);
            formulario.Show();
        }

        private void buttonInicio_Click_1(object sender, EventArgs e)
        {
            MarcarBotonActivo(buttonInicio);
            AbrirFormulario(new FormInicio());
        }

        private void buttonTurnos_Click_1(object sender, EventArgs e)
        {
            MarcarBotonActivo(buttonTurnos);
            AbrirFormulario(new FormTurnos());
        }

        private void Button3HC_Click_1(object sender, EventArgs e)
        {
            MarcarBotonActivo(buttonHistoriaC);
            AbrirFormulario(new FormListaPacientes());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(button1);
            AbrirFormulario(new FormConfiguracionOdontologo());
        }

        private void buttonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e) { }
        private void Button3_Click(object sender, EventArgs e) { }
        private void PanelContenido_Paint(object sender, PaintEventArgs e) { }
        private void PanelContenido_Paint_1(object sender, PaintEventArgs e) { }
    }
}