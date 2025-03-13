namespace System.Master.Loyalty.Group.Data.Repositories.Branch
{
    public interface IBranchRepository
    {
        Task<List<BranchData>> ReadAll();

        Task<bool> Update(BranchData data);

        Task<bool> Create(BranchData data);

        Task<bool> Delete(int dataId);

    }
}
