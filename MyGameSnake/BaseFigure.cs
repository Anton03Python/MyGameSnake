using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameSnake
{
    public abstract class BaseFigure
    {
        public List<Point> points;
        public abstract void Draw();
        protected int[,] ToArray(int x, int y)
        {
            int[,] res = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var point = points.Find(p => p.X == i && p.Y == j);
                    if (point != null)
                        res[i, j] = (int)point.Figure;
                }
            }
            return res;
        }
    }
}
