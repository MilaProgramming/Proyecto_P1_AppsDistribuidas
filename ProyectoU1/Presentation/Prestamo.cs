using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2
{
    public partial class Prestamo : Form
    {
        public Prestamo()
        {
            InitializeComponent();

            // Configurar los DateTimePickers
            dateTimePicker1.MinDate = new DateTime(1990, 1, 1);
            dateTimePicker2.MaxDate = new DateTime(2025, 12, 31);

            // Asociar los eventos ValueChanged
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fecha1 = dateTimePicker1.Value;
            DateTime fecha2 = dateTimePicker2.Value;

            // Validar que fecha1 sea mayor o igual a 1990
            if (fecha1 < new DateTime(1990, 1, 1) || fecha1 > new DateTime(2025, 12, 31))
            {
                MessageBox.Show("La fecha debe ser mayor a 1990 o menor a 2025.");
                dateTimePicker1.Value = new DateTime(1990, 1, 1);
                return;
            }

            // No validar contra fecha2 en este punto para permitir cualquier fecha desde 1990
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fecha1 = dateTimePicker1.Value;
            DateTime fecha2 = dateTimePicker2.Value;

            // Validar que fecha2 sea mayor que fecha1
            if (fecha2 <= fecha1)
            {
                MessageBox.Show("La fecha de entrega debe ser mayor que la fecha del Prestamo.");
                dateTimePicker2.Value = fecha1.AddDays(1); // Ajustar a un día después de la fecha1
            }
        }

    }
}
