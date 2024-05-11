using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using EditorJournal.Modals;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EditorJournal.data.Repo
{
    public class AppUserImplementation : IRepoImplementaion<AppUser>, AppUserRepo

    {
        public readonly AppDBContext _Db;
        public AppUserImplementation(AppDBContext Db):base(Db)
        {
            _Db = Db;
        }
    

        public void Update(AppUser AppUser)
        {
            _Db.Update(AppUser);
        }
    }
}
