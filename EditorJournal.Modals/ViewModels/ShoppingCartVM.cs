using EditorJournal.Modal;

namespace EditorJournal.Modals.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartLists { get; set; }
        public OrderHeader OrderHeader { get; set; }
       
    }
}
