using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, bool tracked=false)
        {
            if (tracked)
            {
                IQueryable<T> query = DbSet;
                query = query.Where(filter);
                return query.FirstOrDefault();
            }else
            {
                IQueryable<T> query = DbSet.AsNoTracking();
                query = query.Where(filter);
                return query.FirstOrDefault();
            }
        }

    
        public void RemoveRange(T entity)
        {
            DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }
            if(includeProperties != null && includeProperties.Length > 0)
            {
                foreach (var property in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }
    }
}
