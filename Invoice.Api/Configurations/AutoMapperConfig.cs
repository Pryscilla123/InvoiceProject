using AutoMapper;
using Invoice.Api.ViewModels;
using Invoice.Business.Models;

namespace Invoice.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fatura, FaturaViewModel>().ReverseMap();
            CreateMap<FaturaItem, FaturaItemViewModel>().ReverseMap();
        }
    }
}
