using System.Master.Loyalty.Group.Entitys.Common;

namespace System.Master.Loyalty.Group.Data
{
    public class InventoryData : BaseEntity
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public ArticleData Article { get; set; }

        public int StoreId { get; set; }

        public StoreData Store { get; set; }

        public int Stock { get; set; }
    }
}
