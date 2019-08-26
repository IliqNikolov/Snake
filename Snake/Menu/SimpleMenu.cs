using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Models
{
    public class SimpleMenu:Menu
    {
        public SimpleMenu(List<string> options) : base(options[0])
        {
            foreach (var option in options.Skip(1))
            {
                Options.Add(stringToKeyValue(option));
            }
        }

        public int StartSelecting()
        {
            Display();
            CurrentY = FirstOptionY;
            while (true)
            {
                Console.SetCursorPosition(Options[Select()].Key - 4, CurrentY);
                Console.Write(MenuSymbol);
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    MoveUp();
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    MoveDowm();
                }
                else if (key == ConsoleKey.Enter)
                {
                    return Select();
                }
            }
        }       
    }
}
