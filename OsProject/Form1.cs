using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OsProject
{
    public partial class Form1: Form
    {
        
        public Form1()
        {
            InitializeComponent();
          
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.ClientSize.Width/2,0);
            this.BackColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }
    }
}
