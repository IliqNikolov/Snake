using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake.Utilities
{
    public class Reader
    {
        private static Thread InputThread;
        private static AutoResetEvent GetInput, GotInput;
        private static ConsoleKeyInfo Input;

        static Reader()
        {
            GetInput = new AutoResetEvent(false);
            GotInput = new AutoResetEvent(false);
            InputThread = new Thread(reader);
            InputThread.IsBackground = true;
            InputThread.Start();
        }

        private static void reader()
        {
            while (true)
            {
                GetInput.WaitOne();
                Input = Console.ReadKey();
                GotInput.Set();
            }
        }

        public static ConsoleKeyInfo ReadLine(int timeOutMillisecs = Timeout.Infinite)
        {
            GetInput.Set();
            bool success = GotInput.WaitOne(timeOutMillisecs);
                return Input;           
        }
    }
}
