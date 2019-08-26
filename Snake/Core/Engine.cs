using SimpleSnake.Utilities;
using Snake.Models;
using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core
{   
    public class Engine
    {
        private const char MenuSymbol = '\u25ba';

        public void Run()
        {
            
            while (true)
            {
                try
                {
                    ConsoleWindow.CustomizeConsole();
                    Game game = SettingGameOptions();
                    game.Start();
                }
                catch (GameOver gg)
                {
                    if (GameOverScrean(gg.Message))
                    {
                        Console.Clear();
                        return;
                    }
                    
                }
            }
        }

        private Game SettingGameOptions()
        {
            List<List<string>> OptionsMenue = new List<List<string>>
            {
                FileToList(@"..\..\..\Menu\StartMenu.txt"),
                FileToList(@"..\..\..\Menu\OptionsMenu.txt"),
                FileToList(@"..\..\..\Menu\Speed.txt"),
                FileToList(@"..\..\..\Menu\DeadlyWalls.txt"),
                FileToList(@"..\..\..\Menu\Colors.txt"),
                FileToList(@"..\..\..\Menu\Colors.txt"),
                FileToList(@"..\..\..\Menu\Food.txt"),
                FileToList(@"..\..\..\Menu\Bot.txt")
            };
            StartMenu menu = new StartMenu(OptionsMenue);
            int[] selectedOptions = menu.OptionSelection();
            int speed;
            switch (selectedOptions[0])
            {
                case 0:
                    speed = 200;
                    break;
                case 1:
                    speed = 80;
                    break;
                case 2:
                    speed = 60;
                    break;
                case 3:
                    speed = 30;
                    break;
                case 4:
                    speed = 10;
                    break;
                default:
                    speed = 80;
                    break;
            }
            bool deadlyWalls = selectedOptions[1] == 0;
            ConsoleColor background = ConsoleColor.White;
            ConsoleColor foreground = ConsoleColor.Black;
            if (selectedOptions[2]!=-1)
            {
                background = ColorSwitch.consoleColor(selectedOptions[2]);
            }
            if (selectedOptions[3] != -1)
            {
                foreground = ColorSwitch.consoleColor(selectedOptions[3]);
            }
            ConsoleWindow.CustomizeConsole(foreground, background);
            
            Console.Clear();
            Game game = new Game(speed, deadlyWalls,Math.Abs(selectedOptions[4]),selectedOptions[5]==0);
            return game;
        }

        private bool GameOverScrean(string gg)
        {
            EndGame end = new EndGame(FileToList(@"..\..\..\Menu\EndGame.txt"), gg);
            return end.StartSelecting() != 0;
        }

        private List<string> FileToList(string path)
        {
            List<string> output = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
                output.Add(line);
            }
            return output;
        }
    }
}
