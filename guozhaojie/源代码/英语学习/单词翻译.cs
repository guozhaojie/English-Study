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

namespace 英语学习
{
    public partial class 单词翻译 : Form
    {
        public 单词翻译()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str + @"\DB\Dictionary.accdb");
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = ("select (cn) from words where en=" + "'" + textBox1.Text + "'");
            con.Open();
            string Chinese = (string)cmd.ExecuteScalar();
            cmd.Dispose();
            con.Close();
            if (Chinese == null) MessageBox.Show("单词不存在！");
            else textBox2.Text = Chinese;
        }
    }
}
