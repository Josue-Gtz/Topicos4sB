using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;
using System.Linq.Expressions;

namespace Base_de_datos_T
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCBD_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = "Server=JOSUE\\SQLEXPRESS;" +
                    "Database=master;" +
                    "User Id=sa;" +
                    "Password=2050";
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CREATE DATABASE ESCOLAR";
                cmd.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erreor del sistema");
            }
        }

        private void btnCT_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = "Server=JOSUE\\SQLEXPRESS;" +
                    "Database=ESCOLAR;" +
                    "User Id=sa;" +
                    "Password=2050";
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CREATE TABLE " +
                    "Alumnos (NoControl varchar(10), nombre varchar(50), carrera int)";
                cmd.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erreor del sistema");
            }
        }
    }
}
