using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GUI_V_2
{
    public partial class InicioResumen : Form
    {
        private HttpClient client;
        public InicioResumen()
        {
            InitializeComponent();
            // Inicializar HttpClient
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            VerLibrosAsync();// Ver los libros al iniciar el formulario

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
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
        private void TablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
