using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console_Games.src.Database;
using Console_Games.src.Account;
using System.Threading.Tasks;
using Console_Games.src.Games;

namespace Console_Games
{
    //Retrieve = DatabaseManager.RetrieveFromDB(dbname, "Username", "string", "Password", "string", "dcdb");
    ////                                         SELECT Username FROM Data WHERE Password(string) = 'dcdb'
    class Program
    {
        static void Main()
        {
            GameManager.PlayGame("Hangman");
            //DatabaseManager.CreateDB(dbname);
            //Register.CreateAccountSystem();
            //Login.LoginSystem(dbname);
            //Console.ReadKey();
        }
    }
}