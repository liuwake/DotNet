using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Db
{
    class SqliteOp

    {
        SQLiteConnection SQLiteConnection;

        public SqliteOp(string connectionString)
        {
            // Sample connection string: "Data Source=C:\\UVSS.sqlite;Version=3";
            SQLiteConnection = new SQLiteConnection(connectionString);
        } 
         public int create(string fileDirection)
        {
            int ret = 0;
            try
            {
                var fileName = fileDirection;

                SQLiteConnection.CreateFile(fileName);
            
            }
            catch(SQLiteException ex)
            {
                Console.WriteLine(ex.ToString());

                return -1;
            }
            return ret;
        }
        
    }
}
