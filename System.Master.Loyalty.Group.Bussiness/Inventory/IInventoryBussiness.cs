using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Inventory;

namespace System.Master.Loyalty.Group.Bussiness.Inventory
{
    public interface IInventoryBussiness
    {
        Task<List<InventoryResponse>> ReadAll();

        Task<BaseResponse> Create(InventoryRequest request);

        Task<BaseResponse> Update(InventoryRequest request);

        Task<BaseResponse> Delete(int branchId);
    }
}
