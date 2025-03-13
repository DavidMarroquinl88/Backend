using System.Master.Loyalty.Group.Entitys.Common;

namespace System.Master.Loyalty.Group.Data
{
    public  class BranchData : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<StoreData> Stores { get; set; }

        public BranchData()
        {
            Stores = new List<StoreData>();
        }

    }
}
