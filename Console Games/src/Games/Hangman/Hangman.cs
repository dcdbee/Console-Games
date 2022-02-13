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
        const string asciiURL = "https://pastebin.com/raw/auFJ2qDg";
        const int LoadingTime = 50; 
        static string hangmanAscii;
        static string wordList;
        static List<char> guessedChars = new List<char>();
        static GameInfo info;

        public struct GameInfo
        {
            public string username;
            public string word;
            public string status;
            public int round;
            public int hangmanStage;
            public int correctGuesses;
            public int incorrectGuesses;
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
            info.status = "playing";
            info.round = 1;
            info.word = generateWord();
            info.hangmanStage = 6;
            info.correctGuesses = 0;
            info.incorrectGuesses = 0;

            TextUtil.LoadingFX(2);

            PlayGame();
        }

        public static void PlayGame()
        {
            info.status = CheckEnd();
            while (info.status == "playing")
            {
                DisplayBoard();
                MakeGuess();
                info.status = CheckEnd();
            }
            DisplayBoard();
            if (info.status == "won")
            {
                Console.WriteLine("WON");
            }
            else if(info.status == "lost")
            {
                Console.WriteLine("You lost");
            }
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
            for(int j = 0; j < guessedChars.Count; j++)
            {
                msg2 += guessedChars[j];
                if(j != guessedChars.Count)
                {
                    msg2 += ",";
                }
            }
            //TextUtil.CosmeticText(DisplayHangman(info.incorrectGuesses), ConsoleColor.Green, 0, true, true);
            if(info.incorrectGuesses == 0)
            {
                TextUtil.EmptySpaces(5);
            }
            TextUtil.CosmeticAscii(DisplayHangman(info.incorrectGuesses), ConsoleColor.Green);
            TextUtil.EmptySpaces(1);
            TextUtil.CosmeticText(msg2, ConsoleColor.Blue, 0, true, true);
            TextUtil.EmptySpaces(1);
            TextUtil.CosmeticText(msg, ConsoleColor.Blue, 0, true, true);
        }

        public static void MakeGuess()
        {
            bool valid = false;
            char guessChar = '.';
            TextUtil.EmptySpaces(2);
            TextUtil.CosmeticText("INPUT:", ConsoleColor.White, 0, true, false);
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
                    if (!validChar(guessChar))
                    {
                        TextUtil.CosmeticText("ERROR: Invalid character.", ConsoleColor.Red, 25, true, true);
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
            bool correct = false;
            for (int i = 0; i < info.word.Length; i++)
            {
                if (info.word[i] == guessChar)
                {
                    info.correctGuesses++;
                    correct = true;
                }
            }
            if (!correct)
            {
                info.incorrectGuesses++;
            }
            
        }

        public static bool validChar(char character)
        {
            bool valid = false;
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for(int i = 0; i < alphabet.Length; i++)
            {
                if (character == alphabet[i])
                {
                    valid = true;
                }
            }
            return valid;
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

        public static string CheckEnd()
        {
            if(info.incorrectGuesses >= 7)
            {
                return "lost";
            }
            for(int i = 0; i < info.word.Length; i++)
            {
                if (!GuessedCheck(info.word[i]))
                {
                    return "playing";
                }
            }
            return "won";
        }

        public static string Retrieve(string url)
        {
            var client = new WebClient();
            string contents = client.DownloadString(url);
            return contents;
        }

        public static string DisplayHangman(int num)
        {
            string[] splitContent = hangmanAscii.Split('@');
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
