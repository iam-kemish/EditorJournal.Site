using EditorJournal.Modals;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditorJournal.Modal
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        [ValidateNever]
        public Item Item { get; set; }
        [Range(1, 5, ErrorMessage = "You can only enter 1 50 5 items at a time.")]
        public int Count { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }


    }
}
