using System.Master.Loyalty.Group.Entitys.Common;

namespace System.Master.Loyalty.Group.Data
{
    public class OrderDetailData : BaseEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public OrderData Order { get; set; }

        public int ArticleId { get; set; }

        public ArticleData Article { get; set; }

        public decimal Quantity { get; set; }
    }
}
