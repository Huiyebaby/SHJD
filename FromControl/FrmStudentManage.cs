using SHJD.UserManage.BLL;
using SHJD.UserManage.BLL.Impl;
using SHJD.UserManage.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHJD.UserManage.FromControl
{
    public partial class FrmStudentManage : Form
    {
        private static IStudentManage StudentManange = new StudentManageImpl();
        private Student Student =null;
        public FrmStudentManage(Student user = null)
        {
            InitializeComponent();
            Student = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox5.Text.Trim(), out int age) == false)
            {
                MessageBox.Show("年龄 必须为数字");
                return;
            }
            if (Student == null)
            {
                Student = new Student();
            }
            else {
                //编辑
            }
            //Student.UserId = userId;
            //Student.UserName = textBox2.Text.Trim();
            //Student.UserPassWord = textBox3.Text.Trim();
            //Student.IsAdmin = checkBox1.Checked;

           Student.Sno = textBox1.Text.Trim();
            Student.Sname = textBox2.Text.Trim();
            Student.Stel = textBox4.Text.Trim();
            Student.Sage = age;
            Student.Sgrade = textBox6.Text.Trim();
            Student.Ssex = radioButton1.Checked;
            try
            {
                StudentManange.Save(Student);
                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查输入内容。是否超长\n" + ex.Message);
            }           
        }

        private void FrmStudentManage_Load(object sender, EventArgs e)
        {
            if (Student!=null)
            {
                //textBox1.Text = Student.UserId.ToString();
                //textBox2.Text = Student.UserName;
                //textBox3.Text = Student.UserPassWord;
                //checkBox1.Checked = Student.IsAdmin;
                textBox1.Text = Student.Sno;
                textBox2.Text = Student.Sname;
                textBox4.Text = Student.Stel;
                textBox5.Text = Student.Sage.ToString();
                textBox6.Text = Student.Sgrade;
                radioButton1.Checked = Student.Ssex;
                radioButton2.Checked = !Student.Ssex;
            }
        }
    }
}
