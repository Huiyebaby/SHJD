using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SHJD.UserManage.DAL
{
    public interface IBaseReposity
    {
        Database DataBasesRepo();
        DbEntityEntry<T> EntryRepo<T>(T info) where T : class;
        bool Exist();
        DbSet<T> GetRepo<T>() where T : class;
    }
}