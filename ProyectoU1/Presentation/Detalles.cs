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
    public partial class Detalles : Form
    {
        public Detalles()
        {
            InitializeComponent();
            // Configurar el formulario para que tenga scroll automático
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 800); // Tamaño mínimo del área de desplazamiento
        }

        private void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(txtIdAutor, "ID de autor") && ValidarCampos(txtNombreAutor, "Nombre de autor"))
            {
                // Aquí puedes continuar con la lógica para guardar el autor
                // Por ejemplo:
                // guardarAutor(txtIdAutor.Text.Trim(), txtNombreAutor.Text.Trim());

                MessageBox.Show("Autor guardado correctamente."); // Mensaje de éxito

                // Limpiar los campos de texto después de guardar correctamente
                txtIdAutor.Clear();
                txtNombreAutor.Clear();
            }
        }

        private bool ValidarCampos(TextBox textBox, string nombreCampo)
        {
            string texto = textBox.Text.Trim();

            // Verificar que el campo no esté vacío
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show($"Por favor, complete el campo '{nombreCampo}'."); // Mostrar mensaje de campo incompleto
                return false; // Indicar que la validación falló
            }

            return true; // Indicar que la validación pasó correctamente
        }

        private void txtIdAutor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado si no es un número o una tecla de control
            }
        }

        private void txtNombreAutor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y teclas de control (como Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado si no es una letra o una tecla de control
            }
        }
    }
}
