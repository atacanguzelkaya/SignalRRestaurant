using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Dtos.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly IBasketService _basketService;
		private readonly IMapper _mapper;
		public BasketController(IBasketService basketService, IMapper mapper)
		{
			_basketService = basketService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetBasketByMenuTableID(int id)
		{
			var values = _basketService.TGetBasketByMenuTableNumber(id);
			return Ok(values);
		}

		[HttpGet("BasketListByMenuTableWithProductName")]
		public IActionResult BasketListByMenuTableWithProductName(int id)
		{
			var values = _basketService.TGetBasketByMenuTableNumber(id);
			return Ok(_mapper.Map<List<ResultBasketListWithProductsDto>>(values));
		}

		[HttpPost]
		public IActionResult CreateBasket(CreateBasketDto createBasketDto)
		{
			var value = _mapper.Map<Basket>(createBasketDto);
			_basketService.TAdd(value);
			return Ok("Basket Added");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBasket(int id)
		{
			var value = _basketService.TGetByID(id);
			_basketService.TDelete(value);
			return Ok("Sepetteki Seçilen Ürün Silindi");
		}
	}
}
