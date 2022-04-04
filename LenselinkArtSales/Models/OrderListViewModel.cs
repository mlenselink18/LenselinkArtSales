namespace LenselinkArtSales.Models
{
    public class OrderListViewModel
    {
        public Order order { get; set; }
        public User customer { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public int orderItemCount { get; set; }
    }
}
