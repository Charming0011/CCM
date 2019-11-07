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
    public partial class Addnews : Form
    {
        public Addnews()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            string access = "insert into news (公告标题,公告作者,公告内容,公告时间) values('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "')";
            OleDbCommand cmd = new OleDbCommand(access, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加成功！");
            DialogResult dialog = MessageBox.Show("是否返回主界面？", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {

               
                this.Hide();
                
                this.Dispose();

            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
        }

        
    }
}
