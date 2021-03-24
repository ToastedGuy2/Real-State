using System.Linq;
using AutoMapper;
using Entities;
using Web.Dto;
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
            CreateMap<House, HouseDto>()
            .ForMember(dest => dest.ImageUrl, source => source.MapFrom(source => $"/images/Houses/{source.ImageName}"))
            .ForMember(dest => dest.Province, source => source.MapFrom(source => source.Province.Name))
            .ForMember(dest => dest.Features, source => source.MapFrom(source => source.Features.Select(f => f.Feature.Name).ToArray()));
        }
    }
}