using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Dtos.TestimonialDto;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;
		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			var values = _testimonialService.TGetListAll();
			return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			var value = _mapper.Map<Testimonial>(createTestimonialDto);
			_testimonialService.TAdd(value);
			return Ok("Testimonial Added");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(value);
			return Ok("Testimonial Deleted");
		}
		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			var value = _mapper.Map<Testimonial>(updateTestimonialDto);
			_testimonialService.TUpdate(value);
			return Ok("Testimonial Updated");
		}
		[HttpGet("{id}")]
		public IActionResult GetTestimonial(int id)
		{
			var value = _testimonialService.TGetByID(id);
			return Ok(_mapper.Map<GetTestimonialDto>(value));
		}
	}
}
