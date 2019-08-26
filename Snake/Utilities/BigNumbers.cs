using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Utilities
{
    public static class BigNumbers
    {
        public static void Zero(int x,int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("╔═══╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("╚═══╝");
        }

        public static void One(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("  ╗  ");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("  ║  ");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("  ║  ");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("  ║  ");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine(" ═╩═ ");
        }

        public static void Two(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("════╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("╔═══╝");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("║    ");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("╚════");
        }

        public static void Three(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("════╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("════╣");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("════╝");
        }

        public static void Four(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("╔   ╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("╚═══╣");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("    ║");
        }

        public static void Five(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("╔════");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("║    ");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("╚═══╗");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("════╝");
        }

        public static void Six(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("╔═══╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("║    ");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("╠═══╗");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("╚═══╝");
        }

        public static void Seven(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("════╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("    ║");
        }

        public static void Eight(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("╔═══╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("╠═══╣");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("╚═══╝");
        }

        public static void Nine(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("╔═══╗");
            Console.SetCursorPosition(y, x+1);
            Console.WriteLine("║   ║");
            Console.SetCursorPosition(y, x+2);
            Console.WriteLine("╚═══╣");
            Console.SetCursorPosition(y, x+3);
            Console.WriteLine("    ║");
            Console.SetCursorPosition(y, x+4);
            Console.WriteLine("╚═══╝");
        }
    }
}
