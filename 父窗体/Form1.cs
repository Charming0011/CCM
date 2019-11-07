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
    public partial class Form1 : Form
    {
        public Form1()
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

        private bool pdyj()

        {
            if (username.Text == "")
                return false;
            if (password.Text == "")
                return false;
            return true;

        }
        public string username1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!pdyj())
            {
                label4.Text = "请输入正确信息！";
                return;
            }

            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();


            string access = "select username,password from users where username='" + this.username.Text + "'and password='" + this.password.Text + "'";

            OleDbCommand cmd = new OleDbCommand(access, conn);
            OleDbDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {


                conn.Close();
                
                Form2 f2 = new Form2();
                username1 = this.username.Text;
                this.Hide();
                f2.ShowDialog();
                this.Dispose();

            }
            else
            {
                label4.Text ="账号密码错误！" ;
            }
        }
    }
}
