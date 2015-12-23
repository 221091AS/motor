using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool zapadka = false;

        int licznik = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox2.Checked = true;
            }

            
            if ((checkBox1.Checked == true) )
            { MessageBox.Show("Tryb pracy", "Sterowanie silnika"); }
            else
            {
               
                MessageBox.Show("Tryb gotowosci", "Sterowanie silnika");
                checkBox1.Checked = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 13)
            {
                numericUpDown1.Value = 1;
                licznik_met("minus");
            }
            if (numericUpDown1.Value == 0)
            {
                numericUpDown1.Value = 12;
                licznik_met("minus");
            }
            show_frame((int)numericUpDown1.Value-1);
            if (zapadka)
                licznik_met("plus");
            

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (checkBox2.Checked == true)
                {
                    numericUpDown1.Visible = true;
                    numericUpDown1.Value = czas + 1;
                    timer1.Stop();
                    timer2.Stop();
                    zapadka = true;
                }
                else
                {
                    czas = Convert.ToInt32(numericUpDown1.Value) - 1;
                    numericUpDown1.Visible = false;
                    zapadka = false;
                }
            }
        }
        int czas = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();

            timer1.Enabled = true;
            timer1.Start();

            MessageBox.Show("Obrot o 30 stopni", "Kat obrotu");


        }

        void show_frame(int n)
        {
            Bitmap[] bmps =
            {
                   global::WindowsFormsApplication3.Properties.Resources._1,
                   global::WindowsFormsApplication3.Properties.Resources._2,
                   global::WindowsFormsApplication3.Properties.Resources._3,
                   global::WindowsFormsApplication3.Properties.Resources._4,
                   global::WindowsFormsApplication3.Properties.Resources._5,
                   global::WindowsFormsApplication3.Properties.Resources._6,
                   global::WindowsFormsApplication3.Properties.Resources._7,
                   global::WindowsFormsApplication3.Properties.Resources._8,
                   global::WindowsFormsApplication3.Properties.Resources._9,
                   global::WindowsFormsApplication3.Properties.Resources._10,
                   global::WindowsFormsApplication3.Properties.Resources._11,
                   global::WindowsFormsApplication3.Properties.Resources._12
            };
            pictureBox.Image = bmps[n];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (checkBox3.Checked == false)
                {
                    czas++;
                    licznik_met("plus");
                    if (czas == 12)
                    { czas = 0; }
                    show_frame(czas);
                }
                else
                {
                    czas--;
                    licznik_met("plus");
                    if (czas == -1)
                    {
                        czas = 11;
                    }
                    show_frame(czas);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (checkBox3.Checked == false)
                {
                    czas = czas + 3;
                    licznik_met("plus");
                    if (czas >= 12)
                    { czas = 0; }
                    show_frame(czas);
                }
                else
                {
                    czas = czas - 3;
                    licznik_met("plus");
                    if (czas <= -1)
                    {
                        czas = 11;
                    }
                    show_frame(czas);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

         
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Enabled = true;
            timer2.Start();

            MessageBox.Show("Obrot o 90 stopni", "Kat obrotu");
            //czas++;
            //textBox1.Text = czas.ToString();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show_frame(0);
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            
            licznik = -1;
            
            if(timer1.Enabled)
            {
                timer1.Stop();
                timer1.Start();
            }
            if (timer2.Enabled)
            {
                timer2.Stop();
                timer2.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.A;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.B;
        }
        
        private void licznik_met(string znak)
        {
            switch (znak)
            {
                case "plus":
                    licznik++;
                    if (licznik == 12)
                    {
                        licznik = 0;
                    }
                    textBox1.Text = licznik.ToString();
                    break;

                case "minus":
                    licznik--;
                    if (licznik == -1)
                    {
                        licznik = 11;
                    }
                    textBox1.Text = licznik.ToString();
                    break;
            }
        }
    }
}