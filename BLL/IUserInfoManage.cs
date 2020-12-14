using SHJD.UserManage.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.BLL
{
    public interface IUserInfoManage
    {

        UserInfo GetUserInfo(int id);

        void DeleteInfo(int id);
        List<UserInfo> GetUserAll(string UserName);
        bool Save(UserInfo info);
    }
}
