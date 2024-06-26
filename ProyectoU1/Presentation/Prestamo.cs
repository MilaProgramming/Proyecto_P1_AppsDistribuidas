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
using System.Net.Http;
using System.Net.Http.Formatting; // Añadir esta referencia
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Data;
using Negocio;


namespace GUI_V_2
{
    public partial class Prestamo : Form
    {
        private HttpClient client;
        public Prestamo()
        {
            InitializeComponent();
            client = new HttpClient();
            InicializarHttpClient();
            // Llenar los ComboBox al iniciar el formulario
            LoadLibros();
            LoadUsuarios();

            // Configurar el ComboBox
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar los DateTimePickers
            dateTimePicker1.MinDate = new DateTime(1990, 1, 1);
            dateTimePicker2.MaxDate = new DateTime(2025, 12, 31);

            // Asociar los eventos ValueChanged
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;

            // Configurar el formulario para que tenga scroll automático
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 1000); // Tamaño mínimo del área de desplazamiento
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

        private async void LoadUsuarios()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Usuario/VerUsuarios");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                    cmbCliente.DataSource = usuarios;
                    cmbCliente.DisplayMember = "usu_cedula"; // Ajusta según el nombre de la propiedad que quieres mostrar
                    cmbCliente.ValueMember = "usu_cedula";
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener los usuarios: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void LimpiarCampos()
        {
            cmbLibro.SelectedIndex = -1;
            cmbCliente.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        // Método para manejar el evento de clic en el botón Ver Préstamo
        private async void btnVerPrestamo_Click(object sender, EventArgs e)
        {
            await VerPrestamosAsync();
        }

        private async Task VerPrestamosAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Prestamo/VerPrestamos");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<PrestamoDTO> prestamos = JsonConvert.DeserializeObject<List<PrestamoDTO>>(json);

                    TablaPrestamos.DataSource = prestamos;
                    ConfigurarDataGridView(); // Configurar DataGridView después de asignar el DataSource
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener los préstamos: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los préstamos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void TablaPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbLibro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        private async void btnGuardarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos estén llenos
                if (cmbLibro.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un libro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbCliente.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores de los DateTimePicker y ComboBox
                DateTime fechaInicio = dateTimePicker1.Value;
                DateTime fechaFinal = dateTimePicker2.Value;
                int libroId = (int)cmbLibro.SelectedValue;
                int usuarioCedula = (int)cmbCliente.SelectedValue;

                // Crear el objeto PrestamoDTO
                var nuevoPrestamo = new PrestamoDTO
                {
                    pre_fecha_inicio = fechaInicio,
                    pre_fecha_final = fechaFinal,
                    lib_id = libroId,
                    usu_cedula = usuarioCedula
                };

                // Convertir el objeto a JSON
                string json = JsonConvert.SerializeObject(nuevoPrestamo);

                // Configurar el contenido de la solicitud
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST a la API
                HttpResponseMessage response = await client.PostAsync("api/Prestamo/CrearPrestamo", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("El préstamo se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now.AddDays(1); // Suponiendo que el préstamo es por al menos 1 día
                    cmbLibro.SelectedIndex = -1;
                    cmbCliente.SelectedIndex = -1;
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al guardar el préstamo: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Configurar la tabla para que no permita la edición
            TablaPrestamos.ReadOnly = true;
            TablaPrestamos.AllowUserToAddRows = false;
            TablaPrestamos.AllowUserToDeleteRows = false;
            TablaPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TablaPrestamos.MultiSelect = false;
            TablaPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


    }

    // Clases auxiliares para deserializar los datos JSON
    public class Libro
    {
        public int lib_id { get; set; }
        public string lib_nombre { get; set; }
        public bool lib_disponible { get; set; }
        public int cat_id { get; set; }
        public int edi_id { get; set; }
        public int aut_id { get; set; }
    }

    public class Usuario
    {
        public int usu_cedula { get; set; }
        public string usu_nombre { get; set; }
        public string usu_apellido { get; set; }
        public string usu_usuario { get; set; }
        public string usu_contrasenia { get; set; }
    }

    public class PrestamoDTO
    {
        public DateTime pre_fecha_inicio { get; set; }
        public DateTime pre_fecha_final { get; set; }
        public int lib_id { get; set; }
        public int usu_cedula { get; set; }
    }

}
