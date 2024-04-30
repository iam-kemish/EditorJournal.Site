using EditorJournal.dataSet.Database;
using EditorJournal.dataSet.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EditorJournal.dataSet.Repo
{
    public class RepoItem<T> : ItemsRepo<T> where T : class
    {
        public readonly AppDBContext _ItemsRepo;
        internal DbSet<T> _Items;

        public RepoItem(AppDBContext ItemsRepo)
        {
            _ItemsRepo = ItemsRepo; 
            this._Items = _ItemsRepo.Set<T>();
         
        }
        public  void Add(T item)
        {
          _Items.Add(item);
        }

       public T Get(Expression<Func<T, bool>> filterItems)
        {
            IQueryable<T> query = _Items;
            query = query.Where(filterItems);
        
            return query.FirstOrDefault();


        }

       public IEnumerable<T> GetAll()
        {
           IQueryable<T> query = _Items;
          
            return query.ToList();
        }

      public  void Remove(T item)
        {
           _Items.Remove(item);
        }

       public void RemoveRange(IEnumerable<T> items)
        {
           _Items.RemoveRange(items);
        }
        public void Update(T Item)
        {
          _ItemsRepo.Update(Item);
        }
    }
}
