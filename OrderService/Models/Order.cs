namespace OrderService.Models
{
    public class Order
    {
        public int[] BookIds { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
