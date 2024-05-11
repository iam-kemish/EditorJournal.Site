using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using EditorJournal.Modals;

namespace EditorJournal.data.Repo
{
    public class ShoppingCartRepoImplementation : IRepoImplementaion<ShoppingCart>, ShoppingCartRepo
    {
        public readonly AppDBContext _Db;
        public ShoppingCartRepoImplementation(AppDBContext Db):base(Db)
        {
            _Db = Db;
        }
        public void Update(ShoppingCart shoppingCart)
        {
          _Db.Update(shoppingCart);
        }
    }
}
