using Console_Games.src.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Games.src.Games.Hangman
{
    class Hangman
    {
        const string Wordsurl = "https://raw.githubusercontent.com/Xethron/Hangman/master/words.txt";
        const string asciiURL = "https://pastebin.com/raw/LY0Da9Qp";
        const int LoadingTime = 50; 
        static string hangmanAscii;
        static string wordList;
        static List<char> guessedChars = new List<char>();
        static GameInfo info;

        public struct GameInfo
        {
            public string username;
            public string word;
            public bool won;
            public int round;
            public int hangmanStage;
        }

        public static void Init()
        {
            Loading();
            Console.ReadKey();
        }

        public static void Loading()
        {
            if (String.IsNullOrEmpty(hangmanAscii))
            {
                hangmanAscii = Retrieve(asciiURL);
            }
            if (String.IsNullOrEmpty(wordList))
            {
                wordList = Retrieve(Wordsurl);
            }

            Account.AccountManager.Cache tmpCache = Account.AccountManager.GetCache();
            info.username = tmpCache.username;
            info.won = false;
            info.round = 1;
            info.word = generateWord();
            info.hangmanStage = 6;

            TextUtil.LoadingFX(2);

            PlayGame();
        }

        public static void PlayGame()
        {
            info.won = CheckWon();
            while (!info.won)
            {
                DisplayBoard();
                MakeGuess();
                info.won = CheckWon();
            }
            DisplayBoard();
            Console.WriteLine("WON");
        }

        public static void DisplayBoard()
        {
            Console.Clear();
            string msg = "";
            string msg2 = "Guessed letters: ";
            for (int i = 0; i < info.word.Length; i++)
            {
                if (GuessedCheck(info.word[i]))
                {
                    msg += info.word[i];
                }
                else
                {
                    msg += "_";
                }
                msg += " "; 
            }
            TextUtil.EmptySpaces(Console.WindowHeight/3);
            for(int j = 0; j < guessedChars.Count; j++)
            {
                msg2 += guessedChars[j];
                if(j != guessedChars.Count)
                {
                    msg2 += ",";
                }
            }
            TextUtil.CosmeticText(msg2, ConsoleColor.Blue, 2, true, true);
            TextUtil.EmptySpaces(1);
            TextUtil.CosmeticText(msg, ConsoleColor.Blue, 2, true, true);

        }

        public static void MakeGuess()
        {
            bool valid = false;
            char guessChar = '.';
            TextUtil.EmptySpaces(2);
            TextUtil.CosmeticText("INPUT:", ConsoleColor.White, 5, true, false);
            string input = Console.ReadLine();
            while (!valid)
            {
                try
                {
                    guessChar = char.Parse(input);
                    valid = true;
                    if (GuessedCheck(guessChar))
                    {
                        TextUtil.CosmeticText("ERROR: You have already guessed that character.", ConsoleColor.Red, 25, true, true);
                        valid = false;
                        TextUtil.EmptySpaces(1);
                        TextUtil.CosmeticText("INPUT:", ConsoleColor.White, 50, true, false);
                        input = Console.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    TextUtil.ErrorHandling(e);
                    valid = false;
                    TextUtil.EmptySpaces(1);
                    TextUtil.CosmeticText("INPUT:", ConsoleColor.White, 50, true, false);
                    input = Console.ReadLine();
                }
            }
            guessedChars.Add(guessChar);
        }

        public static bool GuessedCheck(char character)
        {
            for(int i = 0; i < guessedChars.Count; i++)
            {
                if(guessedChars[i] == character)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckWon()
        {
            for(int i = 0; i < info.word.Length; i++)
            {
                if (!GuessedCheck(info.word[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static string Retrieve(string url)
        {
            var client = new WebClient();
            string contents = client.DownloadString(url);
            return contents;
        }

        public static string DisplayHangman(int num)
        {
            string[] splitContent = hangmanAscii.Split('/');
            return splitContent[num];
        }

        public static string generateWord()
        {
            List<string> Words = new List<string>();
            string[] splitContent = wordList.Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < splitContent.Length; i++)
            {
                Words.Add(splitContent[i]);
            }
            Random rnd = new Random();
            string word  =  Words[rnd.Next(0, Words.Count)];
            while(word.Length < 5)
            {
                word = Words[rnd.Next(0, Words.Count)];
            }
            return word.ToLower();
        }
    }
}
