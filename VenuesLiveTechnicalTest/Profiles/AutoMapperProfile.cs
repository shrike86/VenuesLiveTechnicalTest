using AutoMapper;
using VenuesLiveTechnicalTest.Data.Entities;
using VenuesLiveTechnicalTest.Shared.Models;

namespace VenuesLiveTechnicalTest.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Invoice, InvoiceDTO>()
                .ReverseMap();
        }
    }
}
