using SHJD.UserManage.DAL.DTO;
using SHJD.UserManage.DAL.Model;
using SHJD.UserManage.DAL.Reposity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.BLL.Impl
{
    public class StudentManageImpl: IStudentManage
    {
        private static StudentReposity userReposity = new StudentReposity();

        public Student GetInfo(string Sno)
        {
            return userReposity.GetRepo<Student>().Where(x => x.Sno == Sno).FirstOrDefault();
        }


        public void DeleteInfo(int id)
        {
            userReposity.DataBasesRepo().ExecuteSqlCommand("delete from Student where id=? ", new object[] { id });
        }
        public List<Student> GetAll(string Name,string grade)
        {
            if (string.IsNullOrEmpty(Name)&& string.IsNullOrEmpty(grade))
            {
                return userReposity.GetRepo<Student>().ToList();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                var param = new List<object>();
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    sb.Append(" and SName like ?");
                    param.Add($"%{Name}%");
                }
                if (!string.IsNullOrWhiteSpace(grade))
                {
                    sb.Append(" and Sgrade like ?");
                    param.Add($"{grade}%");
                }
                //var userList =userReposity.GetRepo<Student>().AsQueryable();
                //if (!string.IsNullOrWhiteSpace(Name))
                //{
                //    userList.Where(x => x.Sname.Contains(Name));
                //}
                //if (!string.IsNullOrWhiteSpace(grade))
                //{
                //    userList.Where(x => x.Sgrade.StartsWith(grade));
                //}
                //return userList.ToList();
                return userReposity.GetRepo<Student>().SqlQuery("select * from Student where 1=1 "+sb.ToString(),param.ToArray()).ToList();
            }
        }


        public bool Save(Student info)
        {
            var result = false;
            if (info.id < 1)
            {
                result = userReposity.Insert(info) > 0;
            }
            else
            {
                result = userReposity.Update(info) > 0;
            }
            return result;
        }



        public StuSubInfo GetStuInfo(int id) {
            //var sql = @"SELECT s.*,stu.Sname,stu.sgrade,sub.SubjectName FROM stusub s" +
            //  "left join student stu on stu.Sno = s.Sno" +
            //  "left join subject sub on sub.SubjectCode = s.Code where s.id=? ";
            //return userReposity.DataBasesRepo().SqlQuery<StuSubInfo>(sql, new object[] { id }).FirstOrDefault();



            var info = (from x in userReposity.GetRepo<StuSub>()
                       join y in userReposity.GetRepo<Student>() on x.Sno equals y.Sno into stuInfo
                       from j in stuInfo.DefaultIfEmpty()
                       join k in userReposity.GetRepo<Subject>() on x.Code equals k.SubjectCode into subInfo
                       from v in subInfo.DefaultIfEmpty()
                       where x.id == id
                       select new StuSubInfo
                       {
                           id = x.id,
                           Sno = x.Sno,
                           Sname = j.Sname,
                           Sgrade = j.Sgrade,
                           Batch = x.Batch,
                           Achievement = x.Achievement,
                           Code = x.Code,
                           SubjectName = v.SubjectName
                       }).FirstOrDefault();
            return info;
        }
        public List<StuSubInfo> GetStuSubAll() {
            var lst = (from x in userReposity.GetRepo<StuSub>()
                       join y in userReposity.GetRepo<Student>() on x.Sno equals y.Sno into stuInfo
                       from j in stuInfo.DefaultIfEmpty()
                       join k in userReposity.GetRepo<Subject>() on x.Code equals k.SubjectCode into subInfo
                       from v in subInfo.DefaultIfEmpty()
                       select new StuSubInfo
                       {
                           id=x.id,
                           Sno=x.Sno,
                           Sname=j.Sname,
                           Sgrade=j.Sgrade,
                           Batch=x.Batch,
                           Achievement=x.Achievement,
                           Code=x.Code,
                           SubjectName=v.SubjectName
                       }).ToList();
            return lst;
            //var sql = @"SELECT s.*,stu.Sname,stu.sgrade,sub.SubjectName FROM stusub s" +
            //    "left join student stu on stu.Sno = s.Sno"+
            //    "left join subject sub on sub.SubjectCode = s.Code";
            //return userReposity.DataBasesRepo().SqlQuery<StuSubInfo>(sql, new object[] {  }).ToList();
        
        }

        public void DeleteSubInfo(int id)
        {
            userReposity.DataBasesRepo().ExecuteSqlCommand("delete from stusub where id=? ", new object[] { id });
        }

        public StuSub GetStuSubInfo(int id)
        {
            return userReposity.GetRepo<StuSub>().Where(x => x.id == id).FirstOrDefault();
        }

        public bool SaveStuSub(StuSub info)
        {
            var result = false;
            if (info.id < 1)
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
