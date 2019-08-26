using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Utilities
{
    public static class ScorePrinter
    {
        public static void PrintScore(string score,int x)
        {
            int y = (Console.WindowWidth-score.Length*5)/2 - (score.Length - 1);
            for (int i = 0; i < score.Length; i++)
            {
                switch (score[i])
                {
                    case '0':
                        BigNumbers.Zero(x,y);
                        break;
                    case '1':
                        BigNumbers.One(x, y);
                        break;
                    case '2':
                        BigNumbers.Two(x, y);
                        break;
                    case '3':
                        BigNumbers.Three(x, y);
                        break;
                    case '4':
                        BigNumbers.Four(x, y);
                        break;
                    case '5':
                        BigNumbers.Five(x, y);
                        break;
                    case '6':
                        BigNumbers.Six(x, y);
                        break;
                    case '7':
                        BigNumbers.Seven(x, y);
                        break;
                    case '8':
                        BigNumbers.Eight(x, y);
                        break;
                    case '9':
                        BigNumbers.Nine(x, y);
                        break;
                }
                y += 7;
            }
        }
    }
}
