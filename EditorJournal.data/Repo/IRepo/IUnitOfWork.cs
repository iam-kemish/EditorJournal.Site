namespace EditorJournal.data.Repo.IRepo
{
    public interface IUnitOfWork
    {
        public ItemsRepo ItemsRepo { get; }
        public CompanyRepo CompanyRepo { get; }
        public AppUserRepo AppUserRepo { get; }
        void Save();
    }
}
