using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Utilities
{
    public static class ColorSwitch
    {
        public static ConsoleColor consoleColor(int num)
        {
            ConsoleColor color=ConsoleColor.Cyan;
            switch (num)
            {
                case 0:
                    color = ConsoleColor.Black;
                    break;
                case 1:
                    color = ConsoleColor.Blue;
                    break;
                case 2:
                    color = ConsoleColor.Cyan;
                    break;
                case 3:
                    color = ConsoleColor.Gray;
                    break;
                case 4:
                    color = ConsoleColor.Green;
                    break;
                case 5:
                    color = ConsoleColor.Magenta;
                    break;
                case 6:
                    color = ConsoleColor.Red;
                    break;
                case 7:
                    color = ConsoleColor.White;
                    break;
                case 8:
                    color = ConsoleColor.Yellow;
                    break;
                case 9:
                    color = ConsoleColor.DarkRed;
                    break;
                default:
                    break;
            }
            return color;
        }
    }
}
