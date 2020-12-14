using SHJD.UserManage.DAL;
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
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var connection = "";
            if (radioButton2.Checked)
            {
                if (string.IsNullOrEmpty(textBox4.Text)|| string.IsNullOrEmpty(textBox5.Text)|| string.IsNullOrEmpty(textBox6.Text)|| string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("必填字段不能为空");
                    return;
                }
                connection = string.Format("Server={0};Database={1}; Uid={3};Pwd={4};port={2};Character Set=utf8;", textBox2.Text.Trim(),textBox6.Text.Trim(), textBox3.Text.Trim()==""?"3306": textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim());

            }
            else {
                connection = textBox1.Text;
            }
            ConstHelper.SqlConnectString = connection;
            try
            {
                var baseEntity = new BaseReposity();
                var flag =baseEntity.Exist();
                if (!flag)
                {
                    MessageBox.Show("连接字符串配置有误，数据库连接不上，请检查是否配置服务器上有test 数据库  " );
                    return;
                }
            }
            catch (Exception ex)
            {
                ConstHelper.SqlConnectString = "";
                MessageBox.Show("连接字符串配置有误，数据库连接不上，请检查是否配置服务器上有test 数据库  异常信息：" + ex.Message);
                return;
            }
            IniFileHelper.Write("sqlmanage", "setting", connection, ConstHelper.IniFile);
            this.Close();
        }

        private void RadioChanged(object sender, EventArgs e)
        {
            var radioCheckStatus = radioButton2.Checked;
            panel1.Enabled = radioCheckStatus;
            label1.Enabled = !radioCheckStatus;
            textBox1.Enabled = !radioCheckStatus;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkedStatus = checkBox1.Checked;
            foreach (Control item in groupBox2.Controls)
            {
                if (item.Name==checkBox1.Name)
                {
                    continue;
                }
                item.Enabled = checkedStatus;
            }
            
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            radioButton2.CheckedChanged += RadioChanged;
            radioButton1.CheckedChanged += RadioChanged;

            try
            {
                var connStr = IniFileHelper.Read("sqlmanage", "setting", "", ConstHelper.IniFile);
                if (!string.IsNullOrEmpty(connStr))
                {
                    textBox1.Text = connStr;
                    radioButton1.Checked = true;
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
