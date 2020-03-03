using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows;

namespace Db
{


    class DbOperation
    {
        private OleDbConnection OleDbConnection;
        private SqlConnection SqlConnection;
        private SQLiteConnection SQLiteConnection;
        private OleDbDataAdapter OleDbAdapter;
        private SqlDataAdapter SqlAdapter;
        private SQLiteDataAdapter SQLiteAdapter;
        private DataSet DataSet;
        private DataTable Table;
        private OleDbCommandBuilder OleDbCommandBuilder;
        private SqlCommandBuilder SqlCommandBuilder;
        private SQLiteCommandBuilder SQLiteCommandBuilder;
        private int DbType = 0; // 0: Access, 1: SQL Server, 2: SQLite

        public DbOperation(string connectionString, int DbType)
        {
            this.DbType = DbType;

            if (DbType == 0)
            {
                // Sample connection string: "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Database.mdb"
                OleDbConnection = new OleDbConnection(connectionString);
            }
            else if (DbType == 1)
            {
                // Sample connection string: "Data Source=127.0.0.1;Initial Catalog=Database;User ID=userid;Password=password"
                SqlConnection = new SqlConnection(connectionString);
            }
            else
            {
                // Sample connection string: "Data Source=C:\\UVSS.sqlite;Version=3";
                SQLiteConnection = new SQLiteConnection(connectionString);
            }
        }

        public int ExecuteNonQuery(string sqlCommand)
        {
            int ret = 0;

            try
            {
                if (DbType == 0)
                {
                    OleDbConnection.Open();

                    OleDbCommand command = new OleDbCommand(sqlCommand, OleDbConnection);
                    ret = command.ExecuteNonQuery();

                    OleDbConnection.Close();
                }
                else if (DbType == 1)
                {
                    SqlConnection.Open();

                    SqlCommand command = new SqlCommand(sqlCommand, SqlConnection);
                    ret = command.ExecuteNonQuery();

                    SqlConnection.Close();
                }
                else
                {
                    SQLiteConnection.Open();

                    SQLiteCommand command = new SQLiteCommand(sqlCommand, SQLiteConnection);
                    ret = command.ExecuteNonQuery();

                    SQLiteConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());

                return -1;
            }

            return ret;
        }

        public DataSet ExecuteDataSet(string sqlCommand)
        {
            try
            {
                if (DbType == 0)
                {
                    OleDbConnection.Open();

                    OleDbAdapter = new OleDbDataAdapter(sqlCommand, OleDbConnection);
                    DataSet = new DataSet();
                    OleDbAdapter.Fill(DataSet);
                    OleDbCommandBuilder = new OleDbCommandBuilder(OleDbAdapter);

                    OleDbConnection.Close();
                }
                else if (DbType == 1)
                {
                    SqlConnection.Open();

                    SqlAdapter = new SqlDataAdapter(sqlCommand, SqlConnection);
                    DataSet = new DataSet();
                    SqlAdapter.Fill(DataSet);
                    SqlCommandBuilder = new SqlCommandBuilder(SqlAdapter);

                    SqlConnection.Close();
                }
                else
                {
                    SQLiteConnection.Open();

                    SQLiteAdapter = new SQLiteDataAdapter(sqlCommand, SQLiteConnection);
                    DataSet = new DataSet();
                    SQLiteAdapter.Fill(DataSet);
                    SQLiteCommandBuilder = new SQLiteCommandBuilder(SQLiteAdapter);

                    SQLiteConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());

                return null;
            }

            return DataSet;
        }

        public DataTable ExecuteDataTable(string sqlCommand)
        {
            try
            {
                if (DbType == 0)
                {
                    OleDbConnection.Open();

                    OleDbAdapter = new OleDbDataAdapter(sqlCommand, OleDbConnection);
                    Table = new DataTable();
                    OleDbAdapter.Fill(Table);
                    OleDbCommandBuilder = new OleDbCommandBuilder(OleDbAdapter);

                    OleDbConnection.Close();
                }
                else if (DbType == 1)
                {
                    SqlConnection.Open();

                    SqlAdapter = new SqlDataAdapter(sqlCommand, SqlConnection);
                    Table = new DataTable();
                    SqlAdapter.Fill(Table);
                    SqlCommandBuilder = new SqlCommandBuilder(SqlAdapter);

                    SqlConnection.Close();
                }
                else
                {
                    SQLiteConnection.Open();

                    SQLiteAdapter = new SQLiteDataAdapter(sqlCommand, SQLiteConnection);
                    Table = new DataTable();
                    SQLiteAdapter.Fill(Table);
                    SQLiteCommandBuilder = new SQLiteCommandBuilder(SQLiteAdapter);

                    SQLiteConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());

                return null;
            }

            return Table;
        }

        public object ExecuteScalar(string sqlCommand)
        {
            object obj = null;

            try
            {
                if (DbType == 0)
                {
                    OleDbConnection.Open();

                    OleDbCommand command = new OleDbCommand(sqlCommand, OleDbConnection);

                    obj = command.ExecuteScalar();

                    OleDbConnection.Close();
                }
                else if (DbType == 1)
                {
                    SqlConnection.Open();

                    SqlCommand command = new SqlCommand(sqlCommand, SqlConnection);

                    obj = command.ExecuteScalar();

                    SqlConnection.Close();
                }
                else
                {
                    SQLiteConnection.Open();

                    SQLiteCommand command = new SQLiteCommand(sqlCommand, SQLiteConnection);

                    obj = command.ExecuteScalar();

                    SQLiteConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());

                return null;
            }

            return obj;
        }

        public int UpdateDataSet()
        {
            int ret = 0;

            if (DataSet == null)
            {
                ret = -1;
                return ret;
            }

            if (DbType == 0)
            {
                OleDbConnection.Open();

                try
                {
                    OleDbAdapter.Update(DataSet);
                }
                catch (OleDbException ex)
                {
                    ret = ex.ErrorCode;
                }

                OleDbConnection.Close();
            }
            else if (DbType == 1)
            {
                SqlConnection.Open();

                try
                {
                    SqlAdapter.Update(DataSet);
                }
                catch (SqlException ex)
                {
                    ret = ex.ErrorCode;
                }
            }
            else
            {
                SQLiteConnection.Open();

                try
                {
                    SQLiteAdapter.Update(DataSet);
                }
                catch (OleDbException ex)
                {
                    ret = ex.ErrorCode;
                }

                SQLiteConnection.Close();
            }

            return ret;
        }

        public int UpdateDataTable()
        {
            int ret = 0;

            if (Table == null)
            {
                ret = -1;
                return ret;
            }

            if (DbType == 0)
            {
                OleDbConnection.Open();

                try
                {
                    OleDbAdapter.Update(Table);
                }
                catch (OleDbException ex)
                {
                    ret = ex.ErrorCode;
                }

                OleDbConnection.Close();
            }
            else if (DbType == 1)
            {
                SqlConnection.Open();

                try
                {
                    SqlAdapter.Update(Table);
                }
                catch (SqlException ex)
                {
                    ret = ex.ErrorCode;
                }

                SqlConnection.Close();
            }
            else
            {
                SQLiteConnection.Open();

                try
                {
                    SQLiteAdapter.Update(Table);
                }
                catch (SQLiteException ex)
                {
                    ret = Convert.ToInt32(ex.ErrorCode);
                }

                SQLiteConnection.Close();
            }

            return ret;
        }
    }

}