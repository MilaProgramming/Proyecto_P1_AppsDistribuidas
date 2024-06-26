using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Newtonsoft.Json;

namespace GUI_V_2
{
    public partial class EliminarDetalles : Form
    {
        private HttpClient client;
        public EliminarDetalles()
        {
            InitializeComponent();

            // Inicializar HttpClient
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar el formulario para que tenga scroll automático
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 1000); // Tamaño mínimo del área de desplazamiento

            // Llenar los ComboBox al iniciar el formulario
            LoadCategorias();
            LoadEditoriales();
            LoadAutores();
            LoadLibros();
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


        private int ObtenerIdCategoriaSeleccionada()
        {
            if (cmbCategoria.SelectedValue != null && int.TryParse(cmbCategoria.SelectedValue.ToString(), out int categoriaId))
            {
                return categoriaId;
            }
            return -1; // Valor por defecto si no hay categoría seleccionada o no se puede convertir el valor a int
        }

        private int ObtenerIdEditorialSeleccionada()
        {
            if (cmbEditorial.SelectedValue != null && int.TryParse(cmbEditorial.SelectedValue.ToString(), out int editorialId))
            {
                return editorialId;
            }
            return -1; // Valor por defecto si no hay editorial seleccionada o no se puede convertir el valor a int
        }
        private int ObtenerIdAutorSeleccionado()
        {
            if (cmbAutor.SelectedValue != null && int.TryParse(cmbAutor.SelectedValue.ToString(), out int autorId))
            {
                return autorId;
            }
            return -1; // Valor por defecto si no hay autor seleccionado o no se puede convertir el valor a int
        }

        private async void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            int idCategoria = ObtenerIdCategoriaSeleccionada();

            if (idCategoria == -1)
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string url = $"https://localhost:44316/api/Categoria/BorrarCategoria/{idCategoria}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("La categoría se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //await VerCategoriasAsync(); // Método para volver a cargar las categorías
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar la categoría: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnEliminarEditorial_Click(object sender, EventArgs e)
        {
            int idEditorial = ObtenerIdEditorialSeleccionada();

            if (idEditorial == -1)
            {
                MessageBox.Show("Seleccione una editorial para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string url = $"https://localhost:44316/api/Editorial/BorrarEditorial/{idEditorial}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("La editorial se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //await VerEditorialesAsync(); // Método para volver a cargar las editoriales
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar la editorial: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la editorial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnEliminarAutor_Click(object sender, EventArgs e)
        {
            int idAutor = ObtenerIdAutorSeleccionado();

            if (idAutor == -1)
            {
                MessageBox.Show("Seleccione un autor para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string url = $"https://localhost:44316/api/Autor/BorrarAutor/{idAutor}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("El autor se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //await VerAutoresAsync(); // Método para volver a cargar los autores
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar el autor: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el autor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadLibros()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Libro/VerLibros");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Libro> libros = JsonConvert.DeserializeObject<List<Libro>>(json);
                    cmbLibro.DataSource = libros;
                    cmbLibro.DisplayMember = "lib_nombre"; // Ajusta según el nombre de la propiedad que quieres mostrar
                    cmbLibro.ValueMember = "lib_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}");
            }
        }

        private int ObtenerIdLibroSeleccionado()
        {
            if (cmbLibro.SelectedValue != null && int.TryParse(cmbLibro.SelectedValue.ToString(), out int libroId))
            {
                return libroId;
            }
            return -1; // Valor por defecto si no hay libro seleccionado o no se puede convertir el valor a int
        }

        private async void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            int idLibro = ObtenerIdLibroSeleccionado();

            if (idLibro == -1)
            {
                MessageBox.Show("Seleccione un libro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string url = $"https://localhost:44316/api/Libro/BorrarLibro/{idLibro}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("El libro se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //await LoadLibrosAsync(); // Método para volver a cargar los libros
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar el libro: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el libro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
