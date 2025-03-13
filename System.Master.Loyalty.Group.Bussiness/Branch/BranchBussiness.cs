using Azure.Core;
using System.Master.Loyalty.Group.Data;
using System.Master.Loyalty.Group.Data.Repositories.Branch;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Branch;

namespace System.Master.Loyalty.Group.Bussiness.Branch
{
    public class BranchBussiness : IBranchBussiness
    {

        private readonly IBranchRepository branchRepository;

        public BranchBussiness(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
        }
        public async Task<BaseResponse> Create(BranchRequest request)
        {
            var item = new BranchData()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTime.Now
            };

            var result = await this.branchRepository.Create(item);

            return new BaseResponse()
            {
                IsSuccess = result
            };
        }

        public async Task<BaseResponse> Delete(int branchId)
        {

            var result = await this.branchRepository.Delete(branchId);

            return new BaseResponse()
            {
                IsSuccess = result
            };

        }

        public async Task<List<BranchResponse>> ReadAll()
        {
            var result = (await this.branchRepository.ReadAll()).Select(element => new BranchResponse()
            {
                Id = element.Id,
                Name = element.Name,
                Description = element.Description,
                IsSuccess = true
            }).ToList();

            return result;
        }

        public async Task<BaseResponse> Update(BranchRequest request)
        {
            var item = new BranchData()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTime.Now
            };

            var result = await this.branchRepository.Update(item);

            return new BaseResponse()
            {
                IsSuccess = result
            };
        }
    }
}
