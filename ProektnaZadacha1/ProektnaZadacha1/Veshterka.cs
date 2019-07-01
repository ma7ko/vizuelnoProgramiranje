using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ProektnaZadacha1.Properties;
using System.Windows.Forms;


namespace ProektnaZadacha1
{
    public class Veshterka
    {
        Image v;

        public Point Center { get; set; }

        public double Velocity { get; set; }

        private float velocityX;
        private float velocityY;


        public Veshterka(Point center)
        {
            Center = center;
            Velocity = 20;
            v = Resources.witch;
            velocityX = 0;
            velocityY = (int)Velocity;
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(v, Center.X + v.Width, Center.Y);
        }

        public void Move()
        {
            float nextX = Center.X;
            float nextY = Center.Y;
            if (nextY <= 10)
            {
                velocityY = (int)Velocity;
            }
            else if (nextX > v.Width/16 && velocityY==0)
            {
                velocityY = -(int)Velocity;
                velocityX = 0;
            }
            else if (nextX <= -150)
            {
                velocityX = (int)Velocity;
            }
            else if(nextY > v.Height && velocityX==0)
            {
                velocityX = -(int)Velocity;
                velocityY = 0;
            }

            nextX = Center.X + velocityX;
            nextY = Center.Y + velocityY;

            Center = new Point((int)nextX, (int)nextY);
        }
    }
}
