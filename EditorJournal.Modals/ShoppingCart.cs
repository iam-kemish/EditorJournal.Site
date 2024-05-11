using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditorJournal.Modals
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Item Item { get; set; }
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
