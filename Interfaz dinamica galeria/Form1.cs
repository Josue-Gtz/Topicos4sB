using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaz_dinamica_galeria
{
    public partial class Form1 : Form
    {
        private PictureBox PicBoxC;
        private PictureBox selectedPictureBox = null;
        private List<PictureBox> dinapictureBoxes = new List<PictureBox>();
        private List<Label> dinalabels = new List<Label>();
        private int controlCounter = 1;
        public Form1()
        {
            InitializeComponent();
        }


        public void PictureBox_Click(object sender, EventArgs e)
        {
            String txtImagen = textBox1.Text;

            selectedPictureBox = sender as PictureBox;
            Form2 abrir = new Form2(txtImagen);

            if (selectedPictureBox != null)
            {
                abrir.ImagenPic(selectedPictureBox.Image);
                abrir.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int ancho = 120;  
                int alto = 130; 
                int marX = 20;     
                int marY = 20;     
                int columnaActual = dinapictureBoxes.Count % 5; 
                int filaActual = dinapictureBoxes.Count / 5;    

                int posiX = marX + (columnaActual * ancho);
                int posiY = marY + (filaActual * alto);

                Label newlabel = new Label();
                newlabel.Size = new Size(100, 20);
                newlabel.Location = new Point(posiX, posiY);
                newlabel.Text = "Imagen " + controlCounter;
                this.Controls.Add(newlabel);
                dinalabels.Add(newlabel);

                PicBoxC = new PictureBox();
                PicBoxC.Size = new Size(100, 100);
                PicBoxC.SizeMode = PictureBoxSizeMode.Zoom;
                PicBoxC.Location = new Point(posiX, posiY + 25);
                this.Controls.Add(PicBoxC);
                dinapictureBoxes.Add(PicBoxC);
                PicBoxC.Click += PictureBox_Click;


                using (var stream = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    PicBoxC.Image = Image.FromStream(stream);
                }

                textBox1.Text = dlg.FileName;
                controlCounter++;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Creación Dinámica de Controles";
            this.Size = new Size(700, 700);

            
        }


       

    }
}
