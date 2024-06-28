using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorJournal.Modals
{
    public class OrderHeader
    {
        public int Id {  get; set; }    
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get;set; }
        public string? TrackingNumber { get; set; }

        public DateOnly PaymentDeu { get; set; }
        public string? paymentIntentDeu { get; set; }

        public string? Name { get; set; }
       
     
        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
