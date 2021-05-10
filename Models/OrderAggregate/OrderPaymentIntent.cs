namespace BookStoreAPI.Models.OrderAggregate
{
    public class OrderPaymentIntent
    {
        public string PaymentIndentId { get; set; }
        public string ClientSecret { get; set; }
    }
}