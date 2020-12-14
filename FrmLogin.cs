using SHJD.UserManage.BLL;
using SHJD.UserManage.BLL.Impl;
using SHJD.UserManage.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHJD.UserManage
{
    public partial class FrmLogin : Form
    {
        private IUserInfoManage userInfoManage;
        public FrmLogin()
        {
            InitializeComponent();
            userInfoManage = new UserInfoManageImpl();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConstHelper.SqlConnectString))
            {
                MessageBox.Show("请先在设置里配置连接字符串，这里数据中心统一采用Mysql ");
                return;
            }
            if (String.IsNullOrEmpty(txtID.Text)|| String.IsNullOrEmpty(txtPwd.Text) || !Int32.TryParse(txtID.Text.ToString(),out int id))
            {
                MessageBox.Show("请填写登录账号 和密码 ");
                return;
            }
            var user = userInfoManage.GetUserInfo(id);
            if (user!=null && user.IsAdmin==cheAdmin.Checked && user.UserPassWord== txtPwd.Text)
            {
                ConstHelper.UserId = user.id;
                ConstHelper.UserName = user.UserName;
                ConstHelper.IsAdmin = user.IsAdmin;
                //MessageBox.Show("登录成功... 跳转中... ");
                var frm = new FormMessage("登录成功... 跳转中... ", 1);
                frm.ShowDialog();
                this.Close();
                return;
            }
            MessageBox.Show("账号密码错误");
            return;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            return;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmSetting();
            frm.ShowDialog();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (string.IsNullOrEmpty(ConstHelper.UserName))
            {
                Application.Exit();
                return;
            }
        }

        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnLogin_Click(null,null);
        }
    }
}
