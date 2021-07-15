using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenuesLiveTechnicalTest.Data;
using VenuesLiveTechnicalTest.Data.Entities;

namespace VenuesLiveTechnicalTest.API
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any board games.
                if (context.Invoices.Any())
                {
                    return;   // Data was already seeded
                }

                context.Invoices.AddRange(
                    new Invoice
                    {
                        Id = 1,
                        Description = "Soccer Ball",
                        Quantity = 1,
                        DiscountPercentage = 5,
                        TaxPercentage = 10,
                        TotalAmount = 11.5
                    });

                context.SaveChanges();
            }
        }
    }
}
