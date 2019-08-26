using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    class EndGame : SimpleMenu
    {
        private string Score;
        public EndGame(List<string> options,string score) : base(options)
        {
            Score = score;
        }

        protected override void DrawLogo()
        {
            ScorePrinter.PrintScore(Score, 4);
        }
    }
}
