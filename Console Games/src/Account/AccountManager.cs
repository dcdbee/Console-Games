using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Games.src.Database;

namespace Console_Games.src.Account
{
    class AccountManager
    {
        public static Cache userCache;
        public struct Cache
        {
            public string username;
            public bool loggedIn;
        }

        public static Cache GetCache()
        {
            return userCache;
        }

        public static void SetCache(Cache cache)
        {
            userCache = cache;
        }

        public static DatabaseManager.Data[] GenerateAccountInfo(string username, string password){
            DatabaseManager.Data UsernameData;
            DatabaseManager.Data PasswordData;
            UsernameData.variableName = "Username";
            UsernameData.type = "string";
            UsernameData.contents = username;
            PasswordData.variableName = "Password";
            PasswordData.type = "string";
            PasswordData.contents = password;
            DatabaseManager.Data[] AccountInfo = { UsernameData, PasswordData };
            return AccountInfo;
        }

        public static bool accountExists(string dbname, string username){
            return DatabaseManager.ExistsInDB(dbname, "Username", "string", username);
        }

    }
}
