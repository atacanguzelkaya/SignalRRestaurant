using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Dtos.BasketDto;
using SignalR.DataAccessLayer.Concrete;
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
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                MenuTableID = createBasketDto.MenuTableID,
                Count = 1,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = createBasketDto.TotalPrice,
            });
            return Ok("The selected product in the basket added");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBasket(int id)
		{
			var value = _basketService.TGetByID(id);
			_basketService.TDelete(value);
			return Ok("The selected product in the basket deleted");
		}
	}
}
