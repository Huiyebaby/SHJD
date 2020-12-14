using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.DAL.Model
{
    [Table("UserInfo")]
    public class UserInfo
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }

        public bool IsAdmin { get; set; }
    }
}
