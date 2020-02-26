using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SQLite;

namespace WcfServiceDb2
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
        //连接数据库
        SQLiteConnection strCon = new SQLiteConnection("Data Source=C:\\WK\\Db\\Used.sqlite;Version=3");
        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns></returns>
        public void openSql()
        {
            strCon.Open();
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <returns></returns>
        public void closeSql()
        {
            strCon.Close();
        }

        /// <summary>
        /// 查询表TEST1中的数据
        /// </summary>
        /// <returns></returns>
        public DataSet querySql()
        {
            try
            {
                openSql();
                string strSql = "SELECT * FROM Used";
                DataSet ds = new DataSet();
                SQLiteDataAdapter s = new SQLiteDataAdapter(strSql, strCon);
                s.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeSql();
            }

        }
        public DataSet dbNew()
        {
            try
            {
                openSql();
                string strSql = "select * from Used WHERE DbId ORDER BY DbId DESC LIMIT 1";
                DataSet ds = new DataSet();
                SQLiteDataAdapter s = new SQLiteDataAdapter(strSql, strCon);
                s.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeSql();
            }

        }
    }
}
