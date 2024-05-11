using EditorJournal.Modals;

namespace EditorJournal.data.Repo.IRepo
{
    public interface CompanyRepo:IRepositary<Company>
    {
        void Update(Company company);
    }
}
