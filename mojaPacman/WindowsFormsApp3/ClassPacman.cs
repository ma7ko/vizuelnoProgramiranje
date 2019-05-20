using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    public class ClassPacman
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public enum NASOKA
        {
            desno,
            levo,
            gore,
            dolu
        }
        public NASOKA nasoka;
        public static int radius = 20;
        public int brzina { get; set; }
        public bool otvorenaUsta { get; set; }
        SolidBrush br = new SolidBrush(Color.Yellow);
        public ClassPacman()
        {
            Xpos = 7;
            Ypos = 5;
            nasoka = NASOKA.desno;
            brzina = radius;
            otvorenaUsta = true;
        }
        public void ChangeDirection(NASOKA direction)
        {
            // vasiot kod ovde
            nasoka = direction;
        }
        public void Move()
        {
            // vasiot kod ovde
            if(otvorenaUsta==true)
            {
                otvorenaUsta = false;
            }
            else
            {
                otvorenaUsta = true;
            }
            switch(nasoka)
            {
                case NASOKA.desno:
                    if (Xpos >= 595)
                    {
                        Xpos = -25;
                    }
                    else
                    {
                        Xpos += brzina;
                    }

                    break;
                case NASOKA.levo:
                    if (Xpos <= 0)
                    {
                        Xpos = 600;
                    }
                    else
                    {
                        Xpos -= brzina;
                    }
                    break;
                case NASOKA.gore:
                    if (Ypos <= 0)
                    {
                        Ypos = 390;
                    }
                    else
                    {
                        Ypos -= brzina;
                    }
                    break;
                case NASOKA.dolu:
                    if (Ypos >= 380)
                    {
                        Ypos = -25;
                    }
                    else
                    {
                        Ypos += brzina;
                    }
                    break;
            }
        }
        public void Draw(Graphics g)
        {
            // vasiot kod ovde
            if (nasoka == NASOKA.desno && otvorenaUsta == true)
            {
                g.FillPie(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2,40,300);
            }
            else if (nasoka == NASOKA.desno && otvorenaUsta == false)
            {
                g.FillEllipse(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2);
            }
            else if (nasoka == NASOKA.levo && otvorenaUsta == true)
            {
                g.FillPie(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2, 220, 320);
            }
            else if (nasoka == NASOKA.levo && otvorenaUsta == false)
            {
                g.FillEllipse(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2);
            }
            else if (nasoka == NASOKA.gore && otvorenaUsta == true)
            {
                g.FillPie(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2, 300, 250);
            }
            else if (nasoka == NASOKA.gore && otvorenaUsta == false)
            {
                g.FillEllipse(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2);
            }
            else if (nasoka == NASOKA.dolu && otvorenaUsta == true)
            {
                g.FillPie(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2, 100, 350);
            }
            else if (nasoka == NASOKA.dolu && otvorenaUsta == false)
            {
                g.FillEllipse(br, Xpos, Ypos, ClassPacman.radius * 2, ClassPacman.radius * 2);
            }
        }
    }
}
