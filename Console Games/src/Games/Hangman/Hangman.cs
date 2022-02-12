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
        const int LoadingTime = 5; 
        static string hangmanAscii;
        static string wordList;

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
            Console.WriteLine(DisplayHangman(1));
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

            GameInfo info;
            Account.AccountManager.Cache tmpCache = Account.AccountManager.GetCache();
            info.username = tmpCache.username;
            info.won = false;
            info.round = 1;
            info.word = generateWord();
            info.hangmanStage = 6;

            TextUtil.LoadingFX(2);
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
            return word;
        }
    }
}
