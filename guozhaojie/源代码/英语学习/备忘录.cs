using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 英语学习
{
    public partial class 备忘录 : Form
    {
        byte[] byData = new byte[100];
        char[] charData = new char[1000];
        public 备忘录()
        {
            InitializeComponent();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            str = this.richTextBox1.Text;
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\备忘录.txt", false);
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            MessageBox.Show("保存成功！");
        }

        private void 备忘录_Load_1(object sender, EventArgs e)
        {
            string str;
            StreamReader sr = new StreamReader(Application.StartupPath + "\\备忘录.txt", false);
            str = sr.ReadToEnd().ToString();
            sr.Close();
            this.richTextBox1.Text = str;
        }
    }
}
