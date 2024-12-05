using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Dtos.SocialMediaDto;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;
		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var values = _socialMediaService.TGetListAll();
			return Ok(_mapper.Map<List<ResultSocialMediaDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
			_socialMediaService.TAdd(value);
			return Ok("SocialMedia Added");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteSocialMedia(int id)
		{
			var value = _socialMediaService.TGetByID(id);
			_socialMediaService.TDelete(value);
			return Ok("SocialMedia Deleted");
		}
		[HttpPut]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
			_socialMediaService.TUpdate(value);
			return Ok("SocialMedia Updated");
		}
		[HttpGet("{id}")]
		public IActionResult GetSocialMedia(int id)
		{
			var value = _socialMediaService.TGetByID(id);
			return Ok(_mapper.Map<GetSocialMediaDto>(value));
		}
	}
}
