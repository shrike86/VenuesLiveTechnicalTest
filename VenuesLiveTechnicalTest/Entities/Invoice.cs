using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenuesLiveTechnicalTest.Data.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double DiscountPercentage { get; set; }
        public double TaxPercentage { get; set; }
        public double TotalAmount { get; set; }
    }
}
