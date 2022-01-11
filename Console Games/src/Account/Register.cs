using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Games.src.Database;

namespace Console_Games.src.Account
{
    class Register
    {
        public static void CreateAccount(string dbname, string username, string password)
        {
            if(!AccountManager.accountExists(dbname, username))
            {
                DatabaseManager.WriteToDB(dbname, AccountManager.GenerateAccountInfo(username, password));
            }
        }
    }
}
