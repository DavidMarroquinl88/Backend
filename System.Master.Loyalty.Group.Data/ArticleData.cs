using System.Master.Loyalty.Group.Entitys.Common;

namespace System.Master.Loyalty.Group.Data
{
    public class ArticleData : BaseEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public List<InventoryData> Inventories { get; set; }

        public List<OrderDetailData> OrderDetails { get; set; }

        public ArticleData()
        {
            this.Inventories = new List<InventoryData>();

            this.OrderDetails = new List<OrderDetailData>();
        }

    }
}
