using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3con
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            button1.MouseEnter += Button1_MouseEnter;
            button1.MouseLeave += Button1_MouseLeave;
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = default(Color);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && e.Clicks==2)
            {
                DialogResult resultado = MessageBox.Show("Quieres continuar?", "Confirmacion"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    MessageBox.Show("Has confirmado la accion");
                }
            }
        }
    }
}
