using SHJD.UserManage.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.BLL
{
    public interface ISubjectManage
    {

        Subject GetSubject(string SubjectCode);

        void DeleteInfo(int id);
        List<Subject> GetAll(string UserName);
        bool Save(Subject info);
    }
}
