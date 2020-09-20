using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class Form1 : Form
    {
        Player player;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new Player(this, Estado.IdleRight, ClientRectangle.Width / 2, ClientRectangle.Height - 500);
            player.Speed = 10;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.VelocityX = -1;
            }
            else if (e.KeyCode == Keys.Right)
            {
                player.VelocityX = 1;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.VelocityX = 0;
            }
            else if (e.KeyCode == Keys.Right)
            {
                player.VelocityX = 0;
            }
        }
    }
}
