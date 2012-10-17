using System.Linq;
using AutoMapper;
using ViewModelsLab.Domain;
using ViewModelsLab.Models;

namespace ViewModelsLab.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });
        }
    }

    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderLineItems,
                    opt => opt.MapFrom(src => 
                        src.OrderLineItems.Select(o => string.Format("{0}: Quantity - {1}", 
                            o.Product.Name, o.Quantity)).ToList())
                            ); 
        }
    }

}