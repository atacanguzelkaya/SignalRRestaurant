namespace SignalR.EntityLayer.Entities
{
	public class Basket
	{
		public int BasketID { get; set; }
		public decimal Price { get; set; }
		public decimal Count { get; set; }
		public decimal TotalPrice { get; set; }
		public int ProductID { get; set; }
		public virtual Product Product { get; set; }
		public int MenuTableID { get; set; }
		public virtual MenuTable MenuTable { get; set; }
	}
}