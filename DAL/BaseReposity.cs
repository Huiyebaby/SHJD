using SHJD.UserManage.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.DAL
{
    /// <summary>
    /// 公共仓库
    /// </summary>
    public class BaseReposity : IBaseReposity
    {
        protected static DbContext db;
        public BaseReposity()
        {
            db = new MyContext();
        }
        public bool Exist()
        {
            return db.Database.Exists();
        }

        public DbSet<T> GetRepo<T>() where T : class
        {
            return db.Set<T>();
        }

        public int Insert<T>(T info) where T : class
        {
             db.Entry(info).State=EntityState.Added;
            return db.SaveChanges();
        }

        public int Update<T>(T info) where T : class
        {
            db.Entry(info).State= EntityState.Modified;
            return db.SaveChanges();
        }
        public int Update<T>(IEnumerable<T> list) where T : class
        {
            foreach (var info in list)
            {
                db.Entry(info).State = EntityState.Modified;
            }
            return db.SaveChanges();
        }

        public DbEntityEntry<T> EntryRepo<T>(T info) where T : class
        {
            return db.Entry<T>(info);
        }

        public Database DataBasesRepo()
        {
            return db.Database;
        }
    }
}
