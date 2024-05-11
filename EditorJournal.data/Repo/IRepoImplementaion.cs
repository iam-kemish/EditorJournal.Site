using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorJournal.data.Repo
{
    public class IRepoImplementaion<T> : IRepositary<T> where T : class
    {
        private readonly AppDBContext _Db;
        internal DbSet<T> DbSet;
        public IRepoImplementaion(AppDBContext Db)
        {
            _Db=Db;
            this.DbSet= _Db.Set<T>();
        }
        public void Add(T entity)
        {
           DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
           DbSet.Remove(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            query=query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
           IQueryable<T> query= DbSet;
            return query.ToList();
        }

       

        
        public void RemoveRange(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}
