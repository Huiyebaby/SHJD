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
    public partial class FrmUserManage : Form
    {
        private static IUserInfoManage userInfoManange = new UserInfoManageImpl();
        private UserInfo userInfo =null;
        public FrmUserManage(UserInfo user=null)
        {
            InitializeComponent();
            userInfo = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text.Trim(),out int userId)==false)
            {
                MessageBox.Show("用户ID 必须为数字");
                return;
            }
            if (userInfo == null)
            {
                userInfo = new UserInfo();
            }
            else {
                //编辑
            }
            userInfo.UserId = userId;
            userInfo.UserName = textBox2.Text.Trim();
            userInfo.UserPassWord = textBox3.Text.Trim();
            userInfo.IsAdmin = checkBox1.Checked;
            try
            {
                userInfoManange.Save(userInfo);
                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查输入内容。是否超长\n" + ex.Message);
            }           
        }

        private void FrmUserManage_Load(object sender, EventArgs e)
        {
            if (userInfo!=null)
            {
                textBox1.Text = userInfo.UserId.ToString();
                textBox2.Text = userInfo.UserName;
                textBox3.Text = userInfo.UserPassWord;
                checkBox1.Checked = userInfo.IsAdmin;
            }
        }
    }
}
