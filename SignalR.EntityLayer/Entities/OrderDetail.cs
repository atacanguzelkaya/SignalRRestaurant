﻿namespace SignalR.EntityLayer.Entities
{
	public class OrderDetail
	{
		public int OrderDetailID { get; set; }
		public int ProductID { get; set; }
		public int OrderID { get; set; }
		public int Count { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public virtual Product Product { get; set; }
		public virtual Order Order { get; set; }
	}
}