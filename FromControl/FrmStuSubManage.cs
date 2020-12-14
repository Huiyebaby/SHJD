using SHJD.UserManage.BLL;
using SHJD.UserManage.BLL.Impl;
using SHJD.UserManage.DAL.DTO;
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
    public partial class FrmStuSubManage : Form
    {
        private static IStudentManage StudentManange = new StudentManageImpl();
        private static ISubjectManage subjectManage = new SubjectManageImpl();
        private StuSubInfo Student =null;
        public FrmStuSubManage(StuSubInfo user = null)
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
            if (Decimal.TryParse(textBox5.Text.Trim(),out decimal Achievement)==false)
            {
                MessageBox.Show("成绩 必须为数字");
                return;
            }
            var Studentinfo = StudentManange.GetInfo(textBox1.Text.Trim());
            if (Studentinfo == null)
            {
                MessageBox.Show("查无此人");
                return;
            }
            StuSub info;
            if (Student == null)
            {
                info = new StuSub();
            }
            else {
                //编辑
                info= StudentManange.GetStuSubInfo(Student.id);
            }
            info.Sno= textBox1.Text ;
            info.Batch= textBox4.Text ;
            info.Achievement= Achievement;
            info.Code = comboBox1.SelectedValue.ToString();
            try
            {
                StudentManange.SaveStuSub(info);
                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查输入内容。是否超长\n" + ex.Message);
            }           
        }

        private void FrmStuSubManage_Load(object sender, EventArgs e)
        {
            var lstSubject = subjectManage.GetAll("");
            comboBox1.DisplayMember = "SubjectName";
            comboBox1.ValueMember = "SubjectCode";
            comboBox1.DataSource = lstSubject;
            if (Student!=null)
            {
                textBox1.Text = Student.Sno;
                textBox2.Text = Student.Sname;
                textBox3.Text = Student.Sgrade;
                textBox4.Text = Student.Batch;
                textBox5.Text = Student.Achievement.ToString();
                comboBox1.SelectedText = Student.SubjectName;
                comboBox1.SelectedValue = Student.Code;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //查询
            if (e.KeyChar==(char)ConsoleKey.Enter)
            {
                var info = StudentManange.GetInfo(textBox1.Text.Trim());
                if (info != null)
                {
                    textBox2.Text = info.Sname;
                    textBox3.Text = info.Sgrade;
                }
                else
                {
                    MessageBox.Show("查无此人");
                    return;
                }
            }
        }
    }
}
