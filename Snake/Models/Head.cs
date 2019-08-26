using SimpleSnake.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    public class Head:Point
    {
        private char HeadSymbolUp = '\u25b2';
        private char HeadSymbolDown = '\u25bc';
        private char HeadSymbolRight = '\u25ba';
        private char HeadSymbolLeft = '\u25c4';
        private char HeadSymbol;

        public Head(int x, int y,Direction d) : base(x, y)
        {
            switch (d)
            {
                case Direction.Right:
                    HeadSymbol = HeadSymbolRight;
                    break;
                case Direction.Left:
                    HeadSymbol = HeadSymbolLeft;
                    break;
                case Direction.Down:
                    HeadSymbol = HeadSymbolDown;
                    break;
                case Direction.Up:
                    HeadSymbol = HeadSymbolUp;
                    break;
                default:
                    HeadSymbol = '?';
                    break;
            }
            Visualise(X, Y, HeadSymbol);
        }

        public override void Render()
        {
            Visualise(X, Y, HeadSymbol);
        }

        public void DeVisualise()
        {
            Visualise(X, Y, ' ');
        }
    }
}
