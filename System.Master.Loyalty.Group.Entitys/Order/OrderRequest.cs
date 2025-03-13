namespace System.Master.Loyalty.Group.Entities.Order
{
    public class OrderRequest
    {
        public int Total { get; set; }

        public int UserId { get; set; }

        public List<OrderDetailRequest> OrderDetail { get; set; }

        public OrderRequest()
        {
            this.OrderDetail = new List<OrderDetailRequest>();
        }

    }
}
