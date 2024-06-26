using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Newtonsoft.Json;

namespace GUI_V_2
{
    public partial class Productos : Form
    {
        private HttpClient client;
        public Productos()
        {
            InitializeComponent();

            // Inicializar HttpClient
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Llenar los ComboBox al iniciar el formulario
            LoadCategorias();
            LoadEditoriales();
            LoadAutores();

            // Configurar el ComboBox
            cmbDisponible.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;

            // Agregar ítems al ComboBox
            cmbDisponible.Items.Add("Disponible");
            cmbDisponible.Items.Add("No disponible");

            // Asociar el evento SelectedIndexChanged con su manejador
            cmbDisponible.SelectedIndexChanged += new EventHandler(cmbDisponible_SelectedIndexChanged);
            // Configurar el formulario para que tenga scroll automático
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 1000); // Tamaño mínimo del área de desplazamiento
        }

        private async void LoadCategorias()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Categoria/VerCategorias");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Categoria> categorias = JsonConvert.DeserializeObject<List<Categoria>>(json);
                    cmbCategoria.DataSource = categorias;
                    cmbCategoria.DisplayMember = "cat_nombre"; // Ajusta según el nombre de la propiedad que quieres mostrar
                    cmbCategoria.ValueMember = "cat_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}");
            }
        }

        private async void LoadEditoriales()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Editorial/VerEditorial");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Editorial> editoriales = JsonConvert.DeserializeObject<List<Editorial>>(json);
                    cmbEditorial.DataSource = editoriales;
                    cmbEditorial.DisplayMember = "edi_nombre"; // Ajusta según el nombre de la propiedad que quieres mostrar
                    cmbEditorial.ValueMember = "edi_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las editoriales: {ex.Message}");
            }
        }

        private async void LoadAutores()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Autor/VerAutor");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Autor> autores = JsonConvert.DeserializeObject<List<Autor>>(json);
                    cmbAutor.DataSource = autores;
                    cmbAutor.DisplayMember = "aut_nombre"; // Ajusta según el nombre de la propiedad que quieres mostrar
                    cmbAutor.ValueMember = "aut_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los autores: {ex.Message}");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdLibro_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombreLibro.Text) ||
                cmbCategoria.SelectedIndex == -1 ||
                cmbEditorial.SelectedIndex == -1 ||
                cmbAutor.SelectedIndex == -1 ||
                cmbDisponible.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, llene todos los campos antes de guardar el libro.");
                return;
            }

            // Obtener los valores seleccionados
            int categoriaId = (int)cmbCategoria.SelectedValue;
            int editorialId = (int)cmbEditorial.SelectedValue;
            int autorId = (int)cmbAutor.SelectedValue;
            string disponibilidad = cmbDisponible.SelectedItem?.ToString();  // Uso de operador null-coalescing
            bool disponibilidadValor = disponibilidad == "Disponible";
            string nombreLibro = txtNombreLibro.Text.Trim();

            // Crear el objeto libro con los valores seleccionados
            var libro = new
            {
                lib_nombre = nombreLibro,
                lib_disponible = disponibilidadValor,
                cat_id = categoriaId,
                edi_id = editorialId,
                aut_id = autorId
            };

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Libro/CrearLibro", libro);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Libro guardado correctamente.");
                    LimpiarCampos();
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al guardar el libro: {mensajeError}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el libro: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            txtNombreLibro.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbEditorial.SelectedIndex = -1;
            cmbAutor.SelectedIndex = -1;
            cmbDisponible.SelectedIndex = -1;
        }

        private async void btnVerCategoria_Click(object sender, EventArgs e)
        {
            await VerLibrosAsync();
        }

        private async Task VerLibrosAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Libro/VerLibros");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Libro> libros = JsonConvert.DeserializeObject<List<Libro>>(json);

                    TablaProductos.DataSource = libros; // Asignar los libros a la tabla (DataGridView)
                    ConfigurarDataGridView(TablaProductos); // Configurar DataGridView después de asignar el DataSource
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener los libros: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los libros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void cmbDisponible_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisponible.SelectedItem != null)
            {
                // Obtener el ítem seleccionado
                string selectedItem = cmbDisponible.SelectedItem.ToString();
                int disponibilidad = selectedItem == "Disponible" ? 1 : 0;
            }
            else
            {
                // Manejar el caso en que no hay ningún ítem seleccionado
                MessageBox.Show("Por favor, seleccione una opción de disponibilidad.");
            }
        }


        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEditorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
