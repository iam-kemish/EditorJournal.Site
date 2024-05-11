using EditorJournal.data.Repo.IRepo;
using EditorJournal.dataSet.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorJournal.data.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDBContext _Db;
        public ItemsRepo ItemsRepo { get; private set; }

        public CompanyRepo CompanyRepo { get; private set; }

        public ShoppingCartRepo ShoppingCartRepo { get; private set; }

       
        public AppUserRepo AppUserRepo { get; private set; }

        public UnitOfWork(AppDBContext Db) 
        {
            _Db = Db;
            ItemsRepo = new ItemsImpleentation(_Db);
            CompanyRepo = new CompanyRepoImplementation(_Db);
            ShoppingCartRepo = new ShoppingCartRepoImplementation(_Db);
            AppUserRepo = new AppUserImplementation(_Db);
        }
        

        public void Save()
        {
            _Db.SaveChanges();
        }
    }
}
