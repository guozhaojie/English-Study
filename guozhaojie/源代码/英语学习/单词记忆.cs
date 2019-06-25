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
    public partial class 单词记忆 : Form
    {
        public 单词记忆()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        int id = 1, flag1 = -1, flag2 = 1, NO = 0, save = 0;
        int[] old_id=new int[1000];
        int nid=1;

        private int getId()
        {
            Random rand = new Random();
            id = rand.Next(1, 78511);
            return id;
        }
        private int getWord(int id)
        {
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str + @"\DB\Dictionary.accdb");
            OleDbCommand cmd1 = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();
            con.Open();
            cmd1.CommandText = ("select (en) from words where id=" + id);
            cmd2.CommandText = ("select (cn) from words where id=" + id);
            string English = (string)cmd1.ExecuteScalar();
            string Chinese = (string)cmd2.ExecuteScalar();
            cmd1.Dispose();
            cmd2.Dispose();
            con.Close();
            textBox1.Text = English;
            textBox2.Text = Chinese;
            return 0;     
        }
        private void 单词记忆_Load(object sender, EventArgs e)
        {
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str + @"\DB\Dictionary.accdb");
            OleDbCommand cmd1 = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();
            con.Open();
            cmd1.CommandText = ("select max(NO) from savedata");
            save = Convert.ToInt32(cmd1.ExecuteScalar());
            cmd2.CommandText = ("select id from savedata where NO="+save);
            id = Convert.ToInt32(cmd2.ExecuteScalar());
            cmd1.Dispose();
            cmd2.Dispose();
            con.Close();
            getWord(id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save++;
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str + @"\DB\Dictionary.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = ("insert into [savedata]([NO],[id])values(" + save + "," + id + ")");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();                 
            MessageBox.Show("保存成功！");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            flag1 = -flag1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag2 == -1)
            {
                if (NO != 0)
                {
                    NO--;
                    getWord(old_id[NO]);
                }
            }
            else
            {
                if (NO != 0)
                {
                    NO-=2;
                    getWord(old_id[NO]);
                }
            }
            flag2 = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str1 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str1 + @"\DB\Dictionary.accdb");
            con1.Open();
            OleDbCommand cmd1 = con1.CreateCommand();
            cmd1.CommandText = ("select MAX(id) from new");
            string load3 = string.Format("select MAX(id) from new");
            nid = (int)cmd1.ExecuteScalar();
            cmd1.Dispose();
            con1.Close();
            nid++;
            string str2 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str2 + @"\DB\Dictionary.accdb");
            OleDbCommand cmd2 = con2.CreateCommand();
            cmd2.CommandText = ("insert into new(id,en,cn)values("+nid+ ",'" + textBox1.Text.Trim().ToString() + "',"+ "'" + textBox2.Text.Trim().ToString() + "')");
            con2.Open();
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            con2.Close();
            MessageBox.Show("收藏成功！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag2 == -1)
            {
                if (old_id[NO] == 0)
                {
                    if (flag1 == -1)
                    {
                        NO++;
                        id++;
                        getWord(id);
                        old_id[NO] = id;
                        NO ++;
                    }
                    else
                    {
                        NO++;
                        id = getId();
                        getWord(id);
                        old_id[NO] = id;
                        NO ++;
                    }
                }
                else
                {
                    NO++;
                    getWord(old_id[NO]);
                    NO ++;
                }
            }
            else
            {
                if (old_id[NO] == 0)
                {
                    if (flag1 == -1)
                    {
                        id++;
                        getWord(id);
                        old_id[NO] = id;
                        NO ++;
                    }
                    else
                    {
                        id = getId();
                        getWord(id);
                        old_id[NO] = id;
                        NO ++;
                    }
                }
                else
                {
                    getWord(old_id[NO]);
                    NO ++;
                }
            } 
            flag2 = 1;
        }
    }
}
