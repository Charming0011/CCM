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
    public partial class NewsDelete : Form
    {
        public NewsDelete()
        {
            InitializeComponent();
        }

        private void NewsDelete_Load(object sender, EventArgs e)
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFilePath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            string str1 = dataGridView1.SelectedRows[0].Cells["newsid"].Value.ToString();
            int str = int.Parse(str1);
            string access = "Delete from news where newsid=" + str + "";
            OleDbConnection conn = new OleDbConnection(strFilePath);
            conn.Open();
            DialogResult dialog = MessageBox.Show("您确定删除所选行的内容吗？", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                conn.Close();
                return;

            }


            OleDbCommand cmd = new OleDbCommand(access, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                DataRowView drv = this.dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                drv.Delete();
            }

            MessageBox.Show("删除成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
