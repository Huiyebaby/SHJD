
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

namespace SHJD.subManage.FromControl
{
    public partial class FrmSubjectManage : Form
    {
        private static ISubjectManage SubjectManange = new SubjectManageImpl();
        private Subject _subject =null;
        public FrmSubjectManage(Subject sub = null)
        {
            InitializeComponent();
            _subject = sub;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tempSubInfo = SubjectManange.GetSubject(textBox2.Text.Trim());
            if (_subject == null)
            {
                if (tempSubInfo!=null)
                {
                    //重复代码；
                    MessageBox.Show("课程编码重复");
                    return;
                }
                _subject = new Subject();
            }
            else {
                if (tempSubInfo.id!=_subject.id)
                {
                    MessageBox.Show("课程编码重复");
                    return;
                }
                //编辑
            }
            _subject.SubjectName = textBox1.Text.Trim();
            _subject.SubjectCode = textBox2.Text.Trim();
            try
            {
                SubjectManange.Save(_subject);
                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查输入内容。是否超长\n" + ex.Message);
            }           
        }

        private void FrmSubjectManage_Load(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                textBox1.Text = _subject.SubjectName;
                textBox2.Text = _subject.SubjectCode;
            }
        }
    }
}
