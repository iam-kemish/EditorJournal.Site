using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using EditorJournal.Modals;

namespace EditorJournal.data.Repo
{
    public class CompanyRepoImplementation : IRepoImplementaion<Company>, CompanyRepo
    {
        public readonly AppDBContext _Db;
        public CompanyRepoImplementation(AppDBContext Db):base(Db)
        {
            _Db = Db;
        }
        public void Update(Company company)
        {
          _Db.Update(company);
        }
    }
}
