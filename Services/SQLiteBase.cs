using CalendarAE.Interfaces;
using CalendarAE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAE.Services
{
    public class SQLiteBase
    {
        public SQLiteConnection connectionDB;

        public SQLiteBase() 
        {
            if (connectionDB != null) return;

            try
            {
                connectionDB = new SQLiteConnection(Constantes.DataBasePath, Constantes.Flags);
                connectionDB.CreateTable<Calendario>();
                connectionDB.CreateTable<Horario>();
                connectionDB.CreateTable<Festivo>();
                connectionDB.CreateTable<Curso>();
            }
            catch (Exception ex)
            {
                var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                using StreamWriter sw = new(System.IO.Path.Combine(basePath, "logCalendar.txt"), true);
                sw.WriteLine("SQLiteBase: " + DateTime.Now + " - " + ex.Message);
            }
        }

        #region Operations
        public static void Backup()
        {
            try
            {
                SQLiteConnection sourceDB = new(Constantes.DataBasePath, Constantes.Flags);
                sourceDB.Backup(Constantes.BackupPath, "main");
            }
            catch (Exception ex)
            {
                var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                using StreamWriter sw = new(System.IO.Path.Combine(basePath, "logCalendar.txt"), true);
                sw.WriteLine("SQLiteBase: " + DateTime.Now + " - " + ex.Message);
            }
        }

        #endregion
    }
}
