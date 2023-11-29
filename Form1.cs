using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoShow
{
    public partial class Form1 : Form
    {
        List<Image> photos = new List<Image>();
        int pic_pointer = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_slideShow_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            { timer1.Enabled = false;
                btn_slideShow.Text = "Start Slide Show";
            }
            else
            { timer1.Enabled = true;
                btn_slideShow.Text = "Stop Slide Show";
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.Filter = "JPEG|*.jpg|PNG|*.png|GIF|*.gif|BMP|*.bmp";
            openFileDialog1.Multiselect = false;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog(this);
            string chosen_file = openFileDialog1.FileName;
            photos.Add(Image.FromFile(chosen_file));
            pictureBox1.Image = photos[photos.Count-1];
            pic_pointer=photos.Count-1;
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            pic_pointer--;
            if (pic_pointer < 0) {  pic_pointer = photos.Count-1; }
            pictureBox1.Image = photos[pic_pointer];
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            pic_pointer++;
            if (pic_pointer >= photos.Count) { pic_pointer = 0; }
            pictureBox1.Image = photos[pic_pointer];

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pic_pointer++;
            if(pic_pointer >= photos.Count)
            { pic_pointer = 0;                
            }
            pictureBox1.Image = photos[pic_pointer];
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval=((int)(numericUpDown1.Value*1000));
        }
    }
}
