using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenuesLiveTechnicalTest.API.Contracts;
using VenuesLiveTechnicalTest.Data.Entities;
using VenuesLiveTechnicalTest.Shared.Models;

namespace VenuesLiveTechnicalTest.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceRepository.GetInvoicesAsync();
            return Ok(_mapper.Map<List<InvoiceDTO>>(invoices));
        }

        [HttpGet("{id}", Name = "GetInvoice")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InvoiceDTO>(invoice));
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceDTO invoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newInvoice = _mapper.Map<Invoice>(invoiceDto);

            await _invoiceRepository.CreateInvoiceAsync(newInvoice);
            await _invoiceRepository.Save();

            var returnInvoice = _mapper.Map<InvoiceDTO>(newInvoice);

            return CreatedAtRoute("GetInvoice", new { id = newInvoice.Id}, returnInvoice);
        }
    }
}
