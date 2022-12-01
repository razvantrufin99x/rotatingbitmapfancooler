using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rotatingbitmapfancooler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bitmap1;
        int ismd = 0;

        private void InitializeBitmap()
        {
            try
            {
                bitmap1 = (Bitmap)Bitmap.FromFile(@"imagini\rotating.bmp");
                PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                PictureBox1.Image = bitmap1;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the bitmap.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBitmap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bitmap1 != null)
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate90FlipY);
                PictureBox1.Image = bitmap1;
                bitmap1.RotateFlip(RotateFlipType.Rotate270FlipY);
                PictureBox1.Image = bitmap1;
                bitmap1.RotateFlip(RotateFlipType.Rotate90FlipY);
                PictureBox1.Image = bitmap1;
                bitmap1.RotateFlip(RotateFlipType.Rotate90FlipY);
                PictureBox1.Image = bitmap1;
               
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = 0;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismd == 1)
            {
                Left += e.X;
                Top += e.Y;
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = 1;
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
