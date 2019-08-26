using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    public class GameObject
    {
        public static void Visualise(int x,int y,char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        public virtual void Render()
        {

        }
    }
}
