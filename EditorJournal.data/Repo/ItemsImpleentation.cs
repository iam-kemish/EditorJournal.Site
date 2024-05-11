using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using EditorJournal.Modals;

namespace EditorJournal.data.Repo
{
    public class ItemsImpleentation : IRepoImplementaion<Item>, ItemsRepo
    {
        private readonly AppDBContext _Db;
        public ItemsImpleentation(AppDBContext Db): base(Db)
        {
            _Db = Db;
        }
        
        public void update(Item item)
        {
         _Db.Update(item);
        }
    }
}
