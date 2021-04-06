using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Entities;
using Web.ViewModels.Rent;

namespace Web.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceViewModel, Invoice>()
            .ForMember(dest => dest.Date, source => source.MapFrom(source => DateTimeOffset.Now))
            .ForMember(dest => dest.StartDate, source => source.MapFrom(source => DateTimeOffset.ParseExact(source.From, "MM.dd.yyyy", new CultureInfo("en-US"))))
            .ForMember(dest => dest.EndDate, source => source.MapFrom(source => DateTimeOffset.ParseExact(source.To, "MM.dd.yyyy", new CultureInfo("en-US"))));
            // .ForMember(dest => dest.Services, source => source.MapFrom(source => source.SelectedServices.Select(serviceId => new InvoiceService() { ServiceId = serviceId.ServiceId }).ToList()));
        }
    }
}