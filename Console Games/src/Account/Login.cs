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
            if (password == Retrieve.contents)
            {
                AccountManager.Cache cache;
                cache = AccountManager.GetCache();
                cache.loggedIn = true;
                cache.username = username;
                AccountManager.SetCache(cache);
                return true;
            }
            return false;
        }

        public static void LoginSystem(string dbname)
        {
            string username = "";
            string password;
            bool valid = false;
            while (!valid)
            {
                TextUtil.CosmeticText("Username:", ConsoleColor.Cyan, 25, true, false);
                Console.ForegroundColor = ConsoleColor.White;
                username = Console.ReadLine();
                Console.WriteLine();
                TextUtil.CosmeticText("Password: ", ConsoleColor.Cyan, 25, true, false);
                Console.ForegroundColor = ConsoleColor.White;
                password = Console.ReadLine();
                if(LoginAccount(dbname, username, password))
                {
                    TextUtil.CosmeticText("Successfully logged you in.", ConsoleColor.Green, 25, true, true);
                    valid = true;
                }
                else
                {
                    TextUtil.CosmeticText("Error: Incorrect username or password", ConsoleColor.Red, 25, true, true);

                }
            }

        }
    }
}
