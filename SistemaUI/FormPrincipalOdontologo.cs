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
            AbrirFormulario(new FormInicio());//para abrir el formulrio de inicio como defecto
            //para centar los controles
            CentrarControles();
        }
        //
        public void AbrirFormulario(Form formulario)
        {
            // El menú principal se oculta cuando se abre la sección historias clinicas y de turnos
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

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void PanelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonInicio_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInicio());
        }

        private void PanelContenido_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void buttonTurnos_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormTurnos());
        }

        private void Button3HC_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormListaPacientes());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormConfiguracionOdontologo());
        }
    

        private void buttonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
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


        private void FormPrincipalOdontologo_Resize(object sender, EventArgs e)
        {
            CentrarControles();
        }
    }

}
