using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using EditorJournal.Modals;

namespace EditorJournal.data.Repo
{
    public class OrderDetailImplementation : IRepoImplementaion<OrderDetail>, OrderDetailRepo
    {
        public readonly AppDBContext _Db;
        public OrderDetailImplementation(AppDBContext Db):base(Db)
        {
            _Db = Db;
        }
        public void Update(OrderDetailRepo orderDetail)
        {
         _Db.Update(orderDetail);   
        }
    }
}
