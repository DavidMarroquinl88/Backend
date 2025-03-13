using System.Master.Loyalty.Group.Entities.Branch;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Inventory;
using System.Master.Loyalty.Group.Data.Repositories.Branch;
using System.Master.Loyalty.Group.Data;
using System.Master.Loyalty.Group.Data.Repositories.Inventory;

namespace System.Master.Loyalty.Group.Bussiness.Inventory
{
    public class InventoryBussiness : IInventoryBussiness
    {
        private readonly IInventoryRepository inventoryRepository;

        public InventoryBussiness(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<BaseResponse> Create(InventoryRequest request)
        {
            var item = new InventoryData()
            {
                Stock = request.Stock,
                ArticleId = request.ArticleId,
                StoreId = request.StoreId
            };

            var result = await this.inventoryRepository.Create(item);

            return new BaseResponse()
            {
                IsSuccess = result
            };
        }

        public async Task<BaseResponse> Delete(int branchId)
        {

            var result = await this.inventoryRepository.Delete(branchId);

            return new BaseResponse()
            {
                IsSuccess = result
            };

        }

        public async Task<List<InventoryResponse>> ReadAll()
        {
            var result = (await this.inventoryRepository.ReadAll()).Select(element => new InventoryResponse()
            {
                Id = element.Id,
                Stock = element.Stock,
                ArticleId = element.Article.Id,
                ArticleName = element.Article.Name,
                ArticleCode = element.Article.Code,
                StoreId = element.Store.Id,
                StoreName = element.Store.Name,
                BranchId = element.Store.Branch.Id,
                BranchName = element.Store.Branch.Name
            }).ToList();

            return result;
        }

        public async Task<BaseResponse> Update(InventoryRequest request)
        {
            var item = new InventoryData()
            {
                Id = request.Id,
                Stock = request.Stock,
                ArticleId = request.ArticleId,
                StoreId = request.StoreId
            };

            var result = await this.inventoryRepository.Update(item);

            return new BaseResponse()
            {
                IsSuccess = result
            };
        }
    }
}
