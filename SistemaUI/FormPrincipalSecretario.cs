using Sistema_Odontológico;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormPrincipalSecretario : Form
    {
        public FormPrincipalSecretario()
        {
            InitializeComponent();
        }

        private void FormPrincipalSecretario_Load(object sender, EventArgs e)
        {
            if (Sesion.Actual != null)
                this.Text = $"Sistema Odontológico — {Sesion.Actual.NombreCompleto} (Secretaría)";

            CargarBotonesAgendasOdontologos();
            AbrirFormulario(new FormInicio());
        }

        private void CargarBotonesAgendasOdontologos()
        {
            // Ocultamos los botones de ejemplo del diseñador
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            var odontologos = Servicios.Usuarios.ObtenerOdontologos()
                .Where(o => o.Activo)
                .ToList();

            // En WinForms con Dock = Top, el último agregado con BringToFront queda arriba,
            // por eso recorremos en orden inverso para que queden debajo de buttonTurnos
            foreach (var odontologo in odontologos.AsEnumerable().Reverse())
            {
                var btnAgenda = new Button
                {
                    BackColor = Color.MidnightBlue,
                    Dock = DockStyle.Top,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    Height = 67,
                    Text = $"📒 Agenda {odontologo.NombreCompleto}",
                    Tag = odontologo,
                    UseVisualStyleBackColor = false,
                    Cursor = Cursors.Hand
                };
                btnAgenda.FlatAppearance.BorderColor = Color.MidnightBlue;

                btnAgenda.Click += (s, e) =>
                {
                    MarcarBotonActivo(btnAgenda);
                    AbrirFormulario(new FormInicio(odontologo));
                };

                panelMenu.Controls.Add(btnAgenda);
                // Lo ubicamos justo debajo de buttonTurnos (que está en índice superior)
                panelMenu.Controls.SetChildIndex(btnAgenda, panelMenu.Controls.GetChildIndex(buttonTurnos));
            }
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
            panelMenu.Visible = !(formulario is FormTurnos);

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

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(buttonInicio);
            AbrirFormulario(new FormInicio());
        }

        private void buttonTurnos_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(buttonTurnos);
            AbrirFormulario(new FormTurnos());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(button4);
            AbrirFormulario(new FormConfiguracionSecretario());
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e) { }
    }
}