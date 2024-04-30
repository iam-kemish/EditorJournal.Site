using System.Linq.Expressions;

namespace EditorJournal.dataSet.Repo.IRepo
{
    public interface ItemsRepo<T> where T : class
    {
       
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filterItems);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);
        void Update(T Item);
        
    }
}
