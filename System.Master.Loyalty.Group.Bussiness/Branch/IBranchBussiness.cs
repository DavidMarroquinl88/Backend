using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Branch;

namespace System.Master.Loyalty.Group.Bussiness.Branch
{
    public interface IBranchBussiness
    {

        Task<List<BranchResponse>> ReadAll();

        Task<BaseResponse> Create(BranchRequest request);

        Task<BaseResponse> Update(BranchRequest request);

        Task<BaseResponse> Delete(int branchId);        


    }
}
