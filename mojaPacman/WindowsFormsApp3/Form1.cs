using WindowsFormsApp3.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Timer timer;
        ClassPacman pacman;
        static readonly int TIMER_INTERVAL = 250;
        static readonly int WORLD_WIDTH = 15;
        static readonly int WORLD_HEIGHT = 10;
        Image foodImage;
        bool[][] foodWorld;
        Image stapica;
        bool[][] canMove;
        int izedeno = 0;
        public Form1()
        {
            InitializeComponent();
            // Vcituvanje na slika od resursi
            foodImage = Resources.food;
            stapica = Resources.trap;
            DoubleBuffered = true;
            newGame();
        }
        public void newGame()
        {
            pacman = new ClassPacman();
            this.Width = ClassPacman.radius * 2 * (WORLD_WIDTH + 1);
            this.Height = ClassPacman.radius * 2 * (WORLD_HEIGHT + 1);
            // овде кодот за иницијализација на матрицата foodWorld
            foodWorld = new bool[WORLD_HEIGHT][];
            canMove = new bool[WORLD_HEIGHT][];
            for(int i=0;i<WORLD_HEIGHT;i++)
            {
                canMove[i] = new bool[WORLD_WIDTH];
                for(int j=0;j<WORLD_WIDTH;j++)
                {
                    canMove[i][j] = true;
                }
            }
            canMove[1][1] = false; canMove[2][1] = false; canMove[3][1] = false; //barikada 1
            canMove[7][1] = false; canMove[8][1] = false; canMove[9][1] = false; //barikada 2
            canMove[4][3] = false; canMove[5][3] = false; canMove[6][3] = false; //barikada 3
            canMove[3][6] = false; canMove[4][6] = false; canMove[5][6] = false; //barikada 4
            canMove[0][8] = false; canMove[1][8] = false; canMove[2][8] = false; //barikada 5
            canMove[7][10] = false; canMove[8][10] = false; canMove[9][10] = false; //barikada 6
            canMove[2][11] = false; canMove[3][11] = false; canMove[4][11] = false; //barikada 7
            canMove[5][13] = false; canMove[6][13] = false; canMove[7][13] = false; //barikada 8
            for(int i=0;i<WORLD_HEIGHT;i++)
            {
                foodWorld[i] = new bool[WORLD_WIDTH];
                for(int j = 0; j < WORLD_WIDTH; j++)
                {
                    if(canMove[i][j]==true)
                    {
                        foodWorld[i][j] = true;
                    }
                    else
                    {
                        foodWorld[i][j] = false;
                    }
                    
                }
            }

            // овде кодот за иницијализација и стартување на тајмерот
            timer2 = new Timer();
            timer2.Interval = TIMER_INTERVAL;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

        }
        //private void panel1_Paint(object sender, PaintEventArgs e)
       // {
        //}
       

        private void timer2_Tick(object sender, EventArgs e)
        {
            // овде вашиот код
            int calculatedXPos = Math.Abs(pacman.Xpos / 40);
            int calculatedYpos = Math.Abs(pacman.Ypos / 38);

            //so it wont go out of bounds
            if (calculatedXPos == WORLD_WIDTH)
            {
                calculatedXPos--;
            }
            if (calculatedYpos == WORLD_HEIGHT)
            {
                calculatedYpos--;
            }

            //check if there is food on the coords and eat it
            if (foodWorld[calculatedYpos][calculatedXPos])
            {
                foodWorld[calculatedYpos][calculatedXPos] = false;
                izedeno++;
            }
            if (canMove[calculatedYpos][calculatedXPos])
            {
                pacman.Move();
            }
            else
            {
                if (pacman.nasoka == ClassPacman.NASOKA.levo)
                    pacman.nasoka = ClassPacman.NASOKA.desno;
                else if (pacman.nasoka == ClassPacman.NASOKA.desno)
                    pacman.nasoka = ClassPacman.NASOKA.levo;
                else if (pacman.nasoka == ClassPacman.NASOKA.dolu)
                    pacman.nasoka = ClassPacman.NASOKA.gore;
                else if (pacman.nasoka == ClassPacman.NASOKA.gore)
                    pacman.nasoka = ClassPacman.NASOKA.dolu;
                pacman.Move();
            }
            Invalidate(true);
        }


        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            // не заборавајте да го додадете настанот на самата форма
            // вашиот код овде
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (pacman.nasoka != ClassPacman.NASOKA.gore)
                    {
                        pacman.ChangeDirection(ClassPacman.NASOKA.gore);
                    }
                    break;
                case Keys.Down:
                    if (pacman.nasoka != ClassPacman.NASOKA.dolu)
                    {
                        pacman.ChangeDirection(ClassPacman.NASOKA.dolu);
                    }
                    break;
                case Keys.Left:
                    if (pacman.nasoka != ClassPacman.NASOKA.levo)
                    {
                        pacman.ChangeDirection(ClassPacman.NASOKA.levo);
                    }
                    break;
                case Keys.Right:
                    if (pacman.nasoka != ClassPacman.NASOKA.desno)
                    {
                        pacman.ChangeDirection(ClassPacman.NASOKA.desno);
                    }
                    break;
                default:
                    break;
            }

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            for (int i = 0; i < foodWorld.Length; i++)
            {
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    if (foodWorld[i][j])
                    {
                        g.DrawImageUnscaled(foodImage, j * ClassPacman.radius * 2 + (ClassPacman.radius * 2 - foodImage.Height) / 2, i * ClassPacman.radius * 2 + (ClassPacman.radius * 2 - foodImage.Width) / 2);
                    }
                    else if(canMove[i][j]==false)
                    {
                        g.DrawImageUnscaled(stapica, j * ClassPacman.radius * 2 + (ClassPacman.radius * 2 - stapica.Height) / 2, i * ClassPacman.radius * 2 + (ClassPacman.radius * 2 - stapica.Width) / 2);
                    }
                }
            }
            pacman.Draw(g);
        }
    }
}
