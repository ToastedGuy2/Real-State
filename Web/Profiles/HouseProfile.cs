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
            // CreateMap<Item, ItemDto>().ForMember(itemDto => itemDto.Id, opt => opt.MapFrom(src => src.ItemId));
        }
    }
}