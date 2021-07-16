using AutoMapper;
using VenuesLiveTechnicalTest.Shared.Models;
using VenuesLiveTechnicalTest.Web.Models;

namespace VenuesLiveTechnicalTest.Web.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<InvoiceDTO, InvoiceVM>()
                .ReverseMap();
        }
    }
}
