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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtContrasenia.Text;

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasenia))
            {
                MessageBox.Show("Por favor, complete todos los campos."); // Mostrar mensaje de campos incompletos
                return; // Salir del método sin continuar con la validación
            }
            // Validar usuario y contraseña
            if (usuario.ToLower() == "admin" && contrasenia == "admin")
            {
                this.Hide(); // Ocultar el formulario actual si es necesario
                Form1 form1 = new Form1(); // Crear una instancia del formulario principal
                form1.Show(); // Mostrar el formulario principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Inténtelo nuevamente."); // Mensaje de error
            }
        }


        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            // Mostrar asteriscos en lugar de caracteres para la contraseña
            txtContrasenia.PasswordChar = '*';
        }


        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
