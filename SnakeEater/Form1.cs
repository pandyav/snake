using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeEater
{
    public partial class Form1 : Form
    {
        Graphics g;
        Snake snake = new Snake();
        Random rn = new Random();
        Eater food;

        private bool left = false;
        private bool right = false;
        private bool down = false;
        private bool up = false;

        private bool paused = false;
        private bool stopped = true;

        private int score = 0;

        public Form1()
        {
            InitializeComponent();
            food = new Eater(rn);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            food.drawFood(g);
            snake.drawSnake(g);
            drawGrid(e.Graphics);

            //for (int i = 0; i < snake.snake2.Length; i++)
            //{
            //    if (snake.snake2[i].IntersectsWith(food.food))
            //    {
            //        food.foodLocation(rn);
            //    }
            //}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space && !stopped)
            {
                if (!paused)
                {
                    timer1.Enabled = false;
                    paused = true;
                    SpaceBarLabel.Text = "PAUSED";
                }
                else
                {
                    timer1.Enabled = true;
                    paused = false;
                    SpaceBarLabel.Text = "";
                }
            }
            else if (e.KeyData == Keys.Space && !timer1.Enabled && stopped)
            {
                timer1.Enabled = true;
                stopped = false;
                SpaceBarLabel.Text = "";
                PauseLabel.Text = "";
                down = false;
                up = false;
                right = true;
                left = false;
            }
            else if (e.KeyData == Keys.Down && !up)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }

            else if (e.KeyData == Keys.Up && !down)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }

            else if (e.KeyData == Keys.Right && !left)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }

            else if (e.KeyData == Keys.Left && !right)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SnakeScoreLabel.Text = Convert.ToString(score);
            if (down) { snake.moveDown(); }
            if (up) { snake.moveUp(); }
            if (right) { snake.moveRight(); }
            if (left) { snake.moveLeft(); }

            for (int i = 0; i < snake.snake2.Length; i++)
            {
                if (snake.snake2[i].IntersectsWith(food.food))
                {
                    score += 10;
                    snake.growSnake();
                    food.foodLocation(rn);
                }
            }
            collision();

            this.Invalidate();
        }

        public void collision()
        {
            for (int i = 1; i < snake.snake2.Length; i++)
            {
                if (snake.snake2[0].IntersectsWith(snake.snake2[i]))
                {
                    restart();
                }
            }

            if (snake.snake2[0].X < 0 || snake.snake2[0].X > 580)
            {
                restart();
            }

            if (snake.snake2[0].Y < 0 || snake.snake2[0].Y > 540)
            {
                restart();
            }
        }

        public void drawGrid(Graphics g)
        {            
            Pen pen = new Pen(Color.FromArgb(20,Color.LightGray), 1);
            
            Point p1;
            Point p2;
            Point p3;
            Point p4;

             for (int x = 0; x <= 600; x+=20)
             {
                 p1 = new Point(0, x);
                 p2 = new Point(600, x);
                 p3 = new Point(x, 0);
                 p4 = new Point(x, 600);
                 g.DrawLine(pen, p1, p2);
                 g.DrawLine(pen, p3, p4);
             }
             
        }
        public void restart()
        {
            timer1.Enabled = false;
            stopped = true;
            MessageBox.Show("Snake Died, Your score: "+ score);
            SnakeScoreLabel.Text = "0";
            score = 0;
            SpaceBarLabel.Text = "Press Space to Replay";
            snake = new Snake();
            food = new Eater(rn);

            
        }

    }
}
