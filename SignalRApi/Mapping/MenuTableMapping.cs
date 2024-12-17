using AutoMapper;
using SignalR.BusinessLayer.Dtos.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class MenuTableMapping : Profile
	{
		public MenuTableMapping()
		{
			CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
		}
	}
}