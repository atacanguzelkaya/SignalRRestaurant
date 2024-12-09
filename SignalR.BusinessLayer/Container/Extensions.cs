﻿using Microsoft.Extensions.DependencyInjection;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;

namespace SignalR.BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<IAboutService, AboutManager>();
			services.AddScoped<IAboutDal, EfAboutDal>();

			services.AddScoped<IBookingService, BookingManager>();
			services.AddScoped<IBookingDal, EfBookingDal>();

			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<ICategoryDal, EfCategoryDal>();

			services.AddScoped<IContactService, ContactManager>();
			services.AddScoped<IContactDal, EfContactDal>();

			services.AddScoped<IDiscountService, DiscountManager>();
			services.AddScoped<IDiscountDal, EfDiscountDal>();

			services.AddScoped<IFeatureService, FeatureManager>();
			services.AddScoped<IFeatureDal, EfFeatureDal>();

			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IProductDal, EfProductDal>();

			services.AddScoped<ISocialMediaService, SocialMediaManager>();
			services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

			services.AddScoped<ITestimonialService, TestimonialManager>();
			services.AddScoped<ITestimonialDal, EfTestimonialDal>();

			services.AddScoped<IOrderService, OrderManager>();
			services.AddScoped<IOrderDal, EfOrderDal>();

			services.AddScoped<IOrderDetailService, OrderDetailManager>();
			services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
		}
	}
}