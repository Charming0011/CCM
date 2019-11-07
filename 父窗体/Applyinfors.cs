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
    public partial class Applyinfors : Form
    {
        public Applyinfors()
        {
            InitializeComponent();
        }

        private void Applyinfors_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string strFilePath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";

            string sql = "select * from apply";
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

        private void 同意ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);

            conn.Open();
            string access = "Update apply Set [是否同意]='同意' Where [ID]= " + str + "";
            OleDbCommand cmd = new OleDbCommand(access, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("操作成功！");
        }
        public int str;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string str1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                str = int.Parse(str1);
            }
        }

        private void 不同意ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\LiuQi\Desktop\Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);

            conn.Open();
            string access = "Update apply Set [是否同意]='不同意' Where [ID]= " + str + "";
            OleDbCommand cmd = new OleDbCommand(access, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("操作成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
