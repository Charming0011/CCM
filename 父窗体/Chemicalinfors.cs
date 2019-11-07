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
    public partial class Chemicalinfors : Form
    {
        public Chemicalinfors()
        {
            InitializeComponent();
        }

        private void Chemicalinfors_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string strFilePath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";

            string sql = "select * from medicine";
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
                    dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    textBox9.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    textBox10.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    pictureBox1.ImageLocation = @"./Images/" + dataGridView1.SelectedRows[0].Cells[11].Value.ToString();

                    textBox11.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    textBox12.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    textBox13.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                    textBox14.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                    dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                    textBox16.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
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
            string access = "Update medicine Set 化学名称='" + textBox1.Text + "',型号='" + textBox2.Text + "',规格='" + textBox3.Text + "',学科属性='" + textBox4.Text + "',类别='" + textBox5.Text + "',出厂日期='" + dateTimePicker1.Text + "',存放地点='" + textBox7.Text + "',存放单位='" + textBox8.Text + "',主要功能='" + textBox9.Text + "',数量='" + textBox10.Text + "',技术指标='" + textBox11.Text + "',认证机构='" + textBox12.Text + "',存放条件='" + textBox13.Text + "',管理人='" + textBox14.Text + "',添加的时间='" + dateTimePicker2.Text + "',备注='" + textBox16.Text + "'  where [ID]=" + str + "";

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

            string sql = "select * from medicine";
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
