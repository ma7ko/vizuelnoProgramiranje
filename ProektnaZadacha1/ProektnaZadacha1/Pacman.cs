using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProektnaZadacha1
{
    class Pacman
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public enum DIRECTION
        {
            right,
            left,
            up,
            down
        };
        public DIRECTION Direction;
        public int Radius = 20;
        public static int initialRadius = 20;
        public int Speed { get; set; }
        public bool IsOpen { get; set; }
        public bool blocked { get; set; }
        public SolidBrush brush = new SolidBrush(Color.Yellow);

        public Pacman()
        {
            Speed = Radius;
            Xpos = 7;
            Ypos = 5;
            Direction = DIRECTION.right;
            IsOpen = true;
            blocked = false;
        }

        public void ChangeDirection(DIRECTION direction)
        {
            // vasiot kod ovde
            Direction = direction;
        }

        //Check if the mouth is open and move in the correct way with its speed
        public void Move()
        {
            if (IsOpen)
            {
                IsOpen = false;
            }
            else
            {
                IsOpen = true;
            }
            switch (Direction)
            {
                case DIRECTION.right:
                    if (Xpos >= 595)
                    {
                        Xpos = -25;
                    }
                    else
                    {
                        Xpos += Speed;
                    }

                    break;
                case DIRECTION.left:
                    if (Xpos <= 0)
                    {
                        Xpos = 600;
                    }
                    else
                    {
                        Xpos -= Speed;
                    }
                    break;
                case DIRECTION.up:
                    if (Ypos <= 0)
                    {
                        Ypos = 390;
                    }
                    else
                    {
                        Ypos -= Speed;
                    }
                    break;
                case DIRECTION.down:
                    if (Ypos >= 380)
                    {
                        Ypos = -25;
                    }
                    else
                    {
                        Ypos += Speed;
                    }
                    break;
            }
        }

        public void IncreaseRadius()
        {
            Radius += (Radius * 20) / 100;
        }

        public void DecreaseRadius()
        {
            Radius -= (Radius * 20) / 100;
        }

        //Check pacmans direction and if the mouth should be open or closed and draw him
        public void Draw(Graphics g)
        {
            if (Direction == DIRECTION.right && IsOpen)
            {
                g.FillPie(brush, Xpos, Ypos, Radius + Radius, Radius + Radius, 40, 280);
            }
            else if (Direction == DIRECTION.right && !IsOpen)
            {
                g.FillEllipse(brush, Xpos, Ypos, Radius + Radius, Radius + Radius);
            }
            else if (Direction == DIRECTION.left && IsOpen)
            {
                g.FillPie(brush, Xpos, Ypos, Radius + Radius, Radius + Radius, 220, 280);
            }
            else if (Direction == DIRECTION.left && !IsOpen)
            {
                g.FillEllipse(brush, Xpos, Ypos, Radius + Radius, Radius + Radius);
            }
            else if (Direction == DIRECTION.up && IsOpen)
            {
                g.FillPie(brush, Xpos, Ypos, Radius + Radius, Radius + Radius, 310, 280);
            }
            else if (Direction == DIRECTION.up && !IsOpen)
            {
                g.FillEllipse(brush, Xpos, Ypos, Radius + Radius, Radius + Radius);
            }
            else if (Direction == DIRECTION.down && IsOpen)
            {
                g.FillPie(brush, Xpos, Ypos, Radius + Radius, Radius + Radius, 130, 280);
            }
            else if (Direction == DIRECTION.down && !IsOpen)
            {
                g.FillEllipse(brush, Xpos, Ypos, Radius + Radius, Radius + Radius);
            }
        }
    }
}
