namespace System.Master.Loyalty.Group.Entities.Store
{
    public class StoreRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string BranchName { get; set; } = string.Empty;

        public int BranchId { get; set; }
    }
}
