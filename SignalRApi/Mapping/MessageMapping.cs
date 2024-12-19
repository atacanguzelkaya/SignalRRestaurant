using AutoMapper;
using SignalR.BusinessLayer.Dtos.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class MessageMapping : Profile
	{
		public MessageMapping()
		{
			CreateMap<Message, ResultMessageDto>().ReverseMap();
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, GetMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
		}
	}
}