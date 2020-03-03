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
        private string connectionString = @"Data Source=C:\Users\iwake\OneDrive - wake\Desktop\Mia\Db\miaUsed.sqlite;" + "Version=3";
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

            UsedInfo usedInfo = new UsedInfo();
            Random rd = new Random();
            
            usedInfo.DbId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            usedInfo.HospitalNo = (rd.Next(1000) + 64500).ToString();
            usedInfo.BedNo = rd.Next(100).ToString();
            usedInfo.Name = "Patient";
            usedInfo.Age = rd.Next(80).ToString();

            //usedInfo.TagCode = (rd.Next(10000) + 0110111441288).ToString();
            long TagCodeTemp = rd.Next(10000) + 0110111441288;
            for (int TagCodeNum = 0; TagCodeNum <= rd.Next(13); TagCodeNum++)
            {
                usedInfo.TagCode += (TagCodeTemp + TagCodeNum).ToString()+',';
            }


            //sqlCommand = string.Format("INSERT INTO Used(DbId,HospitalNo,BedNo,Name,Age,TagCode ) VALUES({0},{1},{2},{3},{4},{5})", usedInfo.DbId, usedInfo.HospitalNo, usedInfo.BedNo, usedInfo.Name, usedInfo.Age, usedInfo.TagCode);
            sqlCommand = "INSERT INTO Used(DbId,HospitalNo,BedNo,Name,Age,TagCode ) VALUES("
            + usedInfo.DbId + ", '" + usedInfo.HospitalNo + "', '" + usedInfo.BedNo + "', '"
            + usedInfo.Name + "', '" + usedInfo.Age + "', '" + usedInfo.TagCode + "')"; 

            Console.WriteLine(sqlCommand);
            //sqlCommand = string.Format("INSERT INTO Used(DbId) VALUES({0})", usedInfo.DbId);
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
