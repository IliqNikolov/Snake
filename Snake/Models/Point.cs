using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    public class Point:GameObject
    {
        public int X { get;  set; }
        public int Y { get;  set; }

        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
