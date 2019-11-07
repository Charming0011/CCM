using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 父窗体
{
    public partial class AddChemical : Form
    {
        public AddChemical()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //创建一个对话框对象
            OpenFileDialog ofd = new OpenFileDialog();
            //为对话框设置标题
            ofd.Title = "请选择上传的图片";
            //设置筛选的图片格式
            ofd.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff";
            //设置是否允许多选
            ofd.Multiselect = false;
            //如果你点了“确定”按钮
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //获得文件的完整路径（包括名字后后缀）
                string filePath = ofd.FileName;

                //找到文件名比如“1.jpg”前面的那个“\”的位置
                int position = filePath.LastIndexOf("\\");
                //从完整路径中截取出来文件名“1.jpg”
                string s = DateTime.Now.ToFileTime().ToString();
                string fileName = s+filePath.Substring(position + 1);
                //读取选择的文件，返回一个流
                using (Stream stream = ofd.OpenFile())
                {
                    //创建一个流，用来写入得到的文件流（注意：创建一个名为“Images”的文件夹，如果是用相对路径，必须在这个程序的Degug目录下创建
                    //如果是绝对路径，放在那里都行，我用的是相对路径）
                    using (FileStream fs = new FileStream(@"./Images/" + fileName, FileMode.Append))
                    {
                        //将得到的文件流复制到写入流中
                        stream.CopyTo(fs);
                        //将写入流中的数据写入到文件中
                        fs.Flush();
                    }
                    //PictrueBOx 显示该图片，此时这个图片已经被复制了一份在Images文件夹下，就相当于上传
                    //至于上传到别的地方你再更改思路就行，这里只是演示过程
                    pbShow.ImageLocation = @"./Images/" + fileName;
                    
                }
                this.textBox17.Text = fileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "")
                    {
                        MessageBox.Show("请输入信息");
                        return;
                    }
                }
            }
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            string access = "insert into medicine (化学名称,型号,规格,学科属性,类别,出厂日期,存放地点,存放单位,主要功能,数量,技术指标,认证机构,存放条件,管理人,添加的时间,备注,照片)" +
                " values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + dateTimePicker2.Text + "','" + textBox16.Text + "','" + textBox17.Text + "')";
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
