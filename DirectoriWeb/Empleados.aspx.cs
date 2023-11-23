using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Web.UI;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Xml.Linq;


namespace DirectoriWeb
{
    public partial class Empleados : System.Web.UI.Page
    {
        private Byte[] bytesImagen;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            // Crea una nueva instancia de la clase MySqlConnection
            MySqlConnection conexion = new MySqlConnection("Data Source=localhost;Initial Catalog=directorio_empleados;User ID=Geison;Password=981015");
            conexion.Open();

            // Crea una nueva instancia de la clase MySqlCommand
            MySqlCommand comando = new MySqlCommand("SELECT * FROM empleados", conexion);

            // Ejecuta el comando y almacena el resultado en un DataTable
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            DataTable dtDatos = new DataTable();
            adaptador.Fill(dtDatos);
            // Cerrar la conexión
            conexion.Close();

            // Vincula la tabla de datos al GridView
            GridView1.DataSource = dtDatos;
            GridView1.DataBind();


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene los datos de los campos de entrada
                string documento = txtDocumento.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cargo = txtCargo.Text;
                int numeroOficina = int.Parse(txtNumeroOficina.Text);
                int telefonoMovil = int.Parse(txtTelefonoMovil.Text);
                byte[] fotografia = FileUpload1.FileBytes;




                // Comprueba si todos los campos están completos
                if (documento == "" || nombre == "" || apellido == "" || cargo == "" || numeroOficina == 0 || telefonoMovil == 0 || fotografia == null)
                {
                    // Mostrar un mensaje de error
                    Console.WriteLine("Debe completar todos los campos.");
                }
                else
                {
                    Console.WriteLine("Todos los campos están completos.");
                }

                // Crea una conexión a la base de datos
                MySqlConnection conexion = new MySqlConnection("Data Source=localhost;Initial Catalog=directorio_empleados;User ID=Geison;Password=981015");
                conexion.Open();


                // Prepara una consulta SQL
                MySqlCommand comando = new MySqlCommand("INSERT INTO empleados (documento, nombre, apellido, cargo, numeroOficina, telefonoMovil, fotografia) VALUES (@documento, @nombre, @apellido, @cargo, @numeroOficina, @telefonoMovil, @fotografia)", conexion);
                
                comando.Parameters.AddWithValue("@documento", documento);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@cargo", cargo);
                comando.Parameters.AddWithValue("@numeroOficina", numeroOficina);
                comando.Parameters.AddWithValue("@telefonoMovil", telefonoMovil);
                comando.Parameters.AddWithValue("@fotografia", fotografia);
                comando.ExecuteNonQuery();


                // Close the connection
                conexion.Close();
               
                // Show a success message
                MessageBox.Show("Empleado agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene los datos de los campos de entrada
                string documento = txtDocumento.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cargo = txtCargo.Text;
                int numeroOficina = int.Parse(txtNumeroOficina.Text);
                int telefonoMovil = int.Parse(txtTelefonoMovil.Text);
                byte[] fotografia = FileUpload1.FileBytes;


                // Comprueba si todos los campos están completos
                if (documento == "" || nombre == "" || apellido == "" || cargo == "" || numeroOficina == 0 || telefonoMovil == 0 || fotografia == null)
                {
                    // Mostrar un mensaje de error
                    Console.WriteLine("Debe completar todos los campos.");
                }
                else
                {
                    Console.WriteLine("Todos los campos están completos.");
                }

                // Consulta la base de datos para obtener el documento del empleado
                MySqlConnection conexion = new MySqlConnection("Data Source=localhost;Initial Catalog=directorio_empleados;User ID=Geison;Password=981015");
                conexion.Open();

                MySqlCommand command = new MySqlCommand("SELECT documento FROM empleados WHERE documento=@documento", conexion);
                command.Parameters.AddWithValue("@documento", documento);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // El documento existe
                    documento = reader["documento"].ToString();
                }
                else
                {
                    // El documento no existe
                    MessageBox.Show("El documento no existe.");
                    return;
                }
                reader.Close();
                // Actualiza los datos del empleado
                command = new MySqlCommand("UPDATE empleados SET nombre = @nombre, apellido = @apellido, cargo = @cargo, numeroOficina = @numeroOficina, telefonoMovil = @telefonoMovil, fotografia = @fotografia WHERE documento = @documento", conexion);
                command.Parameters.AddWithValue("@documento", documento);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@cargo", cargo);
                command.Parameters.AddWithValue("@numeroOficina", numeroOficina);
                command.Parameters.AddWithValue("@telefonoMovil", telefonoMovil);
                command.Parameters.AddWithValue("@fotografia", fotografia);

                command.ExecuteNonQuery();

                conexion.Close();
                // Muestra un mensaje de confirmación
                MessageBox.Show("Los datos se actualizaron correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error
                MessageBox.Show(ex.Message);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene el documento del campo de entrada
                string documento = txtDocumento.Text;

                // Comprueba si el documento está vacío
                if (documento == "")
                {
                    // Muestra un mensaje de error
                    MessageBox.Show("Debe introducir un documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica si el documento existe en la base de datos
                using (MySqlConnection conexion = new MySqlConnection("Data Source=localhost;Initial Catalog=directorio_empleados;User ID=Geison;Password=981015"))
                {
                    conexion.Open();

                    MySqlCommand comando = new MySqlCommand("SELECT documento FROM empleados WHERE documento = @documento", conexion);
                    comando.Parameters.AddWithValue("@documento", documento);

                    var reader = comando.ExecuteReader();

                    if (!reader.Read())
                    {
                        // El documento no existe
                        MessageBox.Show("El documento no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    reader.Close();
                    // El documento existe

                    // Ejecuta la consulta de eliminación
                    comando = new MySqlCommand("DELETE FROM empleados WHERE documento=@documento", conexion);
                    comando.Parameters.AddWithValue("@documento", documento);

                    comando.ExecuteNonQuery();

                    // Close the connection
                    conexion.Close();

                    // Show a success message
                    MessageBox.Show("Empleado borrado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Show an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia los campos de entrada
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCargo.Text = "";
            txtNumeroOficina.Text = "";
            txtTelefonoMovil.Text = "";
            // Puedes agregar más campos según sea necesario

            // Limpia la imagen si estás utilizando un control FileUpload
            FileUpload1.Dispose();
        }
    }
}

