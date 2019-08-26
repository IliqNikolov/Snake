using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    public class Menu
    {
        protected const char MenuSymbol = '\u25ba';
        protected string Title;
        protected int FirstOptionY;
        protected int LastOptionY;
        protected int CurrentY;
        protected List<KeyValuePair<int,string>> Options;

        public Menu(string title)
        {
            this.Title = title;
            Options = new List<KeyValuePair<int, string>>();
            FirstOptionY = CurrentY + 2;
        }

        protected virtual void DrawLogo()
        {
            int x = Console.WindowWidth / 2 -14;
            CurrentY = 7;
            Console.SetCursorPosition(x, CurrentY);
            Console.Write(@" |___/_| |_|\__,_|_|\_\___|");
            Console.SetCursorPosition(x, CurrentY - 1);
            Console.Write(@" \__ \ | | | (_| |   <  __/");
            Console.SetCursorPosition(x, CurrentY - 2);
            Console.Write(@" / __| '_ \ / _` | |/ / _ \");
            Console.SetCursorPosition(x, CurrentY - 3);
            Console.Write(@"  ___ _ __   __ _| | _____ ");
            Console.SetCursorPosition(x, CurrentY - 4);
            Console.Write("                 _         ");
        }

        protected void MoveUp()
        {
            ClearOldMenuSymbol();
            CurrentY -= 2;
            if (CurrentY<FirstOptionY)
            {
                CurrentY = LastOptionY;
            }
        }

        protected void MoveDowm()
        {
            ClearOldMenuSymbol();
            CurrentY += 2;
            if (CurrentY > LastOptionY)
            {
                CurrentY = FirstOptionY;
            }
        }

        protected int Select()
        {
            return (CurrentY - FirstOptionY) / 2;
        }

        public virtual void Display()
        {
            Console.Clear();
            DrawLogo();
            CurrentY = Console.WindowHeight / 2 - (Options.Count + 1);
            FirstOptionY = CurrentY + 2;
            LastOptionY = CurrentY + (Options.Count + 1) * 2-2;
            Console.SetCursorPosition((Console.WindowWidth - Title.Length) / 2, CurrentY);
            Console.Write(Title);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.SetCursorPosition(Options[i].Key, CurrentY + (i + 1) * 2);
                Console.Write(Options[i].Value);
            }
            Console.SetCursorPosition(Console.WindowWidth/2-11, CurrentY +4+ (Options.Count + 1) * 2);
            Console.Write("\"↑\" or \"↓\" to navigate");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, CurrentY + 6 + (Options.Count + 1) * 2);
            Console.Write("\"Enter\" to select");
        }

        protected KeyValuePair<int,string> stringToKeyValue(string str)
        {
            return new KeyValuePair<int, string>((int)Math.Ceiling((double)(Console.WindowWidth - str.Length) / 2), str);
        }

        protected void ClearOldMenuSymbol()
        {
            int temp = Select();
            int x = Options[temp].Key - 4;
            Console.SetCursorPosition(x, CurrentY);
            Console.Write(" ");
        }

    }
}
