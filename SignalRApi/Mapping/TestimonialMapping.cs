﻿using AutoMapper;
using SignalR.BusinessLayer.Dtos.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class TestimonialMapping : Profile
	{
		public TestimonialMapping()
		{
			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
		}
	}
}