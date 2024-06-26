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
    public partial class ActualizarLibro : Form
    {
        private HttpClient client;
        public ActualizarLibro()
        {
            InitializeComponent();
            client = new HttpClient();
            InicializarHttpClient();
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisponible.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            // Llenar los ComboBox al iniciar el formulario
            LoadLibros();
            
        }

        private void InicializarHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
