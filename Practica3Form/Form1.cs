using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practica3con;

namespace Practica3Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        ValiRFC validarRFC = new ValiRFC();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rfc = textBox1.Text;
            bool validar = validarRFC.EsRFCValido(textBox1.Text);
            if (!validarRFC.EsRFCValido(rfc))
            {
                MessageBox.Show("El RFC ingresado es inválido o está vacío"); 
            }
            else
            {
                MessageBox.Show("RFC Incorrecto debe tener el formato: AAAA######XXX");
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLetra_TextChanged(object sender, EventArgs e)
        {
            InputValor valorIN = new InputValor();
            valorIN.Letras(textBoxLetra.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputValor validacion = new InputValor();
            bool validar = validacion.Letras(textBoxLetra.Text);
            if (validar == true)
            {
                MessageBox.Show("Solo hay letras en la caja de texto");
            }
            else
            {
                MessageBox.Show("No contiene solo letras");
            }
        }
    }
}
