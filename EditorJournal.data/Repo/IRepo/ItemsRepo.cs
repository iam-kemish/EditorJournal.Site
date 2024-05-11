using EditorJournal.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorJournal.data.Repo.IRepo
{
    public interface ItemsRepo: IRepositary<Item>
    {
        void update(Item item);

    }
}
