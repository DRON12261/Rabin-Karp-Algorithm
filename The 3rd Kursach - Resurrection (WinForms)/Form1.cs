using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using System.Collections;
using System.Threading;
using System.IO;
using System.Timers;
using System.Drawing.Text;

namespace The_3rd_Kursach___Resurrection__WinForms_
{
    public partial class Form1 : Form
    {
        static public int VisStep;
        static public VisInformer informer;
        static public Experiment experiment;
        static public bool VisualisationStarts = false;
        Point last;
        Font font1, font2, font3, font4, font5, font6, font7, font8;
        static bool myCheckBox1 = true, myCheckBox2 = false, isVisualisation = false;
        static string[] indexes = new string[] { };
        static Stopwatch timer = new Stopwatch();

        string mainText, findText, nomers;
        double mainTextHash, findTextHash;
        int I, J;
        bool Flag;

        public Form1()
        {
            InitializeComponent();
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("Font/10887.otf");
            fontCollection.AddFontFile("Font/16768.otf");
            FontFamily family1 = fontCollection.Families[0];
            FontFamily family2 = fontCollection.Families[1];
            font1 = new Font(family1, 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            //label4.Font = font1;
            font2 = new Font(family2, 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            //label1.Font = label2.Font = label3.Font = label13.Font = font2;
            font3 = new Font(family2, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            //label6.Font = font3;
            font4 = new Font(family2, 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label7.Font = label11.Font = label8.Font = font4;
            font5 = new Font(family2, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label12.Font = font5;
            font6 = new Font(family2, 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label9.Font = label10.Font = font6;
            font7 = new Font(family2, 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label5.Font = font7;
            font8 = new Font(family2, 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //label14.Font = font8;
            //textBox1.Text = new string('A', 20000);
        }

        public static ulong Hash(string x)
        {
            int p = 31;
            ulong rez = 0;
            for (int i = 0; i < x.Length; i++)
            {
                rez = rez + (ulong)Math.Pow(p, x.Length - 1 - i) * (x[i]);
            }
            return rez;
        }
        
        public static string Rabina(string x, string s)
        {
            timer.Reset();
            timer.Start();
            if (myCheckBox2)
            {
                s = s.ToLower();
                x = x.ToLower();
            }
            s += " ";
            string nom = "";
            if (x.Length > s.Length) return nom;
            ulong xhash = Hash(x);
            ulong shash = Hash(s.Substring(0, x.Length));
            bool flag;
            int j;
            for (int i = 0; i < s.Length - x.Length; i++)
            {
                if (xhash == shash)
                {
                    flag = true;
                    j = 0;
                    while ((flag == true) && (j < x.Length))
                    {
                        if (x[j] != s[i + j]) flag = false;
                        j++;
                    }
                    if (flag == true)
                        nom = nom + Convert.ToString(i) + " ";
                }
                shash = (shash - (ulong)Math.Pow(31, x.Length - 1) * (s[i])) * 31 + (s[i + x.Length]);
            }
            if (nom != "") 
            {
                nom = nom.Substring(0, nom.Length - 1); 
            }
            timer.Stop();
            return nom;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            callRabinCarp(ref Flag);
            if (experiment != null) experiment.UpdateAlg();
        }

        #region Необходимый, но рутинный хлам!
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
            if (res == DialogResult.Yes) this.Close();
        }

        private void Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void Panel3_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        private void Label6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void Panel5_Click(object sender, EventArgs e)
        {
            callRabinCarp(ref myCheckBox1, sender);
        }

        private void Panel6_Click(object sender, EventArgs e)
        {
            callRabinCarp(ref myCheckBox1, sender);
        }

        private void Panel9_MouseHover(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Yellow;
        }

        private void Label9_MouseHover(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Yellow;
        }

        private void Label9_MouseLeave(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void Panel9_MouseLeave(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void Label10_MouseHover(object sender, EventArgs e)
        {
            panel10.BackColor = Color.Yellow;
        }

        private void Panel10_MouseHover(object sender, EventArgs e)
        {
            panel10.BackColor = Color.Yellow;
        }

        private void Label10_MouseLeave(object sender, EventArgs e)
        {
            panel10.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void Panel12_Click(object sender, EventArgs e)
        {
            callRabinCarp(ref myCheckBox2, sender);
            if (experiment != null) experiment.UpdateAlg();
        }

        private void Panel11_Click(object sender, EventArgs e)
        {
            callRabinCarp(ref myCheckBox2, sender);
            if (experiment != null) experiment.UpdateAlg();
        }

        private void Panel13_Click(object sender, EventArgs e)
        {
            SaveLog();
        }

        private void Label12_Click(object sender, EventArgs e)
        {
            SaveLog();
        }

        private void Label13_Click(object sender, EventArgs e)
        {
            SaveLog();
        }

        private void Panel13_MouseHover(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Yellow;
        }

        private void Label12_MouseHover(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Yellow;
        }

        private void Label13_MouseHover(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Yellow;
        }

        private void Panel13_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void Label12_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void Label13_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void Panel9_Click(object sender, EventArgs e)
        {
            LoadFromFile(textBox1);
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            LoadFromFile(textBox1);
        }

        private void Panel10_Click(object sender, EventArgs e)
        {
            LoadFromFile(textBox2);
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            LoadFromFile(textBox2);
        }

        private void Panel7_Click(object sender, EventArgs e)
        {
            if (!VisualisationStarts)
            {
                isVisualisation = true;
                Visualisation();
            }
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            if (!VisualisationStarts)
            {
                isVisualisation = true;
                Visualisation();
            }
        }

        private void Panel7_MouseHover(object sender, EventArgs e)
        {
            panel7.BackColor = Color.LightSkyBlue;
        }

        private void Label8_MouseHover(object sender, EventArgs e)
        {
            panel7.BackColor = Color.LightSkyBlue;
        }

        private void Panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.SteelBlue;
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            expShow();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            expShow();
        }

        private void Label14_Click(object sender, EventArgs e)
        {
            expShow();
        }

        public void expShow()
        {
            if (experiment == null)
            {
                experiment = new Experiment(this);
                experiment.Show();
            }
        }

        private void Panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.PowderBlue;
            label14.BackColor = Color.PowderBlue;
            label5.BackColor = Color.PowderBlue;
        }

        private void Panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DarkTurquoise;
            label14.BackColor = Color.DarkTurquoise;
            label5.BackColor = Color.DarkTurquoise;
        }

        private void Label5_MouseHover(object sender, EventArgs e)
        {
            label14.BackColor = Color.PowderBlue;
            label5.BackColor = Color.PowderBlue;
            panel1.BackColor = Color.PowderBlue;
        }

        private void Label5_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DarkTurquoise;
            label14.BackColor = Color.DarkTurquoise;
            label5.BackColor = Color.DarkTurquoise;
        }

        private void Label14_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.PowderBlue;
            label14.BackColor = Color.PowderBlue;
            label5.BackColor = Color.PowderBlue;
        }

        private void Label14_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DarkTurquoise;
            label14.BackColor = Color.DarkTurquoise;
            label5.BackColor = Color.DarkTurquoise;
        }

        private void Label8_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.SteelBlue;
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            callRabinCarp(ref Flag);
            if (experiment != null && !isVisualisation) experiment.UpdateAlg();
        }

        private void Panel10_MouseLeave(object sender, EventArgs e)
        {
            panel10.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void Label6_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove(e);
        }
        #endregion

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

        private void LoadFromFile(RichTextBox textBox)
        {
            if (!VisualisationStarts)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader reader = new StreamReader(ofd.OpenFile()))
                        {
                            textBox.Text = reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void SaveLog()
        {
            if (!VisualisationStarts)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "txt files (*.txt)|*.txt";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FileStream file = new FileStream(sfd.FileName, FileMode.Create);
                        StreamWriter writer = new StreamWriter(file);
                        writer.WriteLine("ИСХОДНЫЙ ТЕКСТ");
                        writer.WriteLine(new string('-', 120));
                        writer.WriteLine(textBox1.Text);
                        writer.WriteLine(new string('-', 120));
                        writer.WriteLine();
                        writer.WriteLine("ИСКОМЫЙ ТЕКСТ");
                        writer.WriteLine(new string('-', 120));
                        writer.WriteLine(textBox2.Text);
                        writer.WriteLine(new string('-', 120));
                        writer.WriteLine();
                        writer.WriteLine("РЕЗУЛЬТАТ");
                        writer.WriteLine(new string('-', 120));
                        writer.WriteLine(textBox3.Text);
                        writer.WriteLine(new string('-', 120));
                        writer.WriteLine("\n\n");
                        writer.WriteLine(new string('-', 120));
                        writer.WriteLine(DateTime.Now + $" \"Реализация Алгоритма Рабина-Карпа. Скочко А.Е. 184-2 Курсовая\"");
                        writer.WriteLine(new string('-', 120));
                        writer.Close();
                        file.Close();
                    }
                }
            }
        }

        private void callRabinCarp(ref bool checkBox, object sender = null)
        {
            if (!VisualisationStarts)
            {
                int oldSel1 = textBox1.SelectionStart, oldSel2 = textBox2.SelectionStart;
                if (sender == panel6 || sender == panel5)
                {
                    panel6.BackColor = panel6.BackColor == Color.Black ? Color.White : Color.Black;
                }
                else if (sender == panel12 || sender == panel11)
                {
                    panel12.BackColor = panel12.BackColor == Color.Black ? Color.White : Color.Black;
                }
                checkBox = !checkBox;
                string search = Rabina(textBox2.Text, textBox1.Text);
                if (textBox2.Text == "")
                {
                    textBox1.SelectionStart = 0;
                    textBox1.SelectionLength = textBox1.Text.Length;
                    textBox1.SelectionColor = Color.Lime;
                    textBox1.SelectionBackColor = textBox1.BackColor;
                    textBox3.Text = "Ожидание ввода...";
                }
                else
                {
                    if (search == "")
                    {
                        textBox1.SelectionStart = 0;
                        textBox1.SelectionLength = textBox1.Text.Length;
                        textBox1.SelectionColor = Color.Lime;
                        textBox1.SelectionBackColor = textBox1.BackColor;
                        textBox3.Text = $"Ничего не найдено!\nВремя выполнения: {timer.Elapsed.TotalMilliseconds}мс";
                    }
                    else
                    {  
                        indexes = search.Split(' ');
                        textBox3.Text = $"Обнаружено сходство! Совпадений - {indexes.Length}.\nВремя выполнения: {timer.Elapsed.TotalMilliseconds}мс.";
                        if (myCheckBox1)
                        {
                            textBox1.SelectionStart = 0;
                            textBox1.SelectionLength = textBox1.Text.Length;
                            textBox1.SelectionColor = Color.Lime;
                            textBox1.SelectionBackColor = textBox1.BackColor;
                            foreach (string index in indexes)
                            {
                                textBox1.SelectionStart = int.Parse(index);
                                textBox1.SelectionLength = textBox2.Text.Length;
                                textBox1.SelectionColor = Color.Aqua;
                                textBox1.SelectionBackColor = textBox1.BackColor;
                            }
                        }
                        else
                        {
                            textBox1.SelectionStart = 0;
                            textBox1.SelectionLength = textBox1.Text.Length;
                            textBox1.SelectionColor = Color.Lime;
                            textBox1.SelectionBackColor = textBox1.BackColor;
                        }
                        indexes = new string[] { };
                    }
                }
                textBox1.Select(oldSel1, 0);
                textBox2.Select(oldSel2, 0);
            }
        }

        public void Visualisation()
        {
            if ((textBox1.Text == "" || textBox2.Text == "") && !VisualisationStarts)
            {
                MessageBox.Show("Введите исходный и искомый текст!", "ВНИМАНИЕ!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isVisualisation = false;
            }
            else
            {
                DialogResult res = DialogResult.OK;
                if (!VisualisationStarts) res = MessageBox.Show("Запустить визуализацию алгоритма с введенными данными?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (VisualisationStarts || res == DialogResult.Yes)
                {
                    if (!VisualisationStarts)
                    {
                        VisualisationStarts = true;
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        textBox1.SelectionStart = 0;
                        textBox1.SelectionLength = textBox1.Text.Length;
                        textBox1.SelectionColor = Color.Lime;
                        textBox1.SelectionBackColor = textBox1.BackColor;
                        informer = new VisInformer(this);
                        informer.Show();
                        VisStep = 1;
                        mainText = textBox1.Text;
                        findText = textBox2.Text;
                        if (myCheckBox2)
                        {
                            mainText = mainText.ToLower();
                            findText = findText.ToLower();
                        }
                        I = 0; J = 0;
                    }
                    switch (VisStep)
                    {
                        case 1:
                            if (myCheckBox2)
                            {
                                mainText = mainText.ToLower();
                                findText = findText.ToLower();
                            }
                            mainText += " ";
                            informer.richTextBox1.Text = "Первым делом идет проверка на учет регистра, " +
                                "если чувствительность к регистру не важна, то исходный и искомый тексты " +
                                "приводятся к нижнему регистру...";
                            break;
                        case 2:
                            nomers = "";
                            if (mainText.Length < findText.Length) VisStep = -2;
                            informer.richTextBox1.Text = "Потом мы создаем новую строковую переменную, " +
                                "где будем хранить номера первых символов найденных подстрок в " +
                                "тексте. Назовем ее nomers и присвоим ей значение пустой строки. " +
                                "Если длина искомой строки больше, чем длина основного текста, то " +
                                "прекращаем работу алгоритма, так как исходный текст не может содеражть " +
                                "в себе подстроку большей длины, чем имеет сам.";
                            informer.richTextBox1.SelectionStart = 126;
                            informer.richTextBox1.SelectionLength = 6;
                            informer.richTextBox1.SelectionColor = Color.Pink;
                            informer.richTextBox1.Select(0, 0);
                            informer.panel3.Focus();
                            break;
                        case 3:
                            findTextHash = Hash(findText);
                            informer.richTextBox1.Text = $"Вычисляем хэш-функцию для искомой строки. В данном случае " +
                                $"хэш будет равняться {findTextHash}. Запоминаем его в переменной findTextHash.";
                            informer.richTextBox1.SelectionStart = 78;
                            informer.richTextBox1.SelectionLength = findTextHash.ToString().Length;
                            informer.richTextBox1.SelectionColor = Color.LightGreen;
                            informer.richTextBox1.SelectionStart = 108 + findTextHash.ToString().Length;
                            informer.richTextBox1.SelectionLength = 12;
                            informer.richTextBox1.SelectionColor = Color.LightGreen;
                            informer.richTextBox1.Select(0, 0);
                            informer.panel3.Focus();
                            break;
                        case 4:
                            mainTextHash = Hash(mainText.Substring(0, findText.Length));
                            informer.richTextBox1.Text = $"Вычисляем хэш функцию куска исходного текста " +
                                $"длины искомой строки на 0 символе. " +
                                $"В данном случае хэш будет равен {mainTextHash}. Запоминаем его в " +
                                $"переменной mainTextHash.";
                            informer.richTextBox1.SelectionStart = 112;
                            informer.richTextBox1.SelectionLength = mainTextHash.ToString().Length;
                            informer.richTextBox1.SelectionColor = Color.LightBlue;
                            informer.richTextBox1.SelectionStart = 142 + mainTextHash.ToString().Length;
                            informer.richTextBox1.SelectionLength = 12;
                            informer.richTextBox1.SelectionColor = Color.LightBlue;
                            informer.richTextBox1.Select(0, 0);
                            informer.panel3.Focus();
                            break;
                        case 5:
                            informer.richTextBox1.Text = "Запускаем цикл, в ходе которого постоянно проверяем равенство " +
                                "mainTextHash и findTextHash. Если они не равны, то повторяем прошлый шаг с вычислением " +
                                "хэш-функции, только на этот раз сдвигая \"кусок\" исходного текста на символ вперед. " +
                                "При этом не обязательно высчитывать весь хэш нового куска, достаточно из старого хэша отнять " +
                                "хэш первого символа старого куска текста и прибавить хэш последнего символа нового куска текста. " +
                                "Таким образом можно сэкономить время.";
                            informer.richTextBox1.SelectionStart = 62;
                            informer.richTextBox1.SelectionLength = 12;
                            informer.richTextBox1.SelectionColor = Color.LightBlue;
                            informer.richTextBox1.SelectionStart = 77;
                            informer.richTextBox1.SelectionLength = 12;
                            informer.richTextBox1.SelectionColor = Color.LightGreen;
                            informer.richTextBox1.Select(0, 0);
                            informer.panel3.Focus();
                            break;
                        case 6:
                            if (I < mainText.Length - findText.Length)
                            {
                                string[] ind = nomers.Split(' ');
                                textBox1.SelectionStart = 0;
                                textBox1.SelectionLength = textBox1.Text.Length;
                                textBox1.SelectionColor = Color.Lime;
                                textBox1.SelectionBackColor = textBox1.BackColor;
                                foreach (string index in ind)
                                {
                                    try
                                    {
                                        textBox1.SelectionStart = int.Parse(index);
                                        textBox1.SelectionLength = textBox2.Text.Length;
                                        textBox1.SelectionColor = Color.Aqua;
                                        textBox1.SelectionBackColor = textBox1.BackColor;
                                    }
                                    catch { }
                                }
                                textBox1.SelectionStart = I;
                                textBox1.SelectionLength = textBox2.Text.Length;
                                textBox1.SelectionColor = Color.Yellow;
                                textBox1.SelectionBackColor = Color.DarkOrange;
                                if (findTextHash == mainTextHash)
                                {
                                    Flag = true;
                                    J = 0;
                                    while ((Flag == true) && (J < findText.Length))
                                    {
                                        if (findText[J] != mainText[I + J]) Flag = false;
                                        J++;
                                    }
                                    if (Flag == true)
                                        nomers = nomers + Convert.ToString(I) + " ";
                                }
                                mainTextHash = (mainTextHash - (ulong)Math.Pow(31, findText.Length - 1) * (ulong)(mainText[I])) * 31 + (ulong)(mainText[I + findText.Length]);
                                I++;
                                VisStep--;
                            }
                            informer.richTextBox1.Text = "Цикл идет до тех пор, пока такие \"куски\" не кончатся " +
                                "в исходном тексте. Цикл запущен! Продвигайте процесс с помощью кнопки " +
                                "\"ДАЛЕЕ\" и наблюдайте за изменениями в основном окне программы!\n\n" +
                                $"findTextHash = {findTextHash}\n" +
                                $"mainTextHash = {mainTextHash}\n" +
                                $"nomers = \"{(nomers.Length > 0 ? nomers.Substring(0, nomers.Length - 1) : nomers)}\"";
                            informer.richTextBox1.SelectionStart = 187;
                            informer.richTextBox1.SelectionLength = 15 + findTextHash.ToString().Length;
                            informer.richTextBox1.SelectionColor = Color.LightGreen;
                            informer.richTextBox1.SelectionStart = 187 + 16 + findTextHash.ToString().Length;
                            informer.richTextBox1.SelectionLength = 15 + mainTextHash.ToString().Length;
                            informer.richTextBox1.SelectionColor = Color.LightBlue;
                            informer.richTextBox1.SelectionStart = 187 + 17 + findTextHash.ToString().Length + 15 + mainTextHash.ToString().Length;
                            informer.richTextBox1.SelectionLength = 11 + (nomers.Length > 0 ? nomers.Substring(0, nomers.Length - 1).Length : nomers.Length);
                            informer.richTextBox1.SelectionColor = Color.Pink;
                            informer.richTextBox1.Select(0, 0);
                            informer.panel3.Focus();
                            break;
                        case 7:
                            {
                                string[] ind = nomers.Split(' ');
                                textBox1.SelectionStart = 0;
                                textBox1.SelectionLength = textBox1.Text.Length;
                                textBox1.SelectionColor = Color.Lime;
                                textBox1.SelectionBackColor = textBox1.BackColor;
                                foreach (string index in ind)
                                {
                                    try
                                    {
                                        textBox1.SelectionStart = int.Parse(index);
                                        textBox1.SelectionLength = textBox2.Text.Length;
                                        textBox1.SelectionColor = Color.Aqua;
                                        textBox1.SelectionBackColor = textBox1.BackColor;
                                    }
                                    catch { }
                                }
                            }
                                VisStep = -2;
                            informer.richTextBox1.Text = "По окончанию работы цикла мы имеем строковую переменную nomers, " +
                                "в которой через пробел записаны номера первых символов найденных подстрок в тексте. " +
                                "Если ничего не было найдено, то строка будет пустая. Например в нашем случае nomers равна " +
                                $"\"{(nomers.Length > 0 ? nomers.Substring(0, nomers.Length - 1) : nomers)}\". " +
                                $"Так же в данной реализации была дополнительная проверка при совпадении хэшей на совпадение " +
                                $"искомой строки и проверяемого \"куска\" исходного текста, но такая проверка затрачивает дополнительное время. " +
                                $"На этом работа алгоритма считается завершенной.";
                            informer.richTextBox1.SelectionStart = 56;
                            informer.richTextBox1.SelectionLength = 6;
                            informer.richTextBox1.SelectionColor = Color.Pink;
                            informer.richTextBox1.SelectionStart = 225;
                            informer.richTextBox1.SelectionLength = 6;
                            informer.richTextBox1.SelectionColor = Color.Pink;
                            informer.richTextBox1.SelectionStart = 238;
                            informer.richTextBox1.SelectionLength = 2 + (nomers.Length > 0 ? nomers.Substring(0, nomers.Length - 1).Length : nomers.Length);
                            informer.richTextBox1.SelectionColor = Color.Pink;
                            informer.richTextBox1.Select(0, 0);
                            informer.panel3.Focus();
                            break;
                        case -1:
                            isVisualisation = false;
                            VisualisationStarts = false;
                            if (informer != null) { informer.Close(); informer = null; }
                            VisStep = 0;
                            textBox1.ReadOnly = false;
                            textBox2.ReadOnly = false;
                            callRabinCarp(ref Flag);
                            MessageBox.Show("Визуализация алгоритма завершена!", "ВНИМАНИЕ!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                else
                {
                    isVisualisation = false;
                }
            }
        }

        public static string SearchString(string pat, string str)
        {
            if (myCheckBox2)
            {
                pat = pat.ToLower();
                str = str.ToLower();
            }
            str = str + " ";
            string nom = "";
            int m = pat.Length;
            int n = str.Length;
            int[] badChar = new int[65536];
            BadCharHeuristic(pat, m, ref badChar);
            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;
                while (j >= 0 && pat[j] == str[s + j])
                    --j;
                if (j < 0)
                {
                    nom += s.ToString() + " ";
                    s += (s + m < n) ? m - badChar[str[s + m]] : 1;
                }
                else
                {
                    s += Math.Max(1, j - badChar[str[s + j]]);
                }
            }
            if (nom != "")
            {
                nom = nom.Substring(0, nom.Length - 1);
            }
            return nom;
        }
        private static void BadCharHeuristic(string str, int size, ref int[] badChar)
        {
            int i;
            for (i = 0; i < 256; i++)
                badChar[i] = -1;
            for (i = 0; i < size; i++)
                badChar[(int)str[i]] = i;
        }

        public static string BruteForce(string x, string s)
        {
            if (myCheckBox2)
            {
                s = s.ToLower();
                x = x.ToLower();
            }
            s = s + " ";
            string nom = "";

            for (int i = 0; i < s .Length - x.Length; i++)
            {
                if (s.Substring(i, x.Length) == x)
                {
                    nom += i + " ";
                }
            }

            if (nom != "") nom = nom.Substring(0, nom.Length - 1);
            return nom;
        }
    }
}
