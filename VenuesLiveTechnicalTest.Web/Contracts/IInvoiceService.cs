using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenuesLiveTechnicalTest.Shared.Models;

namespace VenuesLiveTechnicalTest.Web.Contracts
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDTO>> GetInvoicesAsync();
        Task CreateInvoiceAsync(InvoiceDTO invoice);
    }
}
