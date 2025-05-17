using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace OsProject
{
    public partial class Form3 : Form
    {
        class prcss
        {
            public float ID;
            public float arrival;
            public float priority;
            public float burst;
            public float CT;
            public float TAT;
            public float WT;
            public float QT;
            public float Rem_Time;
        }
         List<prcss> process = new List<prcss>();
         List<float> done = new List<float>();
         float Time = 999;
         float tot;
         float min = 999;
         float flagc;
         float check = 0;
        public Form3(int flag)
        {
            flagc = flag;
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.panelGanttChart = new System.Windows.Forms.Panel();
            this.panelGanttChart.Location = new System.Drawing.Point(this.ClientSize.Width/2 - this.panelGanttChart.Width, this.ClientSize.Height - this.panelGanttChart.Height);
            this.panelGanttChart.Size = new System.Drawing.Size(610, 60);
            this.panelGanttChart.BackColor = System.Drawing.Color.White;
            this.panelGanttChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelGanttChart);
            this.panelGanttChart.Paint += panelGanttChart_Paint;


            label6.Hide();
            label4.Hide();
            label5.Hide();
            textBox3.Hide();
            textBox4.Hide();
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
                label4.Show();
                textBox3.Show();
            }
            else if (flagc == 5)
            {
                label1.Text = "Priority-NP";
                label4.Show();
                textBox3.Show();
            }
            else if (flagc == 6)
            {
                label1.Text = "RR";
                
                label5.Show();
                label5.Location = new Point(label4.Location.X, label4.Location.Y );
                textBox4.Location = new Point(textBox4.Location.X , label4.Location.Y);
                textBox4.Show();
            }
            this.BackColor = Color.Gray;
            dataGridView1.Columns.Add("pid", "Process ID");
            dataGridView1.Columns.Add("arrival", "Arrival Time");
            dataGridView1.Columns.Add("burst", "Burst Time");
            dataGridView1.Columns.Add("Pr", "Priority");
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
            if(textBox1.Text!=""|| textBox2.Text != "")
            {
                prcss pnn = new prcss();
                pnn.ID = process.Count + 1;
                pnn.arrival = Convert.ToInt32(textBox1.Text);
                pnn.burst = Convert.ToInt32(textBox2.Text);
               
                pnn.Rem_Time = pnn.burst;
                if (flagc == 4 || flagc == 5)
                {
                    pnn.priority = Convert.ToInt32(textBox3.Text);
                }
                if(flagc == 6)
                {
                    pnn.QT = Convert.ToInt32(textBox4.Text);
                    textBox4.Enabled=false;
                }
                process.Add(pnn);
                int i = process.Count - 1;
                if(flagc == 4 || flagc == 5)
                {
                    dataGridView1.Rows.Add(process[i].ID, process[i].arrival, process[i].burst, process[i].priority, "", "", "");
                    textBox3.Clear();
                }
                else
                    dataGridView1.Rows.Add(process[i].ID, process[i].arrival, process[i].burst, "", "", "");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Please fill in the textbox");
            }
        }
        void calcSJFNP()
        {
            int imin = -1;
            for (int i = 0; i < process.Count; i++)
            {
                if (done.Contains(i))
                    continue;
                if (process[i].burst < min && process[i].arrival <= Time)
                {
                    min = process[i].burst;
                    imin = i;
                    Time = process[i].arrival;
                }
            }
            tot += process[imin].burst;
            process[imin].CT = tot;
            process[imin].TAT = process[imin].CT - process[imin].arrival;
            process[imin].WT = process[imin].TAT - process[imin].burst;
            if (process[imin].TAT < 0)
            {
                process[imin].TAT = 0;
            }
            if (process[imin].WT <= 0)
            {
                process[imin].WT = 0;
            }
            done.Add(imin);
            Time = 999;
            min = 999;
        }
        private void CalculateP_NP()
        {
            int imin = -1;
            for (int i = 0; i < process.Count; i++)
            {
                if (done.Contains(i))
                    continue;
                if (process[i].priority < min && process[i].arrival <= Time)
                {
                    min = process[i].priority;
                    imin = i;
                    Time = process[i].arrival;
                }
            }
            tot += process[imin].burst;
            process[imin].CT = tot;
            process[imin].TAT = process[imin].CT - process[imin].arrival;
            process[imin].WT = process[imin].TAT - process[imin].burst;
            if (process[imin].TAT < 0)
            {
                process[imin].TAT = 0;
            }
            if (process[imin].WT < 0)
            {
                process[imin].WT = 0;
            }
            done.Add(imin);
            min = 999;
            Time = 999;
        }
        void calcSJFP()
        {
            int n = process.Count;
            float completed = 0;
            float currentTime = 0;
            float[] rem = new float[n];
            bool[] isDone = new bool[n];
            for (int i = 0; i < n; i++)
                rem[i] = process[i].burst;

            while (completed != n)
            {
                int imin = -1;
                float minRem = 999;
                for (int i = 0; i < n; i++)
                {
                    if (!isDone[i] && process[i].arrival <= currentTime && rem[i] < minRem && rem[i] > 0)
                    {
                        minRem = rem[i];
                        imin = i;
                    }
                }
                currentTime++;
                if (imin != -1)
                {
                    rem[imin]--;

                    if (rem[imin] == 0)
                    {
                        isDone[imin] = true;
                        completed++;
                        process[imin].CT = currentTime;
                        process[imin].TAT = process[imin].CT - process[imin].arrival;
                        process[imin].WT = process[imin].TAT - process[imin].burst;

                        if (process[imin].WT < 0)
                            process[imin].WT = 0;

                        done.Add(imin);
                    }
                }
               
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (flagc == 1)
            {
                CalculateFCFS();
            }
            else if (flagc == 2)
            {
                for (int i = 0; i < process.Count; i++)
                {
                    calcSJFP();
                }
                for (int i = 0; i < process.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["wait"].Value = process[i].WT;
                    dataGridView1.Rows[i].Cells["completion"].Value = process[i].CT;
                    dataGridView1.Rows[i].Cells["TAT"].Value = process[i].TAT;
                }

            }
            else if (flagc == 3)
            {
                 for (int i = 0; i < process.Count; i++)
                 {
                     calcSJFNP();
                 }
                 for (int i = 0; i < process.Count; i++)
                 {
                     dataGridView1.Rows[i].Cells["wait"].Value = process[i].WT;
                     dataGridView1.Rows[i].Cells["completion"].Value = process[i].CT;
                     dataGridView1.Rows[i].Cells["TAT"].Value = process[i].TAT;
                 }

            }
            else if (flagc == 4)
            {
                CalcPP();
                for (int i = 0; i < process.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["wait"].Value = process[i].WT;
                    dataGridView1.Rows[i].Cells["completion"].Value = process[i].CT;
                    dataGridView1.Rows[i].Cells["TAT"].Value = process[i].TAT;
                }

            }
            else if (flagc == 5)
            {
                for (int i = 0; i < process.Count; i++)
                {
                    CalculateP_NP();
                }
                
                for (int i = 0; i < process.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["wait"].Value = process[i].WT;
                    dataGridView1.Rows[i].Cells["completion"].Value = process[i].CT;
                    dataGridView1.Rows[i].Cells["TAT"].Value = process[i].TAT;
                }
            }
            else if (flagc == 6)
            {
                calcRR();
                for (int i = 0; i < process.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["wait"].Value = process[i].WT;
                    dataGridView1.Rows[i].Cells["completion"].Value = process[i].CT;
                    dataGridView1.Rows[i].Cells["TAT"].Value = process[i].TAT;
                }
            }
            if(process.Count>0)
            {
                    float avgWT = process.Sum(x => x.WT) / process.Count;
                    float avgTAT = process.Sum(x => x.TAT) / process.Count;
                    label6.Text ="Average waiting time is : " + avgWT.ToString() + "\n" + "Average turn around time is : " + avgTAT.ToString();
                    label6.Show();
            }
           
            panelGanttChart.Invalidate();
        }
        private void CalculateFCFS()
        {
            int n = process.Count;
            process[0].CT = process[0].arrival + process[0].burst;
            process[0].TAT = process[0].CT - process[0].arrival;
            process[0].WT = process[0].TAT - process[0].burst;

            for (int i = 1; i < n; i++)
            {
                if (process[i].arrival > process[i - 1].CT)
                {
                    process[i].CT = process[i].arrival + process[i].burst;
                }
                else
                {
                    process[i].CT = process[i - 1].CT + process[i].burst;
                }
                process[i].TAT = process[i].CT - process[i].arrival;
                process[i].WT = process[i].TAT - process[i].burst;
            }
            dataGridView1.Rows.Clear();
            for (int i = 0; i < process.Count; i++)
            {
                dataGridView1.Rows.Add
                (
                    process[i].ID,
                    process[i].arrival,
                    process[i].burst,
                    "",
                    process[i].CT,
                    process[i].WT,
                    process[i].TAT
                );
            }

        }
        void calcRR()
        {
            textBox3.Clear();
            float time = 0;
            while (check < process.Count)
            {
                for (int i = 0; i < process.Count ; i++)
                {
                    if (process[i].arrival <= time && process[i].Rem_Time > 0 || process[i].Rem_Time > 0)
                    {
                        if (process[i].Rem_Time > process[i].QT)
                        {
                            process[i].Rem_Time -= process[i].QT;
                            time += process[i].QT;
                        }
                        else
                        {
                            time += process[i].Rem_Time;
                            process[i].Rem_Time = 0;
                            process[i].CT = time;
                            process[i].TAT = process[i].CT - process[i].arrival;
                            process[i].WT = process[i].TAT - process[i].burst;
                           
                            dataGridView1.Rows[i].Cells["wait"].Value = process[i].WT;
                            dataGridView1.Rows[i].Cells["completion"].Value = process[i].CT;
                            dataGridView1.Rows[i].Cells["TAT"].Value = process[i].TAT;
                            check++;
                        }
                        if (check == process.Count)
                        {
                            break;
                        }
                    }
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void panelGanttChart_Paint(object sender, PaintEventArgs e)
        {
            if (flagc == 1)
            {
                if (process.Count == 0) //wont draw if nothing was added to the table
                    return;

                int panelWidth = panelGanttChart.ClientSize.Width; //width & height of the gnnt chart
                int panelHeight = panelGanttChart.ClientSize.Height;

                int xPadding = 10;  //padding so it doesnt take the whole panel 
                int topPadding = 10;

                int labelHeight = 18; // height for time labels

                int barHeight = panelHeight - topPadding - labelHeight - 8; //so it fits the panel and 8 is just extra padding


                Font font = new Font("Arial", 10); // font & pens
                Brush barBrush = Brushes.Blue;
                Brush textBrush = Brushes.White;
                Pen borderPen = Pens.Black;


                float totalBurst = process.Sum(p => p.burst); //used to calc the bar width for all processes 
                if (totalBurst == 0) return; //to avoid dividing by 0

                int availableWidth = panelWidth - 2 * xPadding;
                float pixelsPerBurst = (float)availableWidth / totalBurst;

                int xOffset = xPadding;
                int[] barWidths = new int[process.Count];
                int accumulatedWidth = 0;

                // Calculate all bar widths except the last
                for (int i = 0; i < process.Count - 1; i++)
                {
                    barWidths[i] = (int)Math.Round(process[i].burst * pixelsPerBurst);
                    accumulatedWidth += barWidths[i];
                }
                // Last bar takes the remaining width to fill the panel exactly
                barWidths[process.Count - 1] = availableWidth - accumulatedWidth;

                for (int i = 0; i < process.Count; i++)
                {
                    int width = barWidths[i];

                    // Draw bar
                    e.Graphics.FillRectangle(barBrush, xOffset, topPadding, width, barHeight);
                    e.Graphics.DrawRectangle(borderPen, xOffset, topPadding, width, barHeight);

                    // Draw process ID centered
                    string pid = $"P{process[i].ID}";
                    SizeF textSize = e.Graphics.MeasureString(pid, font);
                    float textX = xOffset + (width - textSize.Width) / 2;
                    float textY = topPadding + (barHeight - textSize.Height) / 2;
                    e.Graphics.DrawString(pid, font, textBrush, textX, textY);

                    // Draw start time below the bar
                    float startTime;
                    if (i == 0)
                    {
                        startTime = process[i].arrival;
                    }
                    else
                    {
                        startTime = Math.Max(process[i].arrival, process[i - 1].CT);
                    }
                    e.Graphics.DrawString(startTime.ToString(), font, Brushes.Black, xOffset, topPadding + barHeight + 2);


                    xOffset += width;
                }

                string lastCT = process[process.Count - 1].CT.ToString();
                SizeF lastCTSize = e.Graphics.MeasureString(lastCT, font);
                e.Graphics.DrawString(lastCT, font, Brushes.Black, xOffset - lastCTSize.Width, topPadding + barHeight + 2);
            }

        }

        void CalcPP()
        {
            int n = process.Count;
            int completed = 0;
            float currentTime = 0;
            float[] rem = process.Select(p => p.burst).ToArray();
            bool[] isDone = new bool[n];

            while (completed != n)
            {
                // Find process with highest priority that has arrived
                int imin = -1;
                float minPriority = 9999;
                for (int i = 0; i < n; i++)
                {
                    if (!isDone[i] && process[i].arrival <= currentTime && rem[i] > 0 &&
                        process[i].priority < minPriority)
                    {
                        minPriority = process[i].priority;
                        imin = i;
                    }
                }

                if (imin != -1)
                {
                    rem[imin]--;
                    currentTime++;

                    if (rem[imin] == 0)
                    {
                        isDone[imin] = true;
                        completed++;
                        process[imin].CT = currentTime;
                        process[imin].TAT = process[imin].CT - process[imin].arrival;
                        process[imin].WT = Math.Max(process[imin].TAT - process[imin].burst, 0);
                        done.Add(imin);
                    }
                }
                else
                {
                    // Jump to next arrival time instead of incrementing one by one
                    float nextArrival = process
                          .Where(p => !isDone[(int)p.ID])
                          .Select(p => p.arrival)
                          .Where(t => t > currentTime)
                          .DefaultIfEmpty(currentTime + 1)
                          .Min();
                    currentTime = nextArrival;
                }
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
