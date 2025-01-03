﻿using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		List<Product> TGetProductsWithCategory();
		int TProductCount();
		int TProductCountByCategoryNameHamburger();
		int TProductCountByCategoryNameDrink();
		decimal TProductPriceAvg();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();
		decimal TProductAvgPriceByHamburger();
        decimal TProductPriceBySteakBurger();
        decimal TTotalPriceByDrinkCategory();
        decimal TTotalPriceBySaladCategory();
        List<Product> TGetLast9Products();
    }
}