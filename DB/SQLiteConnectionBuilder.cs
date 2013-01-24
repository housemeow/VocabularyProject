using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.IO;
using System.Data.SQLite;


namespace SQLiteCon
{
    /// <summary>
    /// 此類別可建立SQLite資料庫的Connection
    /// </summary>
    class SQLiteConnectionBuilder
    {
        private static DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SQLite");

        /// <summary>
        /// 利用DbConnection
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetDbConnection()
        {
            CreateUnexistDBFile();
            DbConnection cnn = dbProviderFactory.CreateConnection();
            cnn.ConnectionString = "Data Source=db/db.s3db";
            return cnn;
        }

        public static SQLiteConnection GetSQLiteConnection()
        {
            CreateUnexistDBFile();
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=db/db.s3db");
            return sqliteConnection;
        }

        /// <summary>
        /// 如果檔案不存在就建立
        /// </summary>
        private static void CreateUnexistDBFile()
        {
            if (!Directory.Exists("db"))
            {
                Directory.CreateDirectory("db");
            }
            //檔案不存在時就建立
            if (!File.Exists("db/db.s3db"))
            {
                //自動建立SQLite檔案
                SQLiteConnection.CreateFile("db/db.s3db");
            }
        }
    }
}
