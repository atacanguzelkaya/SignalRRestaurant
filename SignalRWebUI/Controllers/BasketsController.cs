﻿using Microsoft.AspNetCore.Mvc;
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
			var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44334/api/Basket/BasketListByMenuTableWithProductName?id=" + 4);
            if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}