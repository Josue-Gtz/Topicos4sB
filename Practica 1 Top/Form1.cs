using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_1_Top
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> listaData = new List<string>();
        //hace una lista

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listaData.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione un contacto");
            }
            listBox1.DataSource = null;
            listBox1.DataSource = listaData;

            //si esta indicado lo remueve de la lista, sino le dice que lo seleccione
            //y luego actualiza el listbox
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            listaData.Clear();
            listBox1.DataSource = null;
            listBox1.DataSource = listaData;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            //limpia todo
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            //hace variables los textos de las cajas y los une
            string nombre = textBox1.Text;
            string numero = textBox2.Text;
            string correoE = textBox3.Text;
            string data = "Nombre: " + nombre + " Número: " + numero + " Correo Electronico: " + correoE;
            //Envia la variable data a la lista
            listaData.Add(data);
            listBox1.DataSource = null;
            listBox1.DataSource = listaData;
            MessageBox.Show(nombre +" ha sido agregado" );
            //Actualiza y confirma
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //para salir 
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este es un directorio de contactos hecho por Josué GutiÉrrez" +
                " \n " + "Encarcado por el profesor Luis Armando Cárdenas Florido \n" +
                " Hecho para el 10/02/25 ");
            //info
        }
    }
}
