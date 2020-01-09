using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

class DbOperation
{
    private OleDbConnection Connection;
    private OleDbDataAdapter Adapter;
    private DataSet DataSet;
    private DataTable Table;
    private OleDbCommandBuilder CommandBuilder;

    public DbOperation(string connectionString)
    {
        // Sample connection string: "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Database.mdb"
        Connection = new OleDbConnection(connectionString);
    }

    public int ExecuteNonQuery(string sqlCommand)
    {
        Connection.Open();

        OleDbCommand command = new OleDbCommand(sqlCommand, Connection);
        int ret = command.ExecuteNonQuery();

        Connection.Close();

        return ret;
    }

    public DataSet ExecuteDataSet(string sqlCommand)
    {
        Connection.Open();

        Adapter = new OleDbDataAdapter(sqlCommand, Connection);
        DataSet = new DataSet();
        Adapter.Fill(DataSet);
        CommandBuilder = new OleDbCommandBuilder(Adapter);

        Connection.Close();

        return DataSet;
    }

    public DataTable ExecuteDataTable(string sqlCommand)
    {
        Connection.Open();

        Adapter = new OleDbDataAdapter(sqlCommand, Connection);
        Table = new DataTable();
        Adapter.Fill(Table);
        CommandBuilder = new OleDbCommandBuilder(Adapter);

        Connection.Close();

        return Table;
    }

    public object ExecuteScalar(string sqlCommand)
    {
        Connection.Open();

        OleDbCommand command = new OleDbCommand(sqlCommand, Connection);

        object obj;
        obj = command.ExecuteScalar();

        Connection.Close();

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

        Connection.Open();

        try
        {
            Adapter.Update(DataSet);
        }
        catch (OleDbException ex)
        {
            ret = ex.ErrorCode;
        }

        Connection.Close();

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

        Connection.Open();

        try
        {
            Adapter.Update(Table);
        }
        catch (OleDbException ex)
        {
            ret = ex.ErrorCode;
        }

        Connection.Close();

        return ret;
    }
}
