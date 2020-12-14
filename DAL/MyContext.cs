using SHJD.UserManage.DAL.Model;
using SHJD.UserManage.Helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.DAL
{
    public class MyContext : DbContext
    {
        private static DbConnection GetDbConnection() {
          return  new MySql.Data.MySqlClient.MySqlConnection(ConstHelper.SqlConnectString);
        }
        public MyContext()
            : base(GetDbConnection(),true)//web.config中connectionstring的名字
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StuSub> StuSubs { get; set; }
    }
}
