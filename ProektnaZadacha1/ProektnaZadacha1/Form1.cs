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
        public static readonly int widthw = 17;
        public static readonly int heightw = 10;
        Timer timer;
        Image goodFood;
        Image badFood;
        bool[][] goodFoodMap;
        bool[][] badFoodMap;
        public Form1()
        {
            InitializeComponent();
            pacman = new Pacman();
            goodFood = Resources.apple1;
            badFood = Resources.candy;
            DoubleBuffered = true;
            initializeMatrix();
        }

        private void initializeMatrix()
        {
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
            for(int i = 0; i < heightw; i++)
            {
                Random random = new Random();
                int brojr = random.Next(i, heightw);
                for (int j = 0; j < widthw; j++)
                {
                    int brojk = random.Next(j, widthw);
                    if (randombroj % 3 == 0)
                    {
                        if (goodFoodMap[brojr][brojk] == false && badFoodMap[brojr][brojk] == false)
                        {
                            goodFoodMap[brojr][brojk] = true;
                        }
                        randombroj++;
                    }
                    else
                    {
                        if (badFoodMap[brojr][brojk] == false && goodFoodMap[brojr][brojk] == false)
                        {
                            badFoodMap[brojr][brojk] = true;
                        }
                        randombroj++;
                    }
                }
            }
            timer = new Timer();
            timer.Interval = 250;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            for (int i = 0; i < goodFoodMap.Length; i++)
            {
                for (int j = 0; j < goodFoodMap.Length; j++)
                {
                    if (goodFoodMap[i][j])
                    {
                        g.DrawImageUnscaled(goodFood, j * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - goodFood.Height) / 2, i * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - goodFood.Width) / 2);
                    }
                    else if (badFoodMap[i][j])
                    {
                        g.DrawImageUnscaled(badFood, j * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - badFood.Height) / 2, i * Pacman.initialRadius * 2 + (Pacman.initialRadius * 2 - badFood.Width) / 2);
                    }
                }
            }
            pacman.Draw(g);
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
                pacman.DecreaseRadius();
            }
            if (badFoodMap[calculatedYpos][calculatedXPos])
            {
                badFoodMap[calculatedYpos][calculatedXPos] = false;
                pacman.IncreaseRadius();
            }
            pacman.Move();
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
    }
}
