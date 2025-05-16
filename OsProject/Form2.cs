using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsProject
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
           
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            this.Location = new Point(this.ClientSize.Width/2 - this.Width/2, 0);
            listBox1.Items.Add("FCFS");
            listBox1.Items.Add("SJFP");
            listBox1.Items.Add("SJFNP");
            listBox1.Items.Add("PriorityP");
            listBox1.Items.Add("PriorityNP");
            listBox1.Items.Add("RR");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedItem == "FCFS")
            {
                pictureBox1.Image = Image.FromFile("Assets/FCFS.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (listBox1.SelectedItem == "SJFP")
            {
                pictureBox1.Image = Image.FromFile("Assets/SJFP.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (listBox1.SelectedItem == "SJFNP")
            {
                pictureBox1.Image = Image.FromFile("Assets/SJFNP.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (listBox1.SelectedItem == "PriorityP")
            {
                pictureBox1.Image = Image.FromFile("Assets/PP.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (listBox1.SelectedItem == "PriorityNP")
            {
                pictureBox1.Image = Image.FromFile("Assets/PNP.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (listBox1.SelectedItem == "RR")
            {
                pictureBox1.Image = Image.FromFile("Assets/RR.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "FCFS")
            {
               Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
            else if (listBox1.SelectedItem == "SJFP")
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
            else if (listBox1.SelectedItem == "SJFNP")
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
            else if (listBox1.SelectedItem == "PriorityP")
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
            else if (listBox1.SelectedItem == "PriorityNP")
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
            else if (listBox1.SelectedItem == "RR")
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
