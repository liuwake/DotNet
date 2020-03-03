using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Db
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    DbSQLite dbSQLite = new DbSQLite();
            //    //dbSQLite.SQLiteTestAll();
            //    dbSQLite.SQLiteTestConn();
            //    Console.WriteLine("OK");
            //}
            //catch(SQLiteException ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //finally
            //{

            //}

            DbSQLite dbSQLite = new DbSQLite();
            //    //dbSQLite.SQLiteTestAll();
            //dbSQLite.SQLiteTestConn();
            //dbSQLite.SQLiteConn();
            dbSQLite.SQLiteInsert();
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
