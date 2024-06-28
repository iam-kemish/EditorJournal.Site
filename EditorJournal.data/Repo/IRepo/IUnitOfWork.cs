namespace EditorJournal.data.Repo.IRepo
{
    public interface IUnitOfWork
    {
        public ItemsRepo ItemsRepo { get; }
        public CompanyRepo CompanyRepo { get; }
        public AppUserRepo AppUserRepo { get; }
        public ShoppingCartRepo ShoppingCartRepo { get; }  
        public OrderDetailRepo OrderDetailRepo { get; }
        public OrderHeaderRepo OrderHeaderRepo { get; }
        void Save();
    }
}
