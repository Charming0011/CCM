using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 父窗体
{
    public partial class NewsUpdate : Form
    {
        public NewsUpdate()
        {
            InitializeComponent();
        }

        private void NewsUpdate_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string strFilePath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";

            string sql = "select * from news";
            //声明一个数据连接
            System.Data.OleDb.OleDbConnection con = new OleDbConnection(strFilePath);
            System.Data.OleDb.OleDbDataAdapter da = new OleDbDataAdapter(sql, con);

            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    dataGridView1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                da.Dispose();
            }
        }

        public int str;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    string str1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    str = int.Parse(str1);
                }
            }
            catch
            {
                MessageBox.Show("请选择正确行！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            string access = "Update news Set 公告标题='" + textBox1.Text + "',公告作者='" + textBox2.Text + "',公告内容='" + textBox4.Text + "',公告时间='" + dateTimePicker1.Text + "'  where [newsid]=" + str + "";

            DialogResult dialog = MessageBox.Show("您确定修改所选行的内容吗？", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                conn.Close();
                return;

            }
            OleDbCommand cmd = new OleDbCommand(access, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("修改成功！");
            string strFilePath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";

            string sql = "select * from news";
            //声明一个数据连接
            System.Data.OleDb.OleDbConnection con = new OleDbConnection(strFilePath);
            System.Data.OleDb.OleDbDataAdapter da = new OleDbDataAdapter(sql, con);

            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    dataGridView1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                da.Dispose();
            }
        }

        
    }
}
