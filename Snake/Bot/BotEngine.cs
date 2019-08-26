using Snake.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake.Bot
{
    public class BotEngine
    {
        private int Speed;

        public BotEngine(int speed)
        {
            Speed = speed;
        }

        public void Run(Game game)
        {
            //Console.Clear();
            //game.Render();
            FindApath findApath = new FindApath();
            Queue<ConsoleKey> commands = findApath.FindAPath(game.Snake,game.Foods[0]);
            if (commands.Count == 0)
            {
                for (int i = 0; i < 50; i++)
                {

                    commands.Enqueue(ConsoleKey.UpArrow);
                }
            }
            //game.foods[0].Render();
            foreach (var comand in commands)
            {
                game.MoveSnake(comand);
                Thread.Sleep(Speed);
            }
        }
    }
}
