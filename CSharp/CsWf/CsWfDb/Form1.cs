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
using System.Data.SQLite;

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
            // TODO: 这行代码将数据加载到表“accessDemoDataSet.Scan”中。您可以根据需要移动或删除它。
            //this.scanTableAdapter.Fill(this.accessDemoDataSet.Scan);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            //string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "c:\\WK\\UVSS.mdb;User Id=admin;Password=;";
            string connStr = "Data Source = c:\\WK\\Demo.sqlite; Version = 3";
           
            //创建SqlConnection的实例
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connStr))
                {
                    //打开数据库连接
                    conn.Open();
                    {
                        //查询语句
                        string sqlCommandString = "select * from Scan";
                        //利用 Adapter 转换结果到 datagrid
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCommandString, conn);  
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        DataView dv = ds.Tables[0].DefaultView;

                        dataGridView1.DataSource = dv;
                    }
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

        private void button7_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = oledbConnDefaultStr;
            //创建SQLConnection的实例
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "Select count(*) from Scan where HospitalNo='{0}'";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text);
                //创建SqlCommand对象
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                //执行SQL语句
                int returnvalue = (int)cmd.ExecuteScalar();
                //判断SQL语句是否执行成功
                if (returnvalue != 0)
                {
                    MessageBox.Show("查询存在！");
                }
                else
                {
                    MessageBox.Show("查询不存在！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
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

        private void button8_Click(object sender, EventArgs e)
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
                //判断用户名是否重复
                {
                    string checkHoIdSql = "select count(*) from Scan where HospitalNo='{0}'";
                    checkHoIdSql = string.Format(checkHoIdSql, textBox1.Text);
                    //创建SqlCommand对象
                    OleDbCommand cmdCheckHoId = new OleDbCommand(checkHoIdSql, conn);
                    //执行SQL语句
                    int isRepeatName = (int)cmdCheckHoId.ExecuteScalar();
                    if (isRepeatName != 0)
                    {
                        //用户名重复，则不执行注册操作
                        MessageBox.Show("住院号已存在！");
                        return;
                    }
                }
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                //创建SqlCommand对象
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                //执行SQL语句
                int returnvalue = cmd.ExecuteNonQuery();
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("扫描添加成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("扫描添加失败！" + ex.Message);
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

        private void button9_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = oledbConnDefaultStr;
            //创建 SqlConnection的实例
            OleDbConnection conn = null;
            //定义SqlDataReader类的对象
            OleDbDataReader dr = null;
            try
            {
                conn = new OleDbConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "select HospitalNo,Name from Scan where HospitalNo='{0}'";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text);
                //创建SqlCommand对象
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                //执行Sql语句
                dr = cmd.ExecuteReader();
                //判断SQL语句是否执行成功
                if (dr.Read())
                {
                    //读取指定用户名对应的用户编号和密码
                    string msg = "HoId：" + dr[0] + " Name：" + dr[1];
                    //将msg的值显示在标签上
                    label7.Text = msg;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
            }
            finally
            {
                if (dr != null)
                {
                    //判断dr不为空，关闭OleDbDataReader对象
                    dr.Close();
                }
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void scanBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
