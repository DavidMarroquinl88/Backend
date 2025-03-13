namespace System.Master.Loyalty.Group.Data.Repositories.Store
{
    public  interface IStoreRepository
    {
        Task<List<StoreData>> ReadAll();

        Task<bool> Update(StoreData data);

        Task<bool> Create(StoreData data);

        Task<bool> Delete(int dataId);
    }
}
