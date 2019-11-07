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
    public partial class ApplyforChem : Form
    {
        public ApplyforChem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();


            string access = "insert into apply (申请标题,化学药品名称,申请数量,申请人,联系电话,详细介绍,申请的时间,是否同意) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "',null)";
            OleDbCommand cmd = new OleDbCommand(access, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("申请成功！");
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
