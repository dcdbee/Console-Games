using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
