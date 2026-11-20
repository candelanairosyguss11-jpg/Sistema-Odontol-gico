using Sistema_Odontológico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SistemaUI
{
    public partial class FormInicio : Form
    {
        private const int HoraInicio = 8, HoraFin = 21;
        private readonly CultureInfo cultura = new CultureInfo("es-AR");
        private readonly DataGridView grilla = new DataGridView();
        private readonly Label lblMes = new Label();
        private DateTime semanaInicio;

        public FormInicio()
        {
            InitializeComponent();
            ConstruirCalendario();
            IrASemana(DateTime.Today);
        }

        private void ConstruirCalendario()
        {
            // Barra superior
            var barra = new Panel { Dock = DockStyle.Top, Height = 50 };
            var btnAnt = new Button { Text = "‹", Width = 40, Left = 10, Top = 10 };
            var btnHoy = new Button { Text = "Hoy", Width = 60, Left = 55, Top = 10 };
            var btnSig = new Button { Text = "›", Width = 40, Left = 120, Top = 10 };
            lblMes.Left = 175; lblMes.Top = 14; lblMes.AutoSize = true;
            lblMes.Font = new Font("Segoe UI", 14F);

            btnAnt.Click += (s, e) => IrASemana(semanaInicio.AddDays(-7));
            btnSig.Click += (s, e) => IrASemana(semanaInicio.AddDays(7));
            btnHoy.Click += (s, e) => IrASemana(DateTime.Today);
            barra.Controls.AddRange(new Control[] { btnAnt, btnHoy, btnSig, lblMes });

            // Grilla: 7 columnas (dom..sáb) y una fila por hora
            grilla.Dock = DockStyle.Fill;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.AllowUserToResizeRows = false;
            grilla.ReadOnly = true;
            grilla.EnableHeadersVisualStyles = false;
            grilla.BackgroundColor = Color.White;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grilla.ColumnHeadersHeight = 55;
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grilla.RowHeadersWidth = 70;
            grilla.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            for (int i = 0; i < 7; i++)
                grilla.Columns.Add(new DataGridViewTextBoxColumn
                { SortMode = DataGridViewColumnSortMode.NotSortable });

            for (int h = HoraInicio; h <= HoraFin; h++)
            {
                int idx = grilla.Rows.Add();
                grilla.Rows[idx].Height = 50;
                grilla.Rows[idx].HeaderCell.Value = $"{h}:00";
            }

            // Orden importante: primero el Fill y después el Top
            Controls.Add(grilla);
            Controls.Add(barra);
        }

        private void IrASemana(DateTime fecha)
        {
            semanaInicio = fecha.Date.AddDays(-(int)fecha.DayOfWeek); // domingo
            lblMes.Text = cultura.TextInfo.ToTitleCase(
                semanaInicio.AddDays(3).ToString("MMMM yyyy", cultura));

            for (int i = 0; i < 7; i++)
            {
                DateTime dia = semanaInicio.AddDays(i);
                var col = grilla.Columns[i];
                col.HeaderText = $"{dia.ToString("ddd", cultura)}\n{dia.Day}";
                bool esHoy = dia == DateTime.Today;
                col.HeaderCell.Style.BackColor = esHoy ? Color.MediumPurple : Color.WhiteSmoke;
                col.HeaderCell.Style.ForeColor = esHoy ? Color.White : Color.Black;
            }
            CargarTurnos();
        }

        private void CargarTurnos()
        {
            foreach (DataGridViewRow fila in grilla.Rows)
                foreach (DataGridViewCell c in fila.Cells)
                {
                    c.Value = null;
                    c.Style.BackColor = Color.White;
                }

            // TODO: reemplazar por los turnos reales que devuelva la capa Logica,
            // filtrados entre semanaInicio y semanaInicio.AddDays(7)
            MostrarTurno(semanaInicio.AddDays(1).AddHours(9), "Turno: Juan Pérez", Color.LightSkyBlue);//instancia de prueba, pero aunque cambie de dia sigue el turno idkk
        }

        private void MostrarTurno(DateTime fechaHora, string texto, Color color)
        {
            int col = (int)fechaHora.DayOfWeek;
            int fila = fechaHora.Hour - HoraInicio;
            if (fila < 0 || fila >= grilla.Rows.Count) return;

            var celda = grilla.Rows[fila].Cells[col];
            celda.Value = texto;
            celda.Style.BackColor = color;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            //para centar los controles
            CentrarControles();
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


        private void FormInicio_Resize(object sender, EventArgs e)
        {
            CentrarControles();
        }
    }
}