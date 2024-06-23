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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();

            // Configurar el ComboBox
            cmbDisponible.DropDownStyle = ComboBoxStyle.DropDownList;

            // Agregar ítems al ComboBox
            cmbDisponible.Items.Add("Disponible");
            cmbDisponible.Items.Add("No disponible");

            // Asociar el evento SelectedIndexChanged con su manejador
            cmbDisponible.SelectedIndexChanged += new EventHandler(cmbDisponible_SelectedIndexChanged);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDisponible_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ítem seleccionado
            string selectedItem = cmbDisponible.SelectedItem.ToString();

        }
    }
}
