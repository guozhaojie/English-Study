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
    public partial class 生词本 : Form
    {
        public 生词本()
        {
            InitializeComponent();
        }
        string text=null;
        private void getWord(int id)
        {
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str + @"\DB\Dictionary.accdb");
            OleDbCommand cmd1 = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();
            con.Open();
            cmd1.CommandText = ("select (en) from new where id=" + id);
            cmd2.CommandText = ("select (cn) from new where id=" + id);
            string English = (string)cmd1.ExecuteScalar();
            string Chinese = (string)cmd2.ExecuteScalar();
            cmd1.Dispose();
            cmd2.Dispose();
            con.Close();
            text =text+"编号:"+(id-1)+"    "+"单词：" + English + "    "+"释义：" + Chinese+"\n";
        }

        private void 生词本_Load(object sender, EventArgs e)
        {
            int i,nid;
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str + @"\DB\Dictionary.accdb");
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = ("select MAX(id) from new");
            nid = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            con.Close();
            for (i = 2; i <= nid; i++) getWord(i);
            this.richTextBox1.Text = text;
        }
    }
}
