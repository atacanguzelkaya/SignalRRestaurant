using AutoMapper;
using SignalR.BusinessLayer.Dtos.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class SocialMediaMapping : Profile
	{
		public SocialMediaMapping()
		{
			CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
		}
	}
}