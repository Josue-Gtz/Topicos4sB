using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_dinamica_galeria
{
    public partial class Form2 : Form
    {
        public Form2(String texx)
        {
            InitializeComponent();
            this.Text = "Imagen " + texx;
        }
        public void ImagenPic(Image img)
        {
            Form1 form1 = new Form1();
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Size = new Size(999, 699);
            
        }
        public void Form2_Load(object sender, EventArgs e)
        {
           // this.Text = "Imagen"+ texx ;
            this.Size = new Size(1000, 700);
        }
        
        

        

    }
}
