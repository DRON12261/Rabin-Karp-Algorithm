using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_3rd_Kursach___Resurrection__WinForms_
{
    public partial class Experiment : Form
    {
        Point last;
        Form1 mainForm;
        Font font1, font2;

        private void Panel2_Click(object sender, EventArgs e)
        {
            Form1.experiment = null;
            this.Close();
        }

        private void Panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Red;
        }

        private void Panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Maroon;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void Experiment_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void FormMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point cur = MousePosition;
                int dx = cur.X - last.X;
                int dy = cur.Y - last.Y;
                Point loc = new Point(Location.X + dx, Location.Y + dy);
                Location = loc;
                last = cur;
            }
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        private void Experiment_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        public Experiment(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            UpdateAlg();
        }

        public void UpdateAlg()
        {
            if (mainForm.textBox2.Text == "" || mainForm.textBox3.Text == "")
            {
                sovp1.Text = sovp2.Text = sovp3.Text = time1.Text = time2.Text = time3.Text = "-";
            }
            else
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                string search1 = Form1.Rabina(mainForm.textBox2.Text, mainForm.textBox1.Text);
                timer.Stop();
                double timer1 = timer.Elapsed.TotalMilliseconds;
                timer.Reset();
                timer.Start();
                string search2 = Form1.SearchString(mainForm.textBox2.Text, mainForm.textBox1.Text);
                timer.Stop();
                double timer2 = timer.Elapsed.TotalMilliseconds;
                timer.Reset();
                timer.Start();
                string search3 = Form1.BruteForce(mainForm.textBox2.Text, mainForm.textBox1.Text);
                timer.Stop();
                double timer3 = timer.Elapsed.TotalMilliseconds;
                if (search1 == "") sovp1.Text = "0";
                else
                    sovp1.Text = search1.Split(' ').Length.ToString();
                time1.Text = timer1.ToString() + " мс";
                if (search2 == "") sovp2.Text = "0";
                else
                    sovp2.Text = search2.Split(' ').Length.ToString();
                time2.Text = timer2.ToString() + " мс";
                if (search3 == "") sovp3.Text = "0";
                else
                    sovp3.Text = search3.Split(' ').Length.ToString();
                time3.Text = timer3.ToString() + " мс";
                if (search1 == "") mainForm.textBox3.Text = $"Ничего не найдено!\nВремя выполнения: {timer1}мс";
                else mainForm.textBox3.Text = $"Обнаружено сходство! Совпадений - {search1.Split(' ').Length}.\nВремя выполнения: {timer1}мс.";
            }
        }
    }
}
