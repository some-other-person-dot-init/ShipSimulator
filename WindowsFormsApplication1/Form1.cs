using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer upps = new System.Media.SoundPlayer(Properties.Resources.upps);
        System.Media.SoundPlayer comon = new System.Media.SoundPlayer(Properties.Resources.compron);
        System.Media.SoundPlayer onon = new System.Media.SoundPlayer(Properties.Resources.turnon);
        System.Media.SoundPlayer offoff = new System.Media.SoundPlayer(Properties.Resources.turnoff);
        //System.Media.SoundPlayer noo = new System.Media.SoundPlayer(Properties.Resources.no);
        System.Media.SoundPlayer emgstop = new System.Media.SoundPlayer(Properties.Resources.stop);
        System.Media.SoundPlayer btn = new System.Media.SoundPlayer(Properties.Resources.btn);
        System.Media.SoundPlayer Compress = new System.Media.SoundPlayer(Properties.Resources.compressor);
        System.Media.SoundPlayer Compressend = new System.Media.SoundPlayer(Properties.Resources.compressend);
        bool engine = false;
        bool com = false;
        int t1 = 0;
        int job = 0;
        int nooo = 0;
        int planet;
        int load;
        Random rand = new Random();
        Random rand2 = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Привет, добро пожаловать в почти реалистичный симулятор управления космический кораблем. \n Твоя задача доставлять груз или пассажиров в нужные пункты. Удачи!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (com == false)
            {
                
                if (engine == false)
                {
                    onon.Play();
                    pictureBox1.BackgroundImage = Properties.Resources.start_2;
                    label2.Text = "Вкл";
                    timer1.Enabled = true;
                    engine = true;
                    timer3.Enabled = true;
                }
                else
                {
                    offoff.Play();
                    pictureBox1.BackgroundImage = Properties.Resources.start_1;
                    engine = false;
                    label2.Text = "Выкл";
                    label4.Text = "Выкл";
                    t1 = 0;
                    progressBar1.Value = 0;
                    timer1.Enabled = false;
                    if (timer2.Enabled == true)
                    {
                        timer2.Enabled = false;
                        com = false;
                        emgstop.Play();
                    }
                    timer1.Interval = 1000;
                    timer3.Enabled = false;
                    timer3.Interval = 2000;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t1 == 0)
            {
                comon.Play();
                progressBar1.Value = 80;
                t1++;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            if (t1 != 0)
            {
                timer1.Interval = 7000;
                progressBar1.Value--;
               
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (com == false)
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                pictureBox1.Enabled = false;
                Compress.Load();
                Compress.Play();
                com = true;
            }
            else
            {
                label4.Text = "Вкл";
                progressBar1.Value = progressBar1.Value + 5;
                
            }
            if (progressBar1.Value >= 80)
            {
                Compressend.Load();
                Compressend.Play();
                label4.Text = "Выкл";
                timer1.Enabled = true;
                com = false;
                timer2.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                pictureBox1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (engine == true)
            {
                //nooo++;
                btn.Play();
                ship.Top = ship.Top - 10;
                progressBar1.Value--;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (engine == true)
            {
                /*if (nooo == 1)
                {
                    nooo++;
                }*/
                btn.Play(); btn.Play();
                ship.Left = ship.Left - 10;
                progressBar1.Value--;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (engine == true)
            {
                /*if (nooo == 2)
                {
                    nooo++;
                }*/
                btn.Play();
                ship.Top = ship.Top + 10;
                progressBar1.Value--;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (engine == true)
            {
                btn.Play();
                /*if (nooo == 3)
                {
                    noo.Play();
                    nooo = 0;
                }*/
                ship.Left = ship.Left + 10;
                progressBar1.Value--;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (engine == true)
            {
                emgstop.Play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((ship.Left <= earth.Left + earth.Width) && (ship.Top <= earth.Top + earth.Height) && (job == 0))
            {
                load = rand.Next(0, 4);
                if (load == 1)
                {
                    MessageBox.Show("Твой груз: Пассажиры");
                    label6.Text = "Пассажиры";
                    planet = rand2.Next(0, 2);
                    if (planet == 0)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 1)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                if (load == 0)
                {
                    MessageBox.Show("Твой груз: Строительные материалы");
                    label6.Text = "Стро. матер.";
                    planet = rand2.Next(0, 2);
                    if (planet == 0)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 1)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                if (load == 2)
                {
                    MessageBox.Show("Твой груз: Товары и продукты");
                    label6.Text = "Товары";
                    planet = rand2.Next(0, 2);
                    if (planet == 0)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 1)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                if (load == 3)
                {
                    MessageBox.Show("Твой груз: Боеприпасы");
                    label6.Text = "Боеприпасы";
                    planet = rand2.Next(0, 2);
                    if (planet == 0)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 1)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                upps.Play();
            }
            if ((ship.Left <= earth.Left + earth.Width) && (ship.Top <= earth.Top + earth.Height) && (job == 1) && ((planet == 3) || (planet == 4)))
            {
                MessageBox.Show("Груз доставлен!");
                job = 0;
                upps.Play();
                label8.Text = "";
                label6.Text = "Нет груза"; 
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((ship.Left <= Lune.Left + Lune.Width) && (ship.Top <= Lune.Top + Lune.Height) && (ship.Left >= Lune.Left) && (job == 0))
            {
                load = rand.Next(0, 4);
                if (load == 1)
                {
                    MessageBox.Show("Твой груз: Пассажиры");
                    label6.Text = "Пассажиры";
                    planet = rand2.Next(4, 6);
                    if (planet == 4)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    if (planet == 5)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                if (load == 0)
                {
                    MessageBox.Show("Твой груз: Строительные материалы");
                    label6.Text = "Стро. матер.";
                    planet = rand2.Next(4, 6);
                    if (planet == 4)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    if (planet == 5)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                if (load == 2)
                {
                    MessageBox.Show("Твой груз: Товары и продукты");
                    label6.Text = "Товары";
                    planet = rand2.Next(4, 6);
                    if (planet == 4)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    if (planet == 5)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                if (load == 3)
                {
                    MessageBox.Show("Твой груз: Боеприпасы");
                    label6.Text = "Боеприпасы";
                    planet = rand2.Next(4, 6);
                    if (planet == 4)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    if (planet == 5)
                    {
                        MessageBox.Show("Доставить на Марс");
                        label8.Text = "Марс";
                    }
                    job = 1;
                }
                upps.Play();
            }
             if ((ship.Left <= Lune.Left + Lune.Width) && (ship.Top <= Lune.Top + Lune.Height) && (ship.Left >= Lune.Left) && (job == 1) && ((planet == 0) || (planet == 2)))
             {
                 MessageBox.Show("Груз доставлен!");
                 job = 0;
                 upps.Play();
                 label8.Text = "";
                 label6.Text = "Нет груза";
             }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if ((ship.Left >= Mars.Left) && (ship.Top >= Mars.Top) && (job == 0))
            {
                load = rand.Next(0, 4);
                if (load == 1)
                {
                    MessageBox.Show("Твой груз: Пассажиры");
                    label6.Text = "Пассажиры";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                if (load == 0)
                {
                    MessageBox.Show("Твой груз: Строительные материалы");
                    label6.Text = "Стро. матер.";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                if (load == 2)
                {
                    MessageBox.Show("Твой груз: Товары и продукты");
                    label6.Text = "Товары";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                if (load == 3)
                {
                    MessageBox.Show("Твой груз: Боеприпасы");
                    label6.Text = "Боеприпасы";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                upps.Play();
            }
            if ((ship.Left >= Mars.Left) && (ship.Top >= Mars.Top) && (job == 1) && ((planet == 1) || (planet == 5)))
            {
                MessageBox.Show("Груз доставлен!");
                job = 0;
                upps.Play();
                label8.Text = "";
                label6.Text = "Нет груза";
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 10;
            if (progressBar1.Value <= 50)
            {
                timer2.Enabled = true;
                timer1.Enabled = false;
            }
        }

        private void qualityplanet_CheckedChanged(object sender, EventArgs e)
        {
            if (qualityplanet.Checked == false)
            {
                label10.Text = "Ниже некуда";
                //earth.Visible = true;
                //Mars.Visible = true;
                //Lune.Visible = true;
                earth.BackColor = Color.LightGreen;
                earth.BackgroundImage = null;
                Mars.BackgroundImage = Properties.Resources.Mars;
                Mars.Text = null;
                Lune.BackColor = Color.LightGray;
                Lune.BackgroundImage = null;
                panel1.BackgroundImage = null;
            }
            else
            {
                label10.Text = "ULTRA 4K";
                earth.BackColor = Color.Transparent;
                earth.BackgroundImage = Properties.Resources.Earth;
                Mars.BackgroundImage = Properties.Resources.notmars;
                Mars.Text = "Mars";
                Lune.BackColor = Color.Transparent;
                Lune.BackgroundImage = Properties.Resources.M_O_O_N;
                panel1.BackgroundImage = Properties.Resources.space;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if ((ship.Left >= Mars.Left) && (ship.Top >= Mars.Top) && (job == 0))
            {
                load = rand.Next(0, 4);
                if (load == 1)
                {
                    MessageBox.Show("Твой груз: Пассажиры");
                    label6.Text = "Пассажиры";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                if (load == 0)
                {
                    MessageBox.Show("Твой груз: Строительные материалы");
                    label6.Text = "Стро. матер.";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                if (load == 2)
                {
                    MessageBox.Show("Твой груз: Товары и продукты");
                    label6.Text = "Товары";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                if (load == 3)
                {
                    MessageBox.Show("Твой груз: Боеприпасы");
                    label6.Text = "Боеприпасы";
                    planet = rand2.Next(2, 4);
                    if (planet == 2)
                    {
                        MessageBox.Show("Доставить на Луну");
                        label8.Text = "Луна";
                    }
                    if (planet == 3)
                    {
                        MessageBox.Show("Доставить на Землю");
                        label8.Text = "Земля";
                    }
                    job = 1;
                }
                upps.Play();
            }
            if ((ship.Left >= Mars.Left) && (ship.Top >= Mars.Top) && (job == 1) && ((planet == 1) || (planet == 5)))
            {
                MessageBox.Show("Груз доставлен!");
                job = 0;
                upps.Play();
                label8.Text = "";
                label6.Text = "Нет груза";
            }
        }
    }
}