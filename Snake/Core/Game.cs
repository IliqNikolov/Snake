using SimpleSnake.Enums;
using SimpleSnake.Utilities;
using Snake.Bot;
using Snake.Models;
using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake.Core
{
    public class Game
    {
        private Wall Wall;
        public List<Food> Foods { get; protected set; }
        public Models.Snake Snake { get; protected set; }
        private int Speed;
        private int FoodCount ;
        private bool IsBotEnabled;

        public Game(int speed,bool deadlywalls,int food,bool isBotEnabled)
        {
            Console.Clear();
            Wall = new Wall();
            Foods = new List<Food>();
            Snake = new Models.Snake(Console.WindowWidth - 1, Console.WindowHeight - 1, Foods,deadlywalls);
            Speed = speed;
            FoodCount = food;
            IsBotEnabled = isBotEnabled;
        }
    
        public void Start()
        {
            ConsoleKeyInfo input;
            List<Direction> directions = new List<Direction>();
            while (true)
            {
                if (Foods.Count< FoodCount)
                {
                    GenerateFood(FoodCount);
                }

                if (IsBotEnabled)
                {
                    BotEngine botEngine = new BotEngine(Speed);
                    botEngine.Run(this);
                }
                else
                {
                    input = Reader.ReadLine(Speed);
                    MoveSnake(input.Key);
                }
            }
        }

        public void Render()
        {
            Wall.Render();
            Snake.Render();
            Foods[0].Render();
        }

        private void GenerateFood(int desiredFoodCount)
        {
            while (Foods.Count<desiredFoodCount)
            {
                Random random = new Random();
                int x = random.Next(1, this.Wall.BottomX - 2);
                int y = random.Next(1, Wall.BottomY - 2);
                if (!Snake.ContainsPoint(x,y))
                {
                    Foods.Add(new Food(x, y));
                }
            }
        }

        public void MoveSnake(ConsoleKey input)
        {
            if (input == ConsoleKey.LeftArrow)
            {
                Snake.Move(Direction.Left);
            }
            else if (input == ConsoleKey.RightArrow)
            {
                Snake.Move(Direction.Right);
            }
            else if (input == ConsoleKey.UpArrow)
            {
                Snake.Move(Direction.Up);
            }
            else if (input == ConsoleKey.DownArrow)
            {
                Snake.Move(Direction.Down);
            }
            Console.SetCursorPosition(1, 1);
        }
    }
}
