using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditorJournal.Modals
{
    public class AppUser: IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }
    
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        [ValidateNever]
        public Company Company { get; set; }
    }
}
