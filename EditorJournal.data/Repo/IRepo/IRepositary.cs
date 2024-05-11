using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EditorJournal.data.Repo.IRepo
{
    public interface IRepositary<T> where T : class
    {
    IEnumerable<T> GetAll();   
    T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(T entity);
       

    }
}
