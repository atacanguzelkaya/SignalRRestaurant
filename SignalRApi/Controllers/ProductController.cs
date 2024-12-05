using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Dtos.ProductDto;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _productService.TGetListAll();
			return Ok(_mapper.Map<List<ResultProductDto>>(values));
		}
		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			//var context = new SignalRContext();
			//var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
			//{
			//	Description = y.Description,
			//	ImageUrl = y.ImageUrl,
			//	Price = y.Price,
			//	ProductID = y.ProductID,
			//	ProductName = y.ProductName,
			//	ProductStatus = y.ProductStatus,
			//	CategoryName = y.Category.CategoryName
			//});
			//return Ok(values.ToList());

			var values = _productService.TGetProductsWithCategory();
			return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			_productService.TAdd(value);
			return Ok("Product Added");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var value = _productService.TGetByID(id);
			_productService.TDelete(value);
			return Ok("Product Deleted");
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var value = _mapper.Map<Product>(updateProductDto);
			_productService.TUpdate(value);
			return Ok("Product Updated");
		}
		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(_mapper.Map<GetProductDto>(value));
		}
	}
}
