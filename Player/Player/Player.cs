using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public enum Estado
    {
        IdleLeft, IdleRight, RunLeft, RunRight, JumpLeft, JumpRight, SlideLeft, SlideRight, DeadLeft, DeadRight
    };

    class Player : PictureBox
    {
        int count = 0;
        public int VelocityX = 0, VelocityY = 0, Speed = 500;

        Timer tSprites, tSpeed;

        public Dictionary<Estado, Image[]> Sprites;
        private Estado estadoIdle;

        public Player(Form context, Estado idleInicial, int x, int y)
        {
            Sprites = new Dictionary<Estado, Image[]>()
            {
                { Estado.IdleLeft, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleLeft__009.png")
                    }
                },
                { Estado.IdleRight, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\IdleRight__009.png")
                    }
                },
                { Estado.RunLeft, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunLeft__009.png")
                    }
                },
                { Estado.RunRight, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\RunRight__009.png")
                    }
                },
                { Estado.JumpLeft, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpLeft__009.png")
                    }
                },
                { Estado.JumpRight, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\JumpRight__009.png")
                    }
                },
                { Estado.SlideLeft, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideLeft__009.png")
                    }
                },
                { Estado.SlideRight, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\SlideRight__009.png")
                    }
                },
                { Estado.DeadLeft, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadLeft__009.png")
                    }
                },
                { Estado.DeadRight, new Image[]
                    {
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__000.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__001.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__002.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__003.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__004.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__005.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__006.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__007.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__008.png"),
                        Image.FromFile(Application.StartupPath + @"\sprites\DeadRight__009.png")
                    }
                }
            };
            estadoIdle = idleInicial;

            Location = new Point(x, y);

            tSprites = new Timer();
            tSprites.Tick += T_TickSprites;
            tSprites.Interval = 130;
            tSprites.Start();

            tSpeed = new Timer();
            tSpeed.Tick += T_TickSpeed;
            tSpeed.Interval = 10;
            tSpeed.Start();

            //BorderStyle = BorderStyle.FixedSingle;
            context.Controls.Add(this);
        }

        private void T_TickSprites(object sender, EventArgs e)
        {
            switch (VelocityX)
            {
                default:
                case 0:
                    if (Sprites[estadoIdle] != null)
                    {
                        tSprites.Interval = 130;
                        Size = new Size(Sprites[estadoIdle][0].Width, Sprites[estadoIdle][0].Height);
                        if (count > Sprites[estadoIdle].Count() - 1) count = 0;
                        BackgroundImage = Sprites[estadoIdle][count++];
                    }
                    break;
                case 1:
                    if (Sprites[Estado.RunRight] != null)
                    {
                        tSprites.Interval = 75;
                        Size = new Size(Sprites[Estado.RunRight][0].Width, Sprites[Estado.RunRight][0].Height);
                        if (count > Sprites[Estado.RunRight].Count() - 1) count = 0;
                        BackgroundImage = Sprites[Estado.RunRight][count++];
                        estadoIdle = Estado.IdleRight;
                    }
                    break;
                case -1:
                    if (Sprites[Estado.RunLeft] != null)
                    {
                        tSprites.Interval = 75;
                        Size = new Size(Sprites[Estado.RunLeft][0].Width, Sprites[Estado.RunLeft][0].Height);
                        if (count > Sprites[Estado.RunLeft].Count() - 1) count = 0;
                        BackgroundImage = Sprites[Estado.RunLeft][count++];
                        estadoIdle = Estado.IdleLeft;
                    }
                    break;
            }
        }

        private void T_TickSpeed(object sender, EventArgs e)
        {
            switch (VelocityX)
            {
                default:
                case 0:
                    break;
                case 1:
                    if (Sprites[Estado.RunRight] != null)
                    {  ³                      
                        Location = new Point(Location.X + Speed, Location.Y);
                    }
                    break;
                case -1:
                    if (Sprites[Estado.RunLeft] != null)
                    {
                        Location = new Point(Location.X -³ Speed, Location.Y);
                    }
                    break;
            }
        }
    }
}
