using AutoMapper;
using SignalR.BusinessLayer.Dtos.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class FeatureMapping : Profile
	{
		public FeatureMapping()
		{
			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, GetFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
		}
	}
}