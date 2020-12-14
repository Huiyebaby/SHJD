using MySql.Data.MySqlClient;
using SHJD.UserManage.DAL.Model;
using SHJD.UserManage.DAL.Reposity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.BLL.Impl
{
    public class UserInfoManageImpl : IUserInfoManage
    {
        private static UserReposity userReposity = new UserReposity();

        public UserInfo GetUserInfo(int Userid)
        {
            return userReposity.GetRepo<UserInfo>().Where(x => x.UserId == Userid).FirstOrDefault();
        }


        public void DeleteInfo(int id)
        {
            userReposity.DataBasesRepo().ExecuteSqlCommand("delete from UserInfo where id=? ", new object[]{ id });
        }
        public List<UserInfo> GetUserAll(string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return userReposity.GetRepo<UserInfo>().ToList();
            }
            else
            {
                return userReposity.GetRepo<UserInfo>().Where(x => UserName.Contains(UserName)).ToList();
            }
        }


        public bool Save(UserInfo info)
        {
            var result = false;
            if (info.id <1)
            {
                result = userReposity.Insert(info) > 0;
            }
            else
            {
                result = userReposity.Update(info) > 0;
            }
            return result;
        }
    }
}
