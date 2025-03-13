namespace System.Master.Loyalty.Group.Entities.Inventory
{
    public class InventoryRequest
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public int StoreId { get; set; }

        public int Stock { get; set; }
    }
}
