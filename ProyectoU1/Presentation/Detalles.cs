using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms; // Asegúrate de que esta directiva también esté presente si usas MessageBox.Show
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using Data;
using Newtonsoft.Json;



namespace GUI_V_2
{
    public partial class Detalles : Form
    {
        private HttpClient client; // Declarar HttpClient como un campo privado

        public Detalles()
        {
            InitializeComponent();

            // Configurar el formulario para que tenga scroll automático
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 800); // Tamaño mínimo del área de desplazamiento

            // Inicializar HttpClient
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region Funciones y Validaciones
        private void LimpiarCampos(params TextBox[] campos)
        {
            foreach (var campo in campos)
            {
                campo.Clear();
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
        #endregion

        #region Eventos

            #region Autor
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
            #endregion

            #region Editorial
            private void txtIdEditorial_KeyPress(object sender, KeyPressEventArgs e)
            {
                // Permitir solo números y teclas de control (como Backspace)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignorar el carácter ingresado si no es un número o una tecla de control
                }
            }

            private void txtNombreEditorial_KeyPress(object sender, KeyPressEventArgs e)
            {
                // Permitir solo letras y teclas de control (como Backspace)
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignorar el carácter ingresado si no es una letra o una tecla de control
                }
            }
            #endregion

            #region Categoria
            private void txtIdCategoria_KeyPress(object sender, KeyPressEventArgs e)
            {
                // Permitir solo números y teclas de control (como Backspace)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignorar el carácter ingresado si no es un número o una tecla de control
                }
            }

            private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
            {
                // Permitir solo letras y teclas de control (como Backspace)
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignorar el carácter ingresado si no es una letra o una tecla de control
                }
            }
        #endregion

        #endregion

        #region Boton Guardar

        private async void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(txtNombreAutor, "Nombre de autor"))
            {
                string nombreAutor = txtNombreAutor.Text.Trim();

                try
                {
                    await CrearAutorAsync(nombreAutor);
                    MessageBox.Show("Autor guardado correctamente.");
                    LimpiarCampos(txtNombreAutor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el autor: {ex.Message}");
                }
            }
        }

        private async Task CrearAutorAsync(string nombreAutor)
        {
            var autor = new { aut_nombre = nombreAutor };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Autor/CrearAutor", autor);

            if (response.IsSuccessStatusCode)
            {
                LimpiarCampos(txtNombreAutor);
            }
            else
            {
                string mensajeError = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error al guardar el autor: {mensajeError}");
            }
        }


        private async void btnGuardarEditorial_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(txtNombreEditorial, "Nombre de editorial"))
            {
                string nombreEditorial = txtNombreEditorial.Text.Trim();

                try
                {
                    await CrearEditorialAsync(nombreEditorial);
                    MessageBox.Show("Editorial guardada correctamente.");
                    LimpiarCampos(txtNombreEditorial);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la editorial: {ex.Message}");
                }
            }
        }

        private async Task CrearEditorialAsync(string nombreEditorial)
        {
            var editorial = new { edi_nombre = nombreEditorial };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Editorial/CrearEditorial", editorial);

            if (response.IsSuccessStatusCode)
            {
                LimpiarCampos(txtNombreEditorial);
            }
            else
            {
                string mensajeError = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error al guardar la editorial: {mensajeError}");
            }
        }


        private async void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(txtNombreCategoria, "Nombre de categoría"))
            {
                string nombreCategoria = txtNombreCategoria.Text.Trim();

                try
                {
                    await CrearCategoriaAsync(nombreCategoria);
                    MessageBox.Show("Categoría guardada correctamente.");
                    LimpiarCampos(txtNombreCategoria);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la categoría: {ex.Message}");
                }
            }
        }

        private async Task CrearCategoriaAsync(string nombreCategoria)
        {
            var categoria = new { cat_nombre = nombreCategoria };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Categoria/CrearCategoria", categoria);

            if (response.IsSuccessStatusCode)
            {
                LimpiarCampos(txtNombreCategoria);
            }
            else
            {
                string mensajeError = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error al guardar la categoría: {mensajeError}");
            }
        }

        #endregion

        private void txtNombreAutor_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnVerCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Categoria/VerCategorias");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Categoria> categorias = JsonConvert.DeserializeObject<List<Categoria>>(json);

                    TablaProductos.DataSource = categorias; // Asignar las categorías a la tabla (DataGridView)
                    ConfigurarDataGridView(TablaProductos); // Configurar el DataGridView después de asignar el DataSource
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener las categorías: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView(DataGridView dataGridView)
        {
            // Configurar la tabla para que no permita la edición
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnVerAutor_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Autor/VerAutor");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Autor> autores = JsonConvert.DeserializeObject<List<Autor>>(json);

                    TablaProductos.DataSource = autores; // Asignar los autores a la tabla (DataGridView)
                    ConfigurarDataGridView(TablaProductos); // Configurar el DataGridView después de asignar el DataSource
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener los autores: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los autores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnVerEditorial_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Editorial/VerEditorial");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Editorial> editoriales = JsonConvert.DeserializeObject<List<Editorial>>(json);

                    TablaProductos.DataSource = editoriales; // Asignar las editoriales a la tabla (DataGridView)
                    ConfigurarDataGridView(TablaProductos); // Configurar el DataGridView después de asignar el DataSource
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener las editoriales: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las editoriales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
