using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    public class Wall:GameObject
    {
        private char WallSymbol ='\u25A0' ;
        public int TopX { get; }
        public int TopY { get; }
        public int BottomX { get; }
        public int BottomY { get; }

        public Wall()
        {
            TopX = 0;
            TopY = 0;
            BottomX = Console.WindowWidth-2;
            BottomY = Console.WindowHeight-1;
            LeftAndRightLines();
            TopAndBottomLimes();
        }

        public override void Render()
        {
            TopAndBottomLimes();
            LeftAndRightLines();
        }

        private void LeftAndRightLines()
        {
            for (int i = 0; i < BottomY; i++)
            {
                Visualise(TopX, i, WallSymbol);
                Visualise(BottomX, i, WallSymbol);
            }
        }

        private void TopAndBottomLimes()
        {
            for (int i = 0; i < BottomX; i++)
            {
                Visualise(i, TopY, WallSymbol);
                Visualise(i, BottomY, WallSymbol);
            }
        }
    }
}
