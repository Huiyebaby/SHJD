using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.Helper
{
    public static class ConstHelper
    {
        public static string IniFile { get { return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"SHJD_UserNanage.INI"); } private set { } }


        public static string LogFile { get { return DateTime.Now.ToString("yyyyMMdd")+".log"; } private set { } }
        public static string SqlConnectString { get; set; }
        public static int UserId { get; set; } = 0;
        public static string UserName { get; set; } 
        public static bool IsAdmin { get; set; }= false;
    }
}
