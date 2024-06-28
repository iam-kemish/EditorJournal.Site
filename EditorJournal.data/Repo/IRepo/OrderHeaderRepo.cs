using EditorJournal.Modals;

namespace EditorJournal.data.Repo.IRepo
{
    public interface OrderHeaderRepo:IRepositary<OrderHeader>
    {
        void Update(OrderHeaderRepo orderHeader);
    }
}
