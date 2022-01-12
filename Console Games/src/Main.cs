using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console_Games.src.Database;
using Console_Games.src.Account;
using System.Threading.Tasks;

namespace Console_Games
{
    class Program
    {
        static void Main()
        {
            DatabaseManager.CreateDB("Data");
            Register.CreateAccount("Data", "xd", "hey");

            DatabaseManager.Data Retrieve;
            Retrieve = DatabaseManager.RetrieveFromDB("Data", "Username", "string", "Password", "string", "matt");
            Console.WriteLine(Retrieve.variableName + " " + Retrieve.type + " " + Retrieve.contents);

            Console.WriteLine(Login.LoginAccount("Data", "username", "pass")); //returns true or false

            Console.ReadKey();
        }
    }
}