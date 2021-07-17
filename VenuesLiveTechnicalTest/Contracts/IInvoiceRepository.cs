using System.Collections.Generic;
using System.Threading.Tasks;
using VenuesLiveTechnicalTest.Data.Entities;

namespace VenuesLiveTechnicalTest.API.Contracts
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task CreateInvoiceAsync(Invoice invoice);
        Task<bool> SaveAsync();

    }
}
