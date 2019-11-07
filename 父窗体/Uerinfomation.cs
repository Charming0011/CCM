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
    public partial class Uerinfomation : Form
    {
        public Uerinfomation()
        {
            InitializeComponent();
        }
        private Size beforeResizeSize = Size.Empty;

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            beforeResizeSize = this.Size;
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            //窗口resize之后的大小
            Size endResizeSize = this.Size;
            //获得变化比例
            float percentWidth = (float)endResizeSize.Width / beforeResizeSize.Width;
            float percentHeight = (float)endResizeSize.Height / beforeResizeSize.Height;
            foreach (Control control in this.Controls)
            {
                if (control is DataGridView)
                    continue;
                //按比例改变控件大小
                control.Width = (int)(control.Width * percentWidth);
                control.Height = (int)(control.Height * percentHeight);
                //为了不使控件之间覆盖 位置也要按比例变化
                control.Left = (int)(control.Left * percentWidth);
                control.Top = (int)(control.Top * percentHeight);
            }
        }

        private void Uerinfomation_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string strFilePath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";

            string sql = "select * from infors";
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
                    textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    string str1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    str = int.Parse(str1);

                }
            }
            catch
            {
                MessageBox.Show("请选择正确行！");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            string access = "Update infors Set [userid]='" + textBox1.Text + "',location='" + textBox2.Text + "',tel='" + textBox3.Text + "',workid='" + textBox4.Text + "',others='" + textBox5.Text + "'  where [ID]=" + str + "";

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

            string sql = "select * from infors";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
