using System.Master.Loyalty.Group.Entitys.Common;

namespace System.Master.Loyalty.Group.Data
{
    public class OrderData : BaseEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public decimal Total { get; set; }

        public List<OrderDetailData> OrderDetails { get; set; }

        public OrderData()
        {
            OrderDetails = new List<OrderDetailData>();
        }
    }
}
