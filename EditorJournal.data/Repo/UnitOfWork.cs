using EditorJournal.dataSet.Database;
using EditorJournal.dataSet.Repo.IRepo;

namespace EditorJournal.dataSet.Repo
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private AppDBContext _Db;
     
        public ItemsRepo<T> ItemsRepo { get; private set; }

        public UnitOfWork(AppDBContext Db)
        {
           _Db= Db;
          
            ItemsRepo = new RepoItem<T>(_Db);
    }

        public void Save()
        {
            _Db.SaveChanges();
        }
    }
}
