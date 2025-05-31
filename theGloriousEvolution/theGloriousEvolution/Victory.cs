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
    public partial class Victory : Form
    {
        private SoundPlayer victory;

        public Victory()
        {
            InitializeComponent();
            victory = new SoundPlayer(@"C:\Users\Gamer-PC\Desktop\projects c#\theGloriousEvolution\audio\victory.wav");
            victory.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game obj = new Game();
            obj.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
