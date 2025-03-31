using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private string Servidor = "JOSUE\\SQLEXPRESS";
        private string Basedatos = "ESCOLAR";
        private string UsuarioId = "sa";
        private string Password = "2050";
        
        private string ServidorM = "localhost";
        private string BasedatosM = "ESCOLAR";
        private string UsuarioIdM = "root";
        private string PasswordM= "";

        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                string strConnM = $"Server={ServidorM};" +
                    $"Database={BasedatosM};" +
                    $"User Id={UsuarioIdM};" +
                    $"Password={PasswordM}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = ConsultaSQL;
                    cmd.ExecuteNonQuery();
                }
                else if (chkMySQL.Checked)
                {
                    MySqlConnection conn = new MySqlConnection(strConnM); 
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = ConsultaSQL;
                    cmd.ExecuteNonQuery();
                }

                llenarGrid();

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }
        private void llenarGrid()
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";
                string strConnM = $"Server={ServidorM};" +
                    $"Database={BasedatosM};" +
                    $"User Id={UsuarioIdM};" +
                    $"Password={PasswordM}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    string sqlQuery = "select * from Alumnos";
                    SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);

                    DataSet ds = new DataSet();
                    adp.Fill(ds, "Alumnos");
                    dgvAlumnos.DataSource = ds.Tables[0];
                }
                else if (chkMySQL.Checked)
                {
                    MySqlConnection conn = new MySqlConnection(strConn);
                    conn.Open();

                    string MysqlQuery = "select * from Alumnos";
                    MySqlDataAdapter adp = new MySqlDataAdapter(MysqlQuery, conn);

                    DataSet ds = new DataSet();
                    adp.Fill(ds, "Alumnos");
                    dgvAlumnos.DataSource = ds.Tables[0];

                }

                dgvAlumnos.Refresh();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

    
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0 ||
                    txtNombre.Text.Trim().Length == 0 ||
                    txtCarrera.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }
                else {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    if (chkSQLServer.Checked)
                    {
                        SqlConnection conn = new SqlConnection(strConn);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO " +
                            "Alumnos (NoControl, nombre, carrera) " +
                            "VALUES ('" + txtNoControl.Text +
                            "', '" + txtNombre.Text +
                            "', " + txtCarrera.Text + ")";
                        cmd.ExecuteNonQuery();
                    }
                    else if (chkSQLServer.Checked)
                    {
                        MySqlConnection conn = new MySqlConnection(strConn);
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO " +
                            "Alumnos (NoControl, nombre, carrera) " +
                            "VALUES ('" + txtNoControl.Text +
                            "', '" + txtNombre.Text +
                            "', " + txtCarrera.Text + ")";
                        cmd.ExecuteNonQuery();
                    }

                    llenarGrid();
                
                }

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnCrearBD_Click_1(object sender, EventArgs e)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database=master;" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";
                string strConnM = $"Server={ServidorM};" +
                    $"Database={BasedatosM};" +
                    $"User Id={UsuarioIdM};" +
                    $"Password={PasswordM}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE DATABASE ESCOLAR";
                    cmd.ExecuteNonQuery();

                }
                else if (chkMySQL.Checked)
                {
                    MySqlConnection conn = new MySqlConnection(strConnM);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE DATABASE ESCOLAR";
                    cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void btnCreaTabla_Click_1(object sender, EventArgs e)
        {
            EjecutaComando("CREATE TABLE " +
                    "Alumnos (NoControl varchar(10), nombre varchar(50), carrera int)");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0 ||
                    txtNombre.Text.Trim().Length == 0 ||
                    txtCarrera.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Todos los campos deben estar llenos");
                    return;
                }

                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                string strConnM = $"Server={ServidorM};" +
                    $"Database={BasedatosM};" +
                    $"User Id={UsuarioIdM};" +
                    $"Password={PasswordM}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Alumnos SET nombre=@Nombre, carrera=@Carrera WHERE NoControl=@NoControl";

                    cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Carrera", txtCarrera.Text);

                    cmd.ExecuteNonQuery();
                }
                else if (chkMySQL.Checked)
                {
                    MySqlConnection conn = new MySqlConnection(strConn);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Alumnos SET nombre=@Nombre, carrera=@Carrera WHERE NoControl=@NoControl";

                    cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Carrera", txtCarrera.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registro actualizado correctamente");
                llenarGrid();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el NoControl del alumno a eliminar.");
                    return;
                }

                string strConn = $"Server={Servidor};" +
                                 $"Database={Basedatos};" +
                                 $"User Id={UsuarioId};" +
                                 $"Password={Password}";

                string strConnM = $"Server={ServidorM};" +
                                  $"Database={BasedatosM};" +
                                  $"User Id={UsuarioIdM};" +
                                  $"Password={PasswordM}";

                string query = "DELETE FROM Alumnos WHERE NoControl = @noControl";

                if (chkSQLServer.Checked)
                {
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@noControl", txtNoControl.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if (chkMySQL.Checked)
                {
                    using (MySqlConnection conn = new MySqlConnection(strConnM))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@noControl", txtNoControl.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Registro eliminado correctamente.");
                llenarGrid();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese un número de control");
                    return;
                }
                else
                {

                    string strConn = $"Server={Servidor};" +
                                     $"Database={Basedatos};" +
                                     $"User Id={UsuarioId};" +
                                     $"Password={Password}";

                    string strConnM = $"Server={ServidorM};" +
                                      $"Database={BasedatosM};" +
                                      $"User Id={UsuarioIdM};" +
                                      $"Password={PasswordM}";
                    if (chkSQLServer.Checked)
                    {

                        SqlConnection conn = new SqlConnection(strConn);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Alumnos WHERE NoControl = '{txtNoControl.Text}'";

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");

                        if (ds.Tables["Alumnos"].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables["Alumnos"].Rows[0];
                            txtNombre.Text = row["nombre"].ToString();
                            txtCarrera.Text = row["carrera"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Alumno no encontrado.");
                        }
                    }
                    else if (chkMySQL.Checked)
                    {

                        MySqlConnection conn = new MySqlConnection(strConn);
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Alumnos WHERE NoControl = '{txtNoControl.Text}'";

                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");

                        if (ds.Tables["Alumnos"].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables["Alumnos"].Rows[0];
                            txtNombre.Text = row["nombre"].ToString();
                            txtCarrera.Text = row["carrera"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontro al alumno");
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
