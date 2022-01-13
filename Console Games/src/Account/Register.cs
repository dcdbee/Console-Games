using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Games.src.Database;
using Console_Games.src.Util;

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

        public static void CreateAccountSystem()
        {
            string username = "";
            string password = "";
            bool valid = false;
            while (!valid)
            {
                TextUtil.CosmeticText("Please enter a username for the account you wish to create.", ConsoleColor.Cyan, 25, true, true);
                TextUtil.CosmeticText("INPUT:", ConsoleColor.White, 25, true, false);

                username = Console.ReadLine();
                if(username.Length > 12)
                {
                    TextUtil.CosmeticText("ERROR: The username must have less than 12 characters", ConsoleColor.Red, 25, true, true);
                }
                else if(username.Length <= 3)
                {
                    TextUtil.CosmeticText("ERROR: The username must have more than 3 characters", ConsoleColor.Red, 25, true, true);
                }
                else
                {
                    valid = true;
                }
            }

            valid = false;
            while (!valid)
            {
                TextUtil.CosmeticText("Now enter a password for your account.", ConsoleColor.Cyan, 25, true, true);
                TextUtil.CosmeticText("INPUT:", ConsoleColor.White, 25, true, false);

                password = Console.ReadLine();
                if (password.Length > 16)
                {
                    TextUtil.CosmeticText("ERROR: The password must have less than 17 characters", ConsoleColor.Red, 25, true, true);
                }
                else if (password.Length <= 5)
                {
                    TextUtil.CosmeticText("ERROR: The password must have atleast 6 characters", ConsoleColor.DarkRed, 25, true, true);
                }
                else
                {
                    valid = true;
                }
            }
            CreateAccount("Data", username, password);
            Login.LoginAccount("Data", username, password);

        }
    }
}
