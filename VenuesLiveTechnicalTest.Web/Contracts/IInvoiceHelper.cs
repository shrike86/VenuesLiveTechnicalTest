using VenuesLiveTechnicalTest.Shared.Models;
using VenuesLiveTechnicalTest.Web.Models;

namespace VenuesLiveTechnicalTest.Web.Contracts
{
    public interface IInvoiceHelper
    {
        double CalculateDiscountedPrice(double price, double discountPercent);
        double CalculateTax(double price, double taxPercent);
        InvoiceVM ApplyInvoiceTotalCost(InvoiceVM invoice);
    }
}
