using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Games.src.Games.Snake
{
    class Snake2
    {
        public static char[,] Board;
        public static List<int> xsnake = new List<int>();
        public static List<int> ysnake = new List<int>();

        public static void Init()
        {
            SetupBoard();
            while (true)
            {
                Move();
                DisplayBoard();
                Thread.Sleep(10);
            }
        }

        private static void DisplayBoard()
        {
            Board = new char[Console.WindowWidth, Console.WindowHeight];
            Console.Clear();
            for(int snakex = 0; snakex < xsnake.Count; snakex++)
            {
                Board[xsnake[snakex], ysnake[snakex]] = 'S'; 
            }
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                for(int j = 0; j < Console.WindowHeight; j++)
                {
                    if(Board[i,j] == 'S')
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("■");
                    }
                }
            }
        }

        public static void SetupBoard()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, Console.WindowWidth);
            int y = rnd.Next(0, Console.WindowHeight);
            xsnake.Add(x);
            ysnake.Add(y);
        }

        public static void Move()
        {
            List<int> tempx = new List<int>();
            List<int> tempy = new List<int>();
            for (int x = 0; x < xsnake.Count; x++)
            {
                int tempxval = xsnake[x] + 1;
                int tempyval = ysnake[x];
                tempx.Add(tempxval);
                tempy.Add(tempyval);
            }
            xsnake.Clear();
            ysnake.Clear();
            for(int i = 0; i < tempx.Count; i++)
            {
                xsnake.Add(tempx[i]);
                ysnake.Add(tempy[i]);
            }
        }
    }
}
