using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games.src.Games
{
    class GameManager
    {
        public static void PlayGame(string name)
        {
            if(name == "Hangman")
            {
                Hangman.Hangman.Init();
            }
            else
            {
                Snake.Snake.Init();
            }
        }

    }
}
