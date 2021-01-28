using AutoMapper;
using Entities;
using Web.Models;
using Web.ViewModels.Item;

namespace Web.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<AddItemViewModel, Item>();
            CreateMap<Item, ItemDto>().ForMember(itemDto => itemDto.Id, opt => opt.MapFrom(src => src.ItemId));
        }
    }
}