using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Store;

namespace System.Master.Loyalty.Group.Bussiness.Store
{
    public interface IStoreBussiness
    {
        Task<List<StoreResponse>> ReadAll();

        Task<BaseResponse> Create(StoreRequest request);

        Task<BaseResponse> Update(StoreRequest request);

        Task<BaseResponse> Delete(int branchId);
    }
}
