namespace System.Master.Loyalty.Group.Entities.Inventory
{
    public class InventoryResponse
    {

        public int Id { get; set; }

        public int ArticleId { get; set; }

        public string ArticleCode { get; set; } = string.Empty;

        public string ArticleName { get; set; } = string.Empty;

        public int StoreId { get; set; }

        public string StoreName { get; set; } = string.Empty;

        public int BranchId { get; set; }

        public string BranchName { get; set; } = string.Empty;

        public decimal Stock { get; set; }

    }
}
