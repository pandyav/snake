using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeEater
{
    public class Eater
    {
        private int x, y, w, h;
        private SolidBrush brush;
        public Rectangle food;

        public Eater(Random rn)
        {
            x = rn.Next(0, 29) * 20;
            y = rn.Next(0, 26) * 20;

            brush = new SolidBrush(Color.ForestGreen);

            w = 20;
            h = 20;

            food = new Rectangle(x, y, w, h);
        }

        public void foodLocation(Random rn)
        {
            x = rn.Next(0, 29) * 20;
            y = rn.Next(0, 26) * 20;

        }

        public void drawFood(Graphics g)
        {
            food.X = x;
            food.Y = y;

            g.FillRectangle(brush, food);
        }

    }
}
