using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeEater
{
    public class Snake
    {
        private Rectangle[] snake;
        private SolidBrush brush;
        private int x, y, w, h;

        public Rectangle[] snake2
        {
            get { return snake; }
        }

        public Snake()
        {
            snake = new Rectangle[4];
            brush = new SolidBrush(Color.DarkOliveGreen);

            x = 60;
            y = 0;
            w = 20;
            h = 20;

            for (int i = 0; i < snake.Length; i++)
            {
                snake[i] = new Rectangle(x, y, w, h);
                x -= 20;
            }
        }

        public void drawSnake(Graphics g)
        {
            foreach (Rectangle rec in snake)
            {
                g.FillRectangle(brush, rec);
            }
        }

        public void drawSnake()
        {
            for (int i = snake.Length - 1; i > 0; i--)
            {
                snake[i] = snake[i - 1];
            }
        }

        public void moveDown()
        {
            drawSnake();
            snake[0].Y += 20;       
        }

        public void moveUp()
        {
            drawSnake();
            snake[0].Y -= 20;
        }

        public void moveRight()
        {
            drawSnake();
            snake[0].X += 20;
        }

        public void moveLeft()
        {
            drawSnake();
            snake[0].X -= 20;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snake.ToList();
            rec.Add(new Rectangle(snake[snake.Length-1].X, snake[snake.Length-1].Y,w,h));
            snake=rec.ToArray();
        }

    }
}
