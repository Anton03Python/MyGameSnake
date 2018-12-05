using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameSnake
{
    public class Food: BaseFigure
    {
        private int H;
        private int W;

        public Food(int x, int y)
        {
            W = x;
            H = y;
            points = new List<Point>();
        }

        public void AddFood(int x = 0, int y = 0)
        {
            Random rand = new Random(unchecked((int)DateTime.Now.Millisecond));
            if (x == 0 && y == 0)
                do
                {
                    x = rand.Next(W);
                    y = rand.Next(H);
                } while (x == 0 || y == 0);
            points.Add(new Point(x, y, Figures.Food));

        }

        public void Clear()
        {
            points.Clear();
        }
        public Point GetPoint()
        {
            if (points.Count == 1)
                return points[0];
            else
                return null;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
