using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Games.src.Games.Snake
{
    class Snake
    {
        public static int playerLength = 1;
        public static string direction = "right";
        public static List<int> px = new List<int>();
        public static List<int> py = new List<int>();
        public static int pointx;
        public static int pointy;
        public static char[,] Board;
        public static void Init()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("hey");
            SetupBoard();
            Console.ReadKey();
            while (true)
            {
                DisplayBoard();
                Move();
                Thread.Sleep(25);
            }
        }
        public static void DisplayBoard()
        {
            Console.Clear();
            for (int height = 0; height < Console.WindowHeight; height++)
            {
                for (int width = 0; width < Console.WindowWidth; width++)
                {
                    if(Board[width,height] == 'b')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("█");
                    }
                    else if(Board[width,height] == 'p' || Board[width,height] == 'm')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("█");
                    }
                    else if (Board[width, height] == 'r')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("⬛");
                    }
                }
            }
        }

        public static void SetupBoard()
        {
            Board = new char[Console.WindowWidth, Console.WindowHeight];
            for (int height = 0; height < Console.WindowHeight; height++)
            {
                for (int width = 0; width < Console.WindowWidth; width++)
                {
                    Board[width, height] = 'b';
                }
            }
            Random rnd = new Random();
            int playerx = rnd.Next(0, Console.WindowWidth);
            int playery = rnd.Next(0, Console.WindowHeight);
            Board[playerx, playery] = 'p';
        }

        public static void Move()
        {
            bool complete = false;
            if(direction == "right")
            {
                for(int i = 0; i < playerLength; i++)
                {
                    for (int height = 0; height < Console.WindowHeight; height++)
                    {
                        for (int width = 0; width < Console.WindowWidth; width++)
                        {
                            if (Board[width, height] == 'p' && !complete)
                            {
                                Board[width, height] = 'b';
                                int t = width + 1;
                                Board[t, height] = 'p';
                                complete = true;
                            }
                        }
                    }
                }
            }
        }

    }
}
