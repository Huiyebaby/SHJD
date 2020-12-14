using SHJD.subManage.FromControl;
using SHJD.UserManage.BLL;
using SHJD.UserManage.BLL.Impl;
using SHJD.UserManage.DAL.Model;
using SHJD.UserManage.FromControl;
using SHJD.UserManage.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SHJD.UserManage
{
    public partial class FormMain : Form
    {
        private IUserInfoManage userInfoManange;

        private ISubjectManage subjectManage;

        private IStudentManage studentManage;
        public FormMain()
        {
            if (string.IsNullOrEmpty(ConstHelper.UserName))
            {
                var frmLogin = new FrmLogin();
                frmLogin.ShowDialog();
            }
            InitializeComponent();
            userInfoManange = new UserInfoManageImpl();
            subjectManage = new SubjectManageImpl();
            studentManage = new StudentManageImpl();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            if (!FilterHelper.isAdmin())
            {
                var enable = false;
                panel6.Enabled = enable;
                panel4.Enabled = enable;
                panel3.Enabled = enable;
                panel8.Enabled = enable;
            }


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[treeView1.SelectedNode.Text];
        }

     

        #region 用户管理
        /// <summary>
        /// 用户查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {

            var userAll = userInfoManange.GetUserAll(txtUserName.Text.Trim());
            if (!FilterHelper.isAdmin())
            {
                userAll.ForEach(x => x.UserPassWord = "***************");
            } 
            dataGridView3.DataSource = userAll;
        }
        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                var i = 0;
                foreach (DataGridViewRow item in dataGridView3.SelectedRows)
                {
                    var delID = item.Cells[0];
                    userInfoManange.DeleteInfo((int)delID.Value);
                    ++i;
                }
                MessageBox.Show($"删除成功,共{i}条");
            }
            catch(Exception ex) {
                MessageBox.Show("删除失败！！！！ 请联系作者 ex:"+"\n" + ex.Message +ex.StackTrace);
            }
            button12_Click(null, null);

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            var frm = new FrmUserManage();
            frm.ShowDialog();
            button12_Click(null, null);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count<1)
            {
                return;
            }
            var userInfo= userInfoManange.GetUserInfo((int)dataGridView3.SelectedRows[0].Cells[1].Value);
            var frm = new FrmUserManage(userInfo);
            frm.ShowDialog();
            button12_Click(null, null);
        }

        #endregion
        #region 课程管理
        /// <summary>
        /// 课程查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_Click(object sender, EventArgs e)
        {
            var lst = subjectManage.GetAll(textBox4.Text.Trim());
            dataGridView4.DataSource = lst;
        }
        /// <summary>
        /// 课程新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            var frm = new FrmSubjectManage();
            frm.ShowDialog();
            button16_Click(null, null);
        }
        /// <summary>
        /// 课程编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count < 1)
            {
                return;
            }
            var sub = subjectManage.GetSubject((string)dataGridView4.SelectedRows[0].Cells[2].Value);
            var frm = new FrmSubjectManage(sub);
            frm.ShowDialog();
            button16_Click(null, null);
        }
        /// <summary>
        /// 课程删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                var i = 0;
                foreach (DataGridViewRow item in dataGridView4.SelectedRows)
                {
                    var delID = item.Cells[0];
                    subjectManage.DeleteInfo((int)delID.Value);
                    ++i;
                }
                MessageBox.Show($"删除成功,共{i}条");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！！！！ 请联系作者 ex:" + "\n" + ex.Message + ex.StackTrace);
            }
            button16_Click(null, null);
        }
        #endregion

        #region 学生管理
        /// <summary>
        /// 学生查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
          var lst =  studentManage.GetAll(textBox1.Text.Trim(),textBox3.Text.Trim());
            if (!ConstHelper.IsAdmin)
            {
                lst.ForEach(x => x.Stel = "***************");
            }
            
          dataGridView1.DataSource = lst; 
        }
        /// <summary>
        /// 学生新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new FrmStudentManage();
            frm.ShowDialog();
            button1_Click(null, null);
        }
        /// <summary>
        /// 学生编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count<1)
            {
                return;
            }
            var sub = studentManage.GetInfo((string)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value);
            var frm = new FrmStudentManage(sub);
            frm.ShowDialog();
            button1_Click(null, null);
        }
        /// <summary>
        /// 学生删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var i = 0;
                foreach (DataGridViewCell item in dataGridView1.SelectedCells)
                {
                    //item.Index
                    //  var delID = item.Cells[0];
                   
                    studentManage.DeleteInfo((int)dataGridView1.Rows[item.RowIndex].Cells[0].Value);
                    ++i;
                }
                MessageBox.Show($"删除成功,共{i}条");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！！！！ 请联系作者 ex:" + "\n" + ex.Message + ex.StackTrace);
            }
            button1_Click(null, null);
        }

        private static string dataGridView1_sort = "";
        private static int dataGridView1_Sort = 0;
        /// <summary>
        ///  单击列头排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var lst = studentManage.GetAll(textBox1.Text.Trim(), textBox3.Text.Trim());
            var propName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            if (propName.Equals("sexName"))
            {
                propName = "Ssex";
            }
            PropertyInfo prop = typeof(Student).GetProperty(propName);
            if (dataGridView1_sort.Equals(propName))
            {

                if (dataGridView1_Sort == 1)
                {
                    lst = lst.OrderByDescending(x => prop.GetValue(x, null)).ToList();
                    dataGridView1_Sort = 0;
                }
                else if (dataGridView1_Sort == 0)
                {
                    dataGridView1_sort = "";
                }
            }
            else
            {
                //默认第一次都是升序
                lst = lst.OrderBy(x => prop.GetValue(x, null)).ToList();
                dataGridView1_Sort = 1;
                dataGridView1_sort = propName;
            }
            if (!ConstHelper.IsAdmin)
            {
                lst.ForEach(x => x.Stel = "***************");
            }
            dataGridView1.DataSource = lst;
            // dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex], ListSortDirection.Descending);
        }


        /// <summary>
        /// 批量修改列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                var i = 0;
                var col = dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex];
                var str =  Interaction.InputBox($"是否批量修改选中的{col.HeaderText}列", "批量修改");
                if (!string.IsNullOrEmpty(col.HeaderText))
                {
                    foreach (DataGridViewCell item in dataGridView1.SelectedCells)
                    {
                       var stu=   studentManage.GetInfo((string)dataGridView1.Rows[item.RowIndex].Cells[1].Value);
                        PropertyInfo prop = typeof(Student).GetProperty(col.DataPropertyName);
                        prop.SetValue(stu, str);
                        studentManage.Save(stu);
                        ++i;
                    }
                    MessageBox.Show($"修改成功,共{i}条");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！！！！ 请联系作者 ex:" + "\n" + ex.Message + ex.StackTrace);
            }
            button1_Click(null, null);
        }

        #endregion
        #region 成绩管理
      
        /// <summary>
        /// 成绩查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            var lst = studentManage.GetStuSubAll();
            dataGridView2.DataSource = lst;
        }
        /// <summary>
        /// 成绩新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            var frm = new FrmStuSubManage();
            frm.ShowDialog();
            button8_Click(null, null);
        }
        /// <summary>
        /// 成绩编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count < 1)
            {
                return;
            }
            var sub = studentManage.GetStuInfo((int)dataGridView2.SelectedRows[0].Cells[0].Value);
            var frm = new FrmStuSubManage(sub);
            frm.ShowDialog();
            button8_Click(null, null);

        }
        /// <summary>
        /// 成绩删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var i = 0;
                foreach (DataGridViewRow item in dataGridView2.SelectedRows)
                {
                    var delID = item.Cells[0];
                    studentManage.DeleteSubInfo((int)delID.Value);
                    ++i;
                }
                MessageBox.Show($"删除成功,共{i}条");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！！！！ 请联系作者 ex:" + "\n" + ex.Message + ex.StackTrace);
            }
            button8_Click(null, null);
        }
        #endregion
    }
}
