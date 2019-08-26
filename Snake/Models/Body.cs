using SimpleSnake.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Models
{
    public class Body:Point
    {
        private char BodySymbol ;

        public Body(int x, int y,Direction d1,Direction d2) : base(x, y)
        {
            BodySymbol = BodySymbul(d1,d2);
            Visualise(X, Y, BodySymbol);
        }

        public override void Render()
        {
            Visualise(X, Y, BodySymbol);
        }

        public Body(int x, int y, char ch) : base(x, y)
        {
            Visualise(X, Y, ch);
        }

        public void DeVisualise()
        {
            Visualise(X, Y, ' ');
        }

        private char BodySymbul(Direction d1, Direction d2)
        {
            List<Direction> directions = new List<Direction>();
            directions.Add(d1);
            directions.Add(d2);
            directions = directions.OrderBy(x => x).ToList();
            char output='?';
            if (directions[0]==Direction.Right)
            {
                if (directions[1]==Direction.Left)
                {
                    output = '\u2550';
                }
                else if (directions[1] == Direction.Down)
                {
                    output = '\u2554';
                }
                else
                {
                    output = '\u255a';
                }
            }
            else if (directions[0] == Direction.Left)
            {
                if (directions[1] == Direction.Down)
                {
                    output = '\u2557';
                }
                else
                {
                    output = '\u255d';
                }
            }
            else
            {
                output = '\u2551';
            }
            return output;
        }
    }
}
