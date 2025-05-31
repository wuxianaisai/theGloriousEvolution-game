using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theGloriousEvolution
{
    public partial class Game : Form
    {
        private int countHex = 0;
        private bool isWarwickAvailable = false;
        private bool isJinxAvailable = false;
        private bool isJayceAvailable = false;

        private SoundPlayer hexSnd;
        private SoundPlayer vik2;
        private SoundPlayer vik3;
        private SoundPlayer vik4;

        public Game()
        {
            InitializeComponent();
            warwick.Top = -1000;
            vik2 = new SoundPlayer(@"C:\Users\Gamer-PC\Desktop\projects c#\theGloriousEvolution\audio\vik2.wav");
            vik3 = new SoundPlayer(@"C:\Users\Gamer-PC\Desktop\projects c#\theGloriousEvolution\audio\vik3.wav");
            vik4 = new SoundPlayer(@"C:\Users\Gamer-PC\Desktop\projects c#\theGloriousEvolution\audio\vik4.wav");
            hexSnd = new SoundPlayer(@"C:\Users\Gamer-PC\Desktop\projects c#\theGloriousEvolution\audio\hex_sound.wav");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = (countHex >= 10) ? 5 : 3; 
            BG1.Top += speed;
            BG2.Top += speed;

            int enemySpeed = (countHex >= 10) ? 8 : 5;
            heim.Top += enemySpeed;
            mel.Top += enemySpeed;

            int warwickSpeed = (countHex >= 10) ? 15 : 10;
            int jinxSpeed = 12;
            int jayceSpeed = 2;


            hexcore.Top += speed;

            if (BG1.Top >= 620 ) 
            {
                BG1.Top = 0;
                BG2.Top = -600;
            }

            if (heim.Top >= 620)
            {
                heim.Top = -120;
                Random rand = new Random();
                heim.Left = rand.Next(155, 300);
            }

            if (mel.Top >= 620)
            {
                mel.Top = -450;
                Random rand = new Random();
                mel.Left = rand.Next(300, 825);
            }
            if (isWarwickAvailable)
            {
                warwick.Top += warwickSpeed;
                if (warwick.Top >= 620)
                {
                    warwick.Top = -950;
                    Random rand = new Random();
                    warwick.Left = rand.Next(255, 525);
                }
            }

            if (isJinxAvailable)
            {
                jinx.Top += jinxSpeed;
                if (jinx.Top >= 620)
                {
                    jinx.Top = -250;
                    Random rand = new Random();
                    jinx.Left = rand.Next(155, 825);
                }
            }

            if (isJayceAvailable)
            {
                jayce.Top += jayceSpeed;
                if (jayce.Top >= 620)
                {
                    jayce.Top = -950;
                    Random rand = new Random();
                    jayce.Left = rand.Next(255, 525);
                }
            }

            if (hexcore.Top >= 620)
            {
                hexcore.Top = -50;
                Random rand = new Random();
                hexcore.Left = rand.Next(155, 825);
            }

            if (vik1.Bounds.IntersectsWith(mel.Bounds) 
                || vik1.Bounds.IntersectsWith(heim.Bounds) 
                || vik1.Bounds.IntersectsWith(jayce.Bounds)
                || vik1.Bounds.IntersectsWith(warwick.Bounds)
                || vik1.Bounds.IntersectsWith(jinx.Bounds)) 
            {
                timer.Enabled = false;
                GameOver obj = new GameOver();
                obj.Show();
                this.Close();
            }

            if (vik1.Bounds.IntersectsWith(hexcore.Bounds)) 
            {
                countHex++;
                cntLbl.Text = countHex.ToString();
                hexcore.Top = -50;
                Random rand = new Random();
                hexcore.Left = rand.Next(155, 825);

                hexSnd.Play();

                if (countHex == 5)
                {
                    isWarwickAvailable = true;
                    vik1.Image = Image.FromFile("C:\\Users\\Gamer-PC\\Desktop\\projects c#\\theGloriousEvolution\\img\\vik2.png");
                    
                    vik2.Play();
                }
                else if (countHex == 10)
                {
                    vik1.Image = Image.FromFile("C:\\Users\\Gamer-PC\\Desktop\\projects c#\\theGloriousEvolution\\img\\vik3.png");

                    vik3.Play();
                }
                else if (countHex == 15)
                {
                    isJayceAvailable = true;
                    isJinxAvailable = true;
                    vik1.Image = Image.FromFile("C:\\Users\\Gamer-PC\\Desktop\\projects c#\\theGloriousEvolution\\img\\vik4.png");

                    vik4.Play();
                }
                else if (countHex == 20) 
                { 
                    Victory obj = new Victory();
                    obj.Show();
                    this.Close();
                }
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 2;

            if (countHex >= 5 && countHex < 10)
            {
                speed = 6;
            }
            else if (countHex >= 10 && countHex < 15)
            {
                speed = 10;
            }

            else if (countHex >= 15) 
            {
                speed = 16;
            }

            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && vik1.Left > 155) 
            {
                vik1.Left -= speed;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && vik1.Right < 825)
            {
                vik1.Left += speed;
            }
        }
    }
}
