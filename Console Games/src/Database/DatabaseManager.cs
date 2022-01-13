using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games.src.Database
{
    class DatabaseManager
    {
        public struct Data
        {
            public string variableName;
            public string type;
            public string contents;
        }

        public static void CreateDB(string dbname)
        {
            if (DBExists(dbname))
            {
                Console.WriteLine("database already exists idiot");
            }
            else
            {
                using (FileStream fs = File.Create(                                                                               dbname + ".txt"))
                {
                    fs.Close();
                }
                using (StreamWriter writer = new StreamWriter(                                                                               dbname + ".txt", false))
                {
                    writer.WriteLine(dbname + " - Created " + DateTime.Now);
                    writer.WriteLine("-==== DATA ====-");
                    writer.Close();
                }
            }
        }

        public static bool DBExists(string dbname)
        {
            try
            {
                string[] Lines = File.ReadAllLines(dbname + ".txt");
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static void WriteToDB(string dbname, Data[] variable)
        {
            using (StreamWriter writer = new StreamWriter(dbname + ".txt", true))
            {
                for(int i = 0; i < variable.Length; i++)
                {
                    writer.Write(variable[i].variableName + ":" + variable[i].type + ":" + variable[i].contents + "|");
                }
                writer.WriteLine();
                writer.Close();
            }
        }

        public static Data RetrieveFromDB(string dbname, string RetrieveVarName, string VarType, string WhereVarName, string WhereVarType, string where)
        {
            Data Null;
            string[] lines = File.ReadAllLines(dbname + ".txt");
            for(int i = 2; i < lines.Length; i++)
            {
                string temp = lines[i];
                string[] Variables = temp.Split('|');
                string[] tVar1 = Variables[0].Split(':');
                string[] tVar2 = Variables[1].Split(':');

                Data Var1;
                Data Var2;

                Var1.variableName = tVar1[0];
                Var1.type = tVar1[1];
                Var1.contents = tVar1[2];
                Var2.variableName= tVar2[0];
                Var2.type = tVar2[1];
                Var2.contents = tVar2[2];

                //            DatabaseManager.RetrieveFromDB("Data", "Username", "string", "Password", "string", "matt");
                if (Var1.variableName == RetrieveVarName && Var1.type == VarType && Var2.variableName == WhereVarName && Var2.type == WhereVarType && Var1.contents == where)
                {
                    return Var2;
                }
            }
            Null.variableName = "null";
            Null.contents = "null";
            Null.type = "null";
            return Null;
        }

        public static bool ExistsInDB(string dbname, string variableName, string variableType, string contents)
        {
            string[] lines = File.ReadAllLines(dbname + ".txt");
            for(int i = 2; i < lines.Length; i++)
            {
                string temp = lines[i];
                string[] Variables = temp.Split('|');
                string[] tVar1 = Variables[0].Split(':');

                Data Var1;
                Var1.variableName = tVar1[0];
                Var1.type = tVar1[1];
                Var1.contents = tVar1[2];
                if(variableName == Var1.variableName && variableType == Var1.type && Var1.contents == contents)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
