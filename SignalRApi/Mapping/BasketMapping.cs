using AutoMapper;
using SignalR.BusinessLayer.Dtos.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class BasketMapping : Profile
	{
		public BasketMapping()
		{
			CreateMap<Basket, CreateBasketDto>().ReverseMap();
			CreateMap<Basket, ResultBasketDto>().ReverseMap();
			CreateMap<Basket, ResultBasketListWithProductsDto>()
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName)).ReverseMap();
		}
	}
}