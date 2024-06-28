using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditorJournal.Modals
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }
        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        [ValidateNever]
        public Item Item { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }


    }
}
