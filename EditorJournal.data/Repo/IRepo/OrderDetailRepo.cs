using EditorJournal.Modals;

namespace EditorJournal.data.Repo.IRepo
{
    public interface OrderDetailRepo:IRepositary<OrderDetail>
    {
        void Update(OrderDetailRepo orderDetail);
    }
}
