using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using EditorJournal.Modals;

namespace EditorJournal.data.Repo
{
    public class OrderHeaderImplementation:IRepoImplementaion<OrderHeader>,OrderHeaderRepo
    {
        public readonly AppDBContext _Db;
        public OrderHeaderImplementation(AppDBContext Db): base(Db)
        {
            _Db = Db;   
        }
      

        public void Update(OrderHeaderRepo orderHeader)
        {
            _Db.Update(orderHeader);
        }
    }
}
