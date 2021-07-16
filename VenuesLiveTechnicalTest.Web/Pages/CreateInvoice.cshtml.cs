using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VenuesLiveTechnicalTest.Shared.Models;
using VenuesLiveTechnicalTest.Web.Contracts;
using VenuesLiveTechnicalTest.Web.Models;

namespace VenuesLiveTechnicalTest.Web.Pages
{
    public class CreateInvoiceModel : PageModel
    {
        [BindProperty]
        public InvoiceVM Invoice { get; set; }

        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInvoiceModel> _logger;
        private readonly IInvoiceHelper _invoiceHelper;

        public CreateInvoiceModel(IInvoiceService invoiceService, IMapper mapper, ILogger<CreateInvoiceModel> logger, IInvoiceHelper invoiceCalculations)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
            _logger = logger;
            _invoiceHelper = invoiceCalculations;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var calculatedInvoice = _invoiceHelper.ApplyInvoiceTotalCost(Invoice); 
                    await _invoiceService.CreateInvoiceAsync(_mapper.Map<InvoiceDTO>(calculatedInvoice));
                    return RedirectToPage("InvoiceCreated", "Success");
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError("HTTP Request Exception occurred!", ex);
                    return RedirectToPage("Error", "Error");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
