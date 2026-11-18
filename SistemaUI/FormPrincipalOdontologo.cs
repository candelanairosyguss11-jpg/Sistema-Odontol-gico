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

        }
        //agragado NAi
        private void AbrirFormulario(Form formulario)
        {
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

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void PanelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInicio());
        }

        private void PanelContenido_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Button3HC_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormHistoriasClinicas());
        }

        private void buttonTurnos_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormTurnos());
        }

        private void buttonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonInicio_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInicio());
        }
    }
}
