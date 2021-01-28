using AutoMapper;
using Entities;
using Web.Models;

namespace Web.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>().ForMember(brandDto => brandDto.Id, opt => opt.MapFrom(src => src.BrandId));
        }
    }
}