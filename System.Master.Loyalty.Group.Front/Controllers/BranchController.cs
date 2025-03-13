using Microsoft.AspNetCore.Mvc;
using System.Master.Loyalty.Group.Bussiness.Branch;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Branch;

namespace System.Master.Loyalty.Group.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {

        private readonly IBranchBussiness branchBussiness;
        public BranchController(IBranchBussiness branchBussiness)
        {
            this.branchBussiness = branchBussiness;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] BranchRequest request)
        {
            var result = await this.branchBussiness.Create(request);

            return Ok(result);
        }

        [HttpGet("ReadAll")]
        public async Task<ActionResult<List<BranchResponse>>> ReadAll()
        {
            var result = await this.branchBussiness.ReadAll();

            return Ok(result);
        }


        [HttpPost("Update")]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] BranchRequest request)
        {
            var result = await this.branchBussiness.Update(request);

            return Ok(result);
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<BaseResponse>> Delete([FromBody] int branchId)
        {
            var result = await this.branchBussiness.Delete(branchId);

            return Ok(result);
        }
    }
}
