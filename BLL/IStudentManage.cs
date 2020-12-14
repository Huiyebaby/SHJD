using SHJD.UserManage.DAL.DTO;
using SHJD.UserManage.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.BLL
{
   public  interface IStudentManage
    {
        Student GetInfo(string Sno);

        void DeleteInfo(int id);
        List<Student> GetAll(string Name, string grade);
        bool Save(Student info);
        List<StuSubInfo> GetStuSubAll();
        void DeleteSubInfo(int id);
        StuSubInfo GetStuInfo(int id);
        StuSub GetStuSubInfo(int id);
        bool SaveStuSub(StuSub info);
    }
}
