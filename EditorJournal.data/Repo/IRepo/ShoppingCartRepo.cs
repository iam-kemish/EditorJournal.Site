using EditorJournal.Modals;

namespace EditorJournal.data.Repo.IRepo
{
    public interface ShoppingCartRepo:IRepositary<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart);
    }
}
