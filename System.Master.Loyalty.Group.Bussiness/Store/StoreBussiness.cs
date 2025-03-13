using System.Master.Loyalty.Group.Data;
using System.Master.Loyalty.Group.Data.Repositories.Branch;
using System.Master.Loyalty.Group.Data.Repositories.Store;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Branch;
using System.Master.Loyalty.Group.Entities.Store;

namespace System.Master.Loyalty.Group.Bussiness.Store
{
    public class StoreBussiness : IStoreBussiness
    {
        private readonly IStoreRepository storeRepository;

        public StoreBussiness(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }
        public async Task<BaseResponse> Create(StoreRequest request)
        {
            var item = new StoreData()
            {
                Name = request.Name,
                Address = request.Address,
                BranchId = request.BranchId,
                CreatedDate = DateTime.Now,
                Status = Data.Enums.Status.Create
            };

            var result = await this.storeRepository.Create(item);

            return new BaseResponse()
            {
                IsSuccess = result
            };
        }

        public async Task<BaseResponse> Delete(int branchId)
        {

            var result = await this.storeRepository.Delete(branchId);

            return new BaseResponse()
            {
                IsSuccess = result
            };

        }

        public async Task<List<StoreResponse>> ReadAll()
        {
            var result = (await this.storeRepository.ReadAll()).Select(element => new StoreResponse()
            {
                Id = element.Id,
                Name = element.Name,
                Address = element.Address,
                BranchId = element.Branch.Id,
                BranchName = element.Branch.Name,
                IsSuccess = true
            }).ToList();

            return result;
        }

        public async Task<BaseResponse> Update(StoreRequest request)
        {
            var item = new StoreData()
            {
                Id = request.Id,
                Name = request.Name,
                Address = request.Address,
                BranchId = request.BranchId,
                CreatedDate = DateTime.Now
            };

            var result = await this.storeRepository.Update(item);

            return new BaseResponse()
            {
                IsSuccess = result
            };
        }
    }
}
