using AutoMapper;
using SignalR.BusinessLayer.Dtos.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class CategoryMapping : Profile
	{
		public CategoryMapping()
		{
			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, GetCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();
		}
	}
}