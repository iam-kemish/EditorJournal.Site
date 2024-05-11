using EditorJournal.Modals;

namespace EditorJournal.data.Repo.IRepo
{
    public interface AppUserRepo:IRepositary<AppUser>
    {
        void Update(AppUser AppUser);
    }
}
