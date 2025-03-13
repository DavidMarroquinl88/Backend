using System.Master.Loyalty.Group.Entitys.Common;

namespace System.Master.Loyalty.Group.Data
{
    public class StoreData : BaseEntity
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        public BranchData Branch { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public List<InventoryData> Inventories { get; set; }

        public StoreData()
        {
            this.Inventories = new List<InventoryData>();
        }
    }
}
