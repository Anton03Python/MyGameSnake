﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameSnake
{
    public class Point
    {
        public Point(int x, int y, Figures figure)
        {
            X = x;
            Y = y;
            Figure = figure;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Figures Figure { get; set; }
    }
}
