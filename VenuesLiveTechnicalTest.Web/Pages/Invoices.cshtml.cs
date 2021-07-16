using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VenuesLiveTechnicalTest.Web.Contracts;
using VenuesLiveTechnicalTest.Web.Models;

namespace VenuesLiveTechnicalTest.Web.Pages
{
    public class InvoicesModel : PageModel
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        private readonly ILogger<InvoicesModel> _logger;

        public List<InvoiceVM> Invoices { get; set; }

        public InvoicesModel(IInvoiceService invoiceService, IMapper mapper, ILogger<InvoicesModel> logger)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                Invoices = _mapper.Map<List<InvoiceVM>>(await _invoiceService.GetInvoicesAsync());
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("HTTP Request Exception occurred!", ex);
            }
        }
    }
}
