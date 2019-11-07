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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
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
        public string username;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("两次密码输入不一致！");
            }
            else if (textBox1.Text == null || textBox2.Text == null)
            {
                MessageBox.Show("请输入正确信息！");
            }


            else
            {
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
                OleDbConnection conn = new OleDbConnection(connString);

                conn.Open();

                username = (Application.OpenForms["Form1"] as Form1).username1;
                string access = "Update users Set [password]='" + textBox2.Text + "' Where [username]= '" + username + "'";
                OleDbCommand cmd = new OleDbCommand(access, conn);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("修改成功！");
                this.Hide();
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            this.Dispose();
        }
    }
}
