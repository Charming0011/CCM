using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 父窗体
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        private void 功能选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.MdiParent = this;
            changePassword.Show();
        }

        private void 添加账户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addinformation addinformation = new Addinformation();
            addinformation.MdiParent = this;
            addinformation.Show();
        }

        private void 所有用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uerinfomation uerinfomation = new Uerinfomation();
            uerinfomation.MdiParent = this;
            uerinfomation.Show();
        }

        private void 添加化学药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChemical add = new AddChemical();
            add.MdiParent = this;
            add.Show();
        }

        private void 化学药品信息查看修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chemicalinfors chemicalinfors = new Chemicalinfors();
            chemicalinfors.MdiParent = this;
            chemicalinfors.Show();
        }

        private void 申请化学药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyforChem applyforChem = new ApplyforChem();
            applyforChem.MdiParent = this;
            applyforChem.Show();
        }

        private void 化学药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applyinfors applyinfors = new Applyinfors();
            applyinfors.MdiParent = this;
            applyinfors.Show();
        }


        private void 添加新闻公告ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Addnews addnews = new Addnews();
            addnews.MdiParent = this;
            addnews.Show();
        }

        private void 新闻公告查看修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewsDelete news = new NewsDelete();
            news.MdiParent = this;
            news.Show();
        }

        private void 修改新闻公告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewsUpdate newsUpdate = new NewsUpdate();
            newsUpdate.MdiParent = this;
            newsUpdate.Show();
        }
    }
}
