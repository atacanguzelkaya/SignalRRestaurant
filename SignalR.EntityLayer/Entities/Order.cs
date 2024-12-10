namespace SignalR.EntityLayer.Entities
{
	public class Order
	{
		public int OrderID { get; set; }
		public string TableNumber { get; set; }
		public string Description { get; set; }
		public DateOnly OrderDate { get; set; }
		public decimal TotalPrice { get; set; }
		public virtual List<OrderDetail> OrderDetails { get; set; }
	}
}