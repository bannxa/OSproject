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
    public partial class Form3: Form
    {
        class prcss
        {
            public int ID;
            public int arrival;
            public int burst;
            public int CT;
            public int TAT;
            public int WT;
        }
        List<prcss> process = new List<prcss>();
        int flagc;
        public Form3(int flag)
        {
            flagc = flag;
            InitializeComponent();
            
        }
        

        private void Form3_Load(object sender, EventArgs e)
        {

            if (flagc == 1)
            {
                label1.Text = "FCFS";
            }
            else if (flagc == 2)
            {
                label1.Text = "SJF-P";
            }
            else if (flagc == 3)
            {
                label1.Text = "SJF-NP";
            }
            else if (flagc == 4)
            {
                label1.Text = "Priority-P";
            }
            else if (flagc == 5)
            {
                label1.Text = "Priority-NP";
            }
            else if (flagc == 6)
            {
                label1.Text = "RR";
            }


            this.BackColor = Color.Gray;
            dataGridView1.Columns.Add("pid", "Process ID");
            dataGridView1.Columns.Add("arrival", "Arrival Time");
            dataGridView1.Columns.Add("burst", "Burst Time");
            dataGridView1.Columns.Add("completion", "C.T.");
            dataGridView1.Columns.Add("wait", "Waiting Time");
            dataGridView1.Columns.Add("TAT", "T.A. Time");
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int i = 0; i < process.Count; i++)
            {
                dataGridView1.Rows.Add(process[i].ID, process[i].arrival, process[i].burst, process[i].CT, process[i].WT, process[i].TAT);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prcss pnn = new prcss();
            pnn.ID = process.Count + 1;
            pnn.arrival = Convert.ToInt32(textBox1.Text);
            pnn.burst = Convert.ToInt32(textBox2.Text);
            process.Add(pnn);
            int i = process.Count - 1;
            dataGridView1.Rows.Add(process[i].ID, process[i].arrival, process[i].burst, "", "", "");
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flagc == 1)
            {
               
            }
            else if (flagc == 2)
            {
                
            }
            else if (flagc == 3)
            {
                
            }
            else if (flagc == 4)
            {
               
            }
            else if (flagc == 5)
            {
                
            }
            else if (flagc == 6)
            {
                
            }
        }
    }
}
