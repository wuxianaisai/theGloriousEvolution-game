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
    public partial class GameOver : Form
    {
        private SoundPlayer gameOver;

        public GameOver()
        {
            InitializeComponent();
            gameOver = new SoundPlayer(@"C:\Users\Gamer-PC\Desktop\projects c#\theGloriousEvolution\audio\game_over.wav");
            gameOver.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game obj = new Game();
            obj.Show();
            this.Close();
            gameOver.Stop();
        }
    }
}
