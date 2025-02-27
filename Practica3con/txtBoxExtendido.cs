using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3con
{
    public partial class txtBoxExtendido : UserControl
    {
        public txtBoxExtendido()
        {
            InitializeComponent();
        }
        
        private void definirTipo(object sender, KeyEventArgs e)
        {
            MessageBox.Show("sdsf");

            bool permitido = false;

            if(permitido == false)
            {
                textBox1.BackColor = Color.Red;
            }
        }
        public bool OnlyNumbers(string texto)
        {
            return Regex.IsMatch(texto, @"^\d+$");

        }
        public bool OnlyLetters(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }
    }
}
