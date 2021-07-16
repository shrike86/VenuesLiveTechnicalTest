using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenuesLiveTechnicalTest.Web.Models
{
    public class InvoiceVM
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Discount Percentage")]
        public double DiscountPercentage { get; set; }

        [Required]
        [Display(Name = "Tax Percentage")]
        public double TaxPercentage { get; set; }

        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }
    }
}
