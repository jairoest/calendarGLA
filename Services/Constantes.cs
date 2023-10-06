using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketOne.Services
{
    internal class Constantes
    {
        private const string DataBaseFileName = "SQLitePocketOne.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DataBasePath
        {
            get
            {
                var basePath =
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                return System.IO.Path.Combine(basePath, DataBaseFileName);
            }
        }
    }
}
