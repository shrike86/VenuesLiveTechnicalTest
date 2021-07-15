using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenuesLiveTechnicalTest.API.Contracts;
using VenuesLiveTechnicalTest.Data;
using VenuesLiveTechnicalTest.Data.Entities;
using VenuesLiveTechnicalTest.Shared.Models;

namespace VenuesLiveTechnicalTest.API.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _appDbContext.Invoices.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            return await _appDbContext.Invoices.ToListAsync();
        }

        public async Task CreateInvoiceAsync(Invoice invoice)
        {
            await _appDbContext.AddAsync(invoice);
        }

        public async Task<bool> Save()
        {
            return (await _appDbContext.SaveChangesAsync() >= 0);
        }
    }
}
