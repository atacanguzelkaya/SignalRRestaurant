using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDto;

namespace SignalRWebUI.Controllers
{
	public class BasketsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BasketsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index(int id)
		{
            TempData["tableId"] = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44334/api/Basket/BasketListByMenuTableWithProductName?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public async Task<IActionResult> DeleteBasket(int id)
		{
            int tableId = int.Parse(TempData["tableId"].ToString());
            var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44334/api/Basket/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", new { id = tableId });
			}
			return NoContent();
		}
	}
}