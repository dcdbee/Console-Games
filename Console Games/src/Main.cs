using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console_Games.src.Database;
using Console_Games.src.Account;
using System.Threading.Tasks;
using Console_Games.src.Games;
using Console_Games.src.Games.Snake;

namespace Console_Games
{
    //Retrieve = DatabaseManager.RetrieveFromDB(dbname, "Username", "string", "Password", "string", "dcdb");
    ////                                         SELECT Username FROM Data WHERE Password(string) = 'dcdb'
    class Program
    {
        const string dbname = "Data";
        static void Main()
        {
            Console.ReadKey();
            Snake2.Init();
            Console.ReadKey();
            //DatabaseManager.CreateDB(dbname);
            //Register.CreateAccountSystem();
            //GameManager.PlayGame("Hangman");
            //Login.LoginSystem(dbname);
            //Console.ReadKey();
        }
    }
}