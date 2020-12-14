using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.Helper
{
    public class FilterHelper
    {
        public static bool isAdmin() {
            return ConstHelper.IsAdmin;
        }
    }
}
