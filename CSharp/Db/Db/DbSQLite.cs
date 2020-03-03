using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SQLite;

namespace Db
{
    class DbSQLite
    {
        //string fileDirection { get; set }
        private string connectionString = "Data Source=C:\\WK\\Db\\Used.sqlite;Version=3";
        private int DbType = 2; // 0: Access, 1: SQL Server, 2: SQLite
        private string sqlCommand;

        public DbSQLite()
        {

        }
        public int SQLiteTestAll()
        {
            int ret = 0;
            try
            {
                SQLiteTestConn();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.ToString());

                return -1;
            }
            return ret;

        }
        public int SQLiteTestConn()
        {
            int ret = 0;
            sqlCommand = "";
            try
            {
                DbOperation dbOperation = new DbOperation(connectionString, DbType);
                //dbOperation.ExecuteNonQuery(sqlCommand);

            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.ToString());

                return -1;
            }
            return ret;
        }
        public void SQLiteConn()
        {

            DbOperation dbOperation = new DbOperation(connectionString, DbType);
            //dbOperation.ExecuteNonQuery(sqlCommand);

        }
        public void SQLiteInsert()
        {

            DbOperation dbOperation = new DbOperation(connectionString, DbType);
            sqlCommand = "INSERT INTO Used(DbId,Name) VALUES(11,'Tom')";
            dbOperation.ExecuteNonQuery(sqlCommand);

        }
        public void SQLiteQuery()
        {

            DbOperation dbOperation = new DbOperation(connectionString, DbType);
            //dbOperation.ExecuteNonQuery(sqlCommand);

        }
        //public int SQLiteTestInsert()
        //{
        //    int ret = 0;
        //    sqlCommand = "";
        //    try
        //    {
        //        DbOperation dbOperation = new DbOperation(connectionString, DbType);
        //        dbOperation.ExecuteNonQuery(sqlCommand);

        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Console.WriteLine(ex.ToString());

        //        return -1;
        //    }
        //    return ret;
        //}
        //public int SQLiteTestQuery()
        //{
        //    int ret = 0;
        //    sqlCommand = "";
        //    try
        //    {
        //        DbOperation dbOperation = new DbOperation(connectionString, DbType);
        //        dbOperation.ExecuteNonQuery(sqlCommand);

        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Console.WriteLine(ex.ToString());

        //        return -1;
        //    }
        //    return ret;
        //}
    }
}
