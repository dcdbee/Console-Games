using Console_Games.src.Database;
using Console_Games.src.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using Console_Games.src.Account;
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
            AccountManager.Cache tcache;
            tcache.username = username;
            tcache.loggedIn = true;
            AccountManager.SetCache(tcache);
            return (password == Retrieve.contents);
        }
    }
}
