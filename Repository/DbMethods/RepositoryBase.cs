using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbMethods
{
    public abstract class RepositoryBase<T>:IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext db;
        public RepositoryBase(ApplicationDbContext _db)
        {
            db = _db;   
        }

        public IQueryable<T> FindAll(bool tracking) => !tracking ? db.Set<T>().AsNoTracking() : db.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool tracking) => !tracking ? db.Set<T>().Where(condition).AsNoTracking() : db.Set<T>().Where(condition);
     
        public void Create(T entity) => db.Set<T>().Add(entity);
        public void Update(T entity)=> db.Set<T>().Update(entity);
        public void Delete(T entity)=> db.Set<T>().Remove(entity);
    }
}
