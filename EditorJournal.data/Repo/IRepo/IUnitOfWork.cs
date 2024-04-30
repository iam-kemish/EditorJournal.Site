namespace EditorJournal.dataSet.Repo.IRepo
{
    public interface IUnitOfWork<T> where T : class
    {
 
 ItemsRepo<T> ItemsRepo {  get; }
        void Save();
    }
}
