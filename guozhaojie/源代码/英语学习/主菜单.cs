using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 英语学习
{
    public partial class 主菜单 : Form
    {
        public 主菜单()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            单词翻译 a = new 单词翻译();
            a.MdiParent = this;
            a.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            单词记忆 b = new 单词记忆();
            b.MdiParent = this;
            b.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            备忘录 c = new 备忘录();
            c.MdiParent = this;
            c.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            生词本 d = new 生词本();
            d.MdiParent = this;
            d.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            词汇测试 test = new 词汇测试();
            test.MdiParent = this;
            test.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            button6.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
        }
    }
}


   

 
