using SampleCRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace SampleCRUD.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public Invoice? Invoice { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
    }
}