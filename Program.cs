using SHJD.UserManage.DAL;
using SHJD.UserManage.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHJD.UserManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if (File.Exists(ConstHelper.IniFile))
                {
                    ConstHelper.SqlConnectString = IniFileHelper.Read("sqlmanage", "setting", "", ConstHelper.IniFile);
                }
                Application.Run(new FormMain());

            }
            catch (Exception ex) {
                MessageBox.Show("遇到致命错误。请重新运行！\n"+ex.Message+ex.StackTrace);
            }
          
        }
    }
}
