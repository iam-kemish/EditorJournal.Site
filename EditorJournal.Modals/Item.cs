using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditorJournal.Modals
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? AuthorName { get; set; }
        [Required]
      
        
        [Range(1, 1000)]

        public double Price { get; set; }
      
        public string Genre { get;set; }
     
        [ValidateNever]
        public  string ImageUrl { get; set; } 
    }
}
