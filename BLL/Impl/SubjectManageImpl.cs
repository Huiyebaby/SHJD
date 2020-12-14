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
    public class SubjectManageImpl : ISubjectManage
    {
        private static UserReposity userReposity = new UserReposity();

        public Subject GetSubject(string SubjectCode)
        {
            return userReposity.GetRepo<Subject>().Where(x => x.SubjectCode == SubjectCode).FirstOrDefault();
        }


        public void DeleteInfo(int id)
        {
            userReposity.DataBasesRepo().ExecuteSqlCommand("delete from Subject where id=? ", new object[]{ id });
        }
        public List<Subject> GetAll(string subjectName)
        {
            if (string.IsNullOrEmpty(subjectName))
            {
                return userReposity.GetRepo<Subject>().ToList();
            }
            else
            {
                return userReposity.GetRepo<Subject>().Where(x => x.SubjectName.Contains(subjectName)).ToList();
                //return userReposity.GetRepo<Subject>().Where(x => x.SubjectName.Contains(subjectName)).ToList();
            }
        }


        public bool Save(Subject info)
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
