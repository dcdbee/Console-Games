using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Games.src.Util
{
    class TextUtil
    {

        public static void CosmeticText(string content, ConsoleColor colour, int time, bool centered, bool newline)
        {
            int spacing = Console.WindowWidth / 2 - content.Length / 2;
            for (int j = 0; j < spacing; j++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < content.Length; i++)
            {
                Console.ForegroundColor = colour;
                Console.Write(content[i]);
                Thread.Sleep(time);
            }
            if (newline) { Console.WriteLine(); }
        }

        public static void CosmeticAscii(string content, ConsoleColor colour)
        {
            string[] splitContent = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Console.SetCursorPosition(Console.WindowWidth / 2,Console.WindowHeight / 2);
            int spacing = Console.WindowWidth / 2 - splitContent[0].Length / 2;
            for (int i = 0; i < splitContent.Length; i++)
            {
                for (int j = 0; j < spacing; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(splitContent[i]);
                Console.WriteLine();
            }
        }

        public static void LoadingFX(int LoadingTime)
        {
            string word = "Loading";
            int count = 0;
            for (int i = 0; i < LoadingTime; i++)
            {
                TextUtil.EmptySpaces(Console.WindowHeight / 3);
                TextUtil.CosmeticText(word, ConsoleColor.Green, 0, false, false);
                word += ".";
                count++;
                if (count > 3)
                {
                    word = "Loading";
                }
                Thread.Sleep(500);
                Console.Clear();
                Thread.Sleep(2);
            }
        }

        public static void EmptySpaces(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                Console.WriteLine();
            }
        }

        public static void ErrorHandling(Exception e)
        {
            string message = "ERROR: " + e.Message;
            CosmeticText(message, ConsoleColor.Red, 25, true, true);
        }

    }
}
