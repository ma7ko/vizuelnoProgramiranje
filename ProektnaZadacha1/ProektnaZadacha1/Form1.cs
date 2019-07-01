using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProektnaZadacha1.Properties;

namespace ProektnaZadacha1
{
    public partial class Form1 : Form
    {
        Pacman pacman;
        public static readonly int widthw = 15;
        public static readonly int heightw = 10;
        Timer timer;
        Image goodFood;
        Image badFood;
        Image house;
        bool[][] goodFoodMap;
        bool[][] badFoodMap;
        int goodfoodsno = 5;
        bool postignataCel;
        bool imaVeshterka;
        Veshterka w;
        public Form1()
        {
            InitializeComponent();
            goodFood = Resources.apple1;
            badFood = Resources.candy;
            house = Resources.house1;
            DoubleBuffered = true;
            postignataCel = false;
            imaVeshterka = false;
            initializeMatrix();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            for (int i = 0; i < heightw; i++)
            {
                for (int j = 0; j < widthw; j++)
                {
                    if (goodFoodMap[i][j])
                    {
                        g.DrawImageUnscaled(goodFood, j * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - goodFood.Height) / 2, i * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - goodFood.Width) / 2);
                    }
                    if (badFoodMap[i][j])
                    {
                        g.DrawImageUnscaled(badFood, j * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - badFood.Height) / 2, i * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - badFood.Width) / 2);
                    }
                }
            }
            g.DrawImageUnscaled(house, Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - house.Height) / 2, Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - house.Width) / 2);
            pacman.Draw(g);
            if (imaVeshterka)
            {
                w.Draw(g);
            }
        }

        private void initializeMatrix()
        {

            pacman = new Pacman();
            w = new Veshterka(new Point(7, 5));
            this.Width = Pacman.initialRadius * 2 * (widthw + 1);
            this.Height = Pacman.initialRadius * 2 * (heightw + 1) + 50;

            goodFoodMap = new bool[heightw][];
            badFoodMap = new bool[heightw][];
            for(int i = 0; i < heightw; i++)
            {
                goodFoodMap[i] = new bool[widthw];
                badFoodMap[i] = new bool[widthw];
                for(int j = 0; j < widthw; j++)
                {
                    goodFoodMap[i][j] = false;
                    badFoodMap[i][j] = false;
                }
            }

            int randombroj = 0;
            int vlegov = 0;
            Random random = new Random();
            for (int i = 0; i < heightw; i++)
            {
                int brojr = random.Next(i, heightw);
                for (int j = 0; j < widthw; j++)
                {
                    int brojk = random.Next(j, widthw);
                    if (brojr == 1)
                        brojr++;
                    if (brojk == 1)
                        brojk++;
                    if (randombroj < 5)
                    {
                        if (goodFoodMap[brojr][brojk] == false && badFoodMap[brojr][brojk] == false)
                        {
                            goodFoodMap[brojr][brojk] = true;
                            vlegov++;
                            randombroj++;
                        }
                    }
                    else
                    {
                        if (badFoodMap[brojr][brojk] == false && goodFoodMap[brojr][brojk] == false)
                        {
                            badFoodMap[brojr][brojk] = true;
                            vlegov++;
                        }
                    }
                    if (vlegov == 10)
                        break;
                }
                if (vlegov == 10)
                    break;
            }
            toolStripStatusLabel1.Text = "Преостанати јаболка: " + goodfoodsno.ToString();
            toolStripStatusLabel2.Text = "Тековна големина на Pacman: " + pacman.Radius; 
            timer = new Timer();
            timer.Interval = 250;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int calculatedXPos = Math.Abs(pacman.Xpos / 40);
            int calculatedYpos = Math.Abs(pacman.Ypos / 38);

            //so it wont go out of bounds
            if (calculatedXPos == widthw)
            {
                calculatedXPos--;
            }
            if (calculatedYpos == heightw)
            {
                calculatedYpos--;
            }

            //check if there is food on the coords and eat it
            if (goodFoodMap[calculatedYpos][calculatedXPos])
            {
                goodFoodMap[calculatedYpos][calculatedXPos] = false;
                goodfoodsno--;
                toolStripStatusLabel1.Text = "Преостанати јаболка: " + goodfoodsno.ToString();
                pacman.DecreaseRadius();
                toolStripStatusLabel2.Text = "Тековна големина на Pacman: " + pacman.Radius;
            }
            if (badFoodMap[calculatedYpos][calculatedXPos])
            {
                badFoodMap[calculatedYpos][calculatedXPos] = false;
                pacman.IncreaseRadius();
                toolStripStatusLabel2.Text = "Тековна големина на Pacman: " + pacman.Radius;
                imaVeshterka = true;
            }
            if (goodfoodsno==0)
            {
                postignataCel = true;
            }
            if(calculatedXPos==1 && calculatedYpos==1 && postignataCel)
            {
                kraj();
            }
            if (imaVeshterka)
            {
                w.Move();
                pacman.Move();
            }
            else
            {
                pacman.Move();

            }
            Invalidate(true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (pacman.Direction != Pacman.DIRECTION.up)
                    {
                        pacman.ChangeDirection(Pacman.DIRECTION.up);
                    }
                    break;
                case Keys.Down:
                    if (pacman.Direction != Pacman.DIRECTION.down)
                    {
                        pacman.ChangeDirection(Pacman.DIRECTION.down);
                    }
                    break;
                case Keys.Left:
                    if (pacman.Direction != Pacman.DIRECTION.left)
                    {
                        pacman.ChangeDirection(Pacman.DIRECTION.left);
                    }
                    break;
                case Keys.Right:
                    if (pacman.Direction != Pacman.DIRECTION.right)
                    {
                        pacman.ChangeDirection(Pacman.DIRECTION.right);
                    }
                    break;
                default:
                    break;
            }

            Invalidate();
        }

        public void kraj()
        {
            timer.Stop();
            MessageBox.Show("Pobedivte");
        }

       
    }
}
