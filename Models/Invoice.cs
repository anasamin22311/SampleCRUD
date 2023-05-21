using SampleCRUD.Models;
using System.ComponentModel;

namespace SampleCRUD.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [DisplayName("CustomerName")]
        public string CustomerName { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; } // Use the plural form for the property name
        [DisplayName("Date")]
        public DateTime InvoiceDate { get; set; }
    }

}