using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_3rd_Kursach___Resurrection__WinForms_
{
    public partial class VisInformer : Form
    {
        Point last;
        Form1 mainForm;
        Font font1, font2, font3;
        public VisInformer(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("Font/10887.otf");
            fontCollection.AddFontFile("Font/16768.otf");
            FontFamily family1 = fontCollection.Families[0];
            FontFamily family2 = fontCollection.Families[1];
            font1 = new Font(family2, 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label6.Font = font1;
            font2 = new Font(family2, 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label9.Font = font2;
            font3 = new Font(family2, 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label1.Font = font3;
        }

        private void Panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Red;
        }

        private void Panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Maroon;
        }

        private void Panel4_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form1.VisStep = -1;
                mainForm.Visualisation();
                this.Close();
            }
        }

        private void VisInformer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void Label6_MouseDown(object sender, MouseEventArgs e)
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

        private void VisInformer_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        private void Label6_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        private void Panel3_Click(object sender, EventArgs e)
        {
            Form1.VisStep++;
            mainForm.Visualisation();
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            Form1.VisStep++;
            mainForm.Visualisation();
        }

        private void Panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.LightSkyBlue;
        }

        private void Label9_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.LightSkyBlue;
        }

        private void Panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.SteelBlue;
        }

        private void Label9_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.SteelBlue;
        }

        private void Panel5_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form1.VisStep = -1;
                mainForm.Visualisation();
                this.Close();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form1.VisStep = -1;
                mainForm.Visualisation();
                this.Close();
            }
        }

        private void Panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void Label1_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void Panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(192, 64, 0);
        }

        private void RichTextBox1_Enter(object sender, EventArgs e)
        {
            panel3.Focus();
        }
    }
}
