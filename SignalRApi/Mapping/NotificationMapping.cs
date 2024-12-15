using AutoMapper;
using SignalR.BusinessLayer.Dtos.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class NotificationMapping : Profile
	{
		public NotificationMapping()
		{
			CreateMap<Notification, ResultNotificationDto>().ReverseMap();
			CreateMap<Notification, CreateNotificationDto>().ReverseMap();
			CreateMap<Notification, GetNotificationDto>().ReverseMap();
			CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
		}
	}
}