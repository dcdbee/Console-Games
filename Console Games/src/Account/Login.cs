using Console_Games.src.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games.src.Account
{
    class Login
    {
        public static bool LoginAccount(string dbname, string username, string password)
        {
            DatabaseManager.Data Retrieve;
            Retrieve = DatabaseManager.RetrieveFromDB("Data", "Username", "string", "Password", "string", username);
            return (password == Retrieve.contents);
        }
    }
}
