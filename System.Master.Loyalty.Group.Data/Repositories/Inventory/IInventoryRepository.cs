namespace System.Master.Loyalty.Group.Data.Repositories.Inventory
{
    public interface IInventoryRepository
    {
        Task<List<InventoryData>> ReadAll();

        Task<bool> Update(InventoryData data);

        Task<bool> Create(InventoryData data);

        Task<bool> Delete(int dataId);


    }
}
