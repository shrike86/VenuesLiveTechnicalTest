using System;
using VenuesLiveTechnicalTest.Shared.Models;
using VenuesLiveTechnicalTest.Web.Contracts;
using VenuesLiveTechnicalTest.Web.Models;

namespace VenuesLiveTechnicalTest.Web
{
    public class InvoiceHelper : IInvoiceHelper
    {
        public double CalculateTax(double basePrice, double taxPercent)
        {
            return Math.Round((basePrice / 100) * taxPercent, 2);
        }

        public double CalculateDiscountedPrice(double price, double discountPercent)
        {
            var discountAmount = (price / 100) * discountPercent;
            return price - discountAmount;
        }

        public InvoiceVM ApplyInvoiceTotalCost(InvoiceVM invoice)
        {
            var totalPrice = invoice.Price * invoice.Quantity;
            var discountedPrice = CalculateDiscountedPrice(totalPrice, invoice.DiscountPercentage);
            var taxAmount = CalculateTax(discountedPrice, invoice.TaxPercentage);
            invoice.TotalAmount = Math.Round(discountedPrice + taxAmount, 2);
            return invoice;
        }
    }
}
