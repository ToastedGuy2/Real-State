using AutoMapper;
using Entities;
using Web.ViewModels.House;

namespace Web.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<AddHouseViewModel, House>();
            CreateMap<House, UpdateHouseViewModel>()
            .ForMember(dest => dest.Features, source => source.Ignore())
            .ForMember(dest => dest.Services, source => source.Ignore())
            .ReverseMap();

        }
    }
}