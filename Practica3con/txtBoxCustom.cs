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
    public partial class txtBoxCustom : UserControl
    {
        public txtBoxCustom()
        {
            InitializeComponent();

        }


        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo deja poner letras
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122)
            {
                //pone el box normal
                textBox1.BackColor = default(Color);
                textBox1.BorderStyle = BorderStyle.Fixed3D;

            }
            else
            {
                //no deja escribir y lo pone amarillo
                e.KeyChar = (char)0;
                textBox1.BackColor = Color.Yellow;
                textBox1.BorderStyle = BorderStyle.FixedSingle;

            }


        }
        

    }
}
