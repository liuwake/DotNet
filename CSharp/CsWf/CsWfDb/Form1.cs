using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Db
//using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CsWfDb
{
    public partial class Form1 : Form
    {

        string oledbConnDefaultStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "c:\\WK\\AccessDemo.mdb;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
            + "c:\\WK\\UVSS.mdb;User Id=admin;Password=;"; 
            //创建SqlConnection的实例
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(connStr);
                //打开数据库连接
                conn.Open();
                MessageBox.Show("数据库连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            //string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "c:\\WK\\UVSS.mdb;User Id=admin;Password=;";
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "c:\\WK\\AccessDemo.mdb;";

            //创建SqlConnection的实例
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    //打开数据库连接
                    conn.Open();
                    MessageBox.Show("数据库连接成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = "Data source=.;Initial Catalog=test;User ID=sa;Password=pwdpwd";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                MessageBox.Show("数据库连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
              //编写数据库连接串
            //string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "c:\\WK\\UVSS.mdb;User Id=admin;Password=;";
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "c:\\WK\\AccessDemo.mdb;";

            //创建SqlConnection的实例
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    //打开数据库连接
                    conn.Open();
                    MessageBox.Show("数据库连接成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = oledbConnDefaultStr;
            //创建 SqlConnection的实例
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "insert into userinfo(name,pwd) values('{0}','{1}')";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text, textBox2.Text);
                //创建SqlCommand对象
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                //执行SQL语句
                int returnvalue = cmd.ExecuteNonQuery();
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("注册成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = oledbConnDefaultStr;
            //创建 SqlConnection的实例
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "insert into Scan(HospitalNo, BedNo,Name, Tagcode, Sign) values('{0}','{1}','{2}','{3}','{4}')";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                //创建SqlCommand对象
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                //执行SQL语句
                int returnvalue = cmd.ExecuteNonQuery();
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("注册成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
    }
}
