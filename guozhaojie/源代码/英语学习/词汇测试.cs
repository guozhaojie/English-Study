using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 英语学习
{
    public partial class 词汇测试 : Form
    {
        public 词汇测试()
        {
            InitializeComponent();
        }
        int option1 = -1, option2 = -1, option3 = -1, option4 = -1;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false) option1 = -1;
            else option1 = 1;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false) option2 = -1;
            else option2 = 1;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false) option3= -1;
            else option3 = 1;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false) option4 = -1;
            else option4 = 1;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        int id;
        int trueAnswer=0;
        int allNumber=0, trueNumber=0;
        private int getId()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            id = rand.Next(1, 78511);
            return id;
        }
        private int getAnswer()
        {
            int answer;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            answer = rand.Next(1, 4);
            return answer ;
        }
        string English, Chinese;

     
        string[] fChinese = new string[3];
        private int getWord(int id)
        {
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con= new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str+@"\DB\Dictionary.accdb" );
            OleDbCommand cmd1 = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();
            con.Open();
            cmd1.CommandText = ("select (en) from words where id=" + id);
            cmd2.CommandText = ("select (cn) from words where id=" + id);
            English = (string)cmd1.ExecuteScalar();
            Chinese = (string)cmd2.ExecuteScalar();
            cmd1.Dispose();
            cmd2.Dispose();
            con.Close();
            return 0;
        }

  
        private int getfCn(int id,int fNO)
        {
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + str + @"\DB\Dictionary.accdb");
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = ("select (cn) from words where id=" + id);
            con.Open();
            fChinese[fNO] = (string)cmd.ExecuteScalar();
            cmd.Dispose();
            con.Close();
            return 0;
        }

        int flag = 1;
        private void check()
        {
            if (option1 + option2 + option3 + option4 == -4)
            {
                MessageBox.Show("未选择选项！");
                flag= -1;
            }
            else if (option1 + option2 + option3 + option4 > -2)
            {
                MessageBox.Show("选择了多个选项！");
                flag= - 1;
            }
            else if (trueAnswer == 0)
            {
                MessageBox.Show("请先开始测试！");
                flag = -1;
            }
            else
            {
                if (trueAnswer == 1)
                {
                    if (option1 == 1)
                    {
                        allNumber++;
                        trueNumber++;
                        MessageBox.Show("回答正确！");
                    }
                    else
                    {
                        allNumber++;
                        MessageBox.Show("回答错误！正确答案为："+Chinese);
                    }
                }
                else if (trueAnswer == 2)
                {
                    if (option2 == 1)
                    {
                        allNumber++;
                        trueNumber++;
                        MessageBox.Show("回答正确！");
                    }
                    else
                    {
                        allNumber++;
                        MessageBox.Show("回答错误！正确答案为：" + Chinese);
                    }
                }
                else if (trueAnswer == 3)
                {
                    if (option3 == 1)
                    {
                        allNumber++;
                        trueNumber++;
                        MessageBox.Show("回答正确！");
                    }
                    else
                    {
                        allNumber++;
                        MessageBox.Show("回答错误！正确答案为：" + Chinese);
                    }
                }
                else
                {
                    if (option4 == 1)
                    {
                        allNumber++;
                        trueNumber++;
                        MessageBox.Show("回答正确！");
                    }
                    else
                    {
                        allNumber++;
                        MessageBox.Show("回答错误！正确答案为：" + Chinese);
                    }
                }
                flag = 0;
            }
        }
        private void question()
        {
            getWord(getId());
            getfCn(getId(), 0);
            getfCn(getId(), 1);
            getfCn(getId(), 2);
            trueAnswer = getAnswer();
            if (trueAnswer == 1)
            {
                textBox1.Text = Chinese;
                textBox2.Text = fChinese[0];
                textBox3.Text = fChinese[1];
                textBox4.Text = fChinese[2];
                textBox5.Text = English;
            }
            else if (trueAnswer == 2)
            {
                textBox2.Text = Chinese;
                textBox1.Text = fChinese[0];
                textBox3.Text = fChinese[1];
                textBox4.Text = fChinese[2];
                textBox5.Text = English;
            }
            else if (trueAnswer == 3)
            {
                textBox3.Text = Chinese;
                textBox1.Text = fChinese[0];
                textBox2.Text = fChinese[1];
                textBox4.Text = fChinese[2];
                textBox5.Text = English;
            }
            else
            {
                textBox4.Text = Chinese;
                textBox1.Text = fChinese[0];
                textBox2.Text = fChinese[1];
                textBox3.Text = fChinese[2];
                textBox5.Text = English;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            question();
            button3.Visible = false;
            button1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            check();
            if(flag ==0) question();
            checkBox1.Checked = false ;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(flag ==0) MessageBox.Show("测试题数：" + allNumber + "\n" + "正确题数：" + trueNumber);
        }
    }
}
