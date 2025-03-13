using Microsoft.AspNetCore.Mvc;
using System.Master.Loyalty.Group.Bussiness.Store;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Store;

namespace System.Master.Loyalty.Group.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreBussiness storeBussiness;
        public StoreController(IStoreBussiness storeBussiness)
        {
            this.storeBussiness = storeBussiness;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] StoreRequest request)
        {
            var result = await this.storeBussiness.Create(request);

            return Ok(result);
        }

        [HttpGet("ReadAll")]
        public async Task<ActionResult<List<StoreResponse>>> ReadAll()
        {
            var result = await this.storeBussiness.ReadAll();

            return Ok(result);
        }


        [HttpPost("Update")]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] StoreRequest request)
        {
            var result = await this.storeBussiness.Update(request);

            return Ok(result);
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<BaseResponse>> Delete([FromBody] int branchId)
        {
            var result = await this.storeBussiness.Delete(branchId);

            return Ok(result);
        }
    }
}
