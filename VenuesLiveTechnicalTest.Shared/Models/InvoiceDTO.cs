using System.ComponentModel.DataAnnotations;

namespace VenuesLiveTechnicalTest.Shared.Models
{
    public class InvoiceDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double Price { get; set; } 
        [Required]
        public double DiscountPercentage { get; set; }
        [Required]
        public double TaxPercentage { get; set; }
        [Required]
        public double TotalAmount { get; set; }
    }
}
