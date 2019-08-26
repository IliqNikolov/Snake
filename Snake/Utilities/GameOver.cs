using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Utilities
{
    public class GameOver:Exception
    {
        public GameOver(string score):base(score)
        {

        }
    }
}
