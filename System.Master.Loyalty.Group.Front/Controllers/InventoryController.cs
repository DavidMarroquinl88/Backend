using Microsoft.AspNetCore.Mvc;
using System.Master.Loyalty.Group.Bussiness.Branch;
using System.Master.Loyalty.Group.Entities.Branch;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Bussiness.Inventory;
using System.Master.Loyalty.Group.Entities.Inventory;

namespace System.Master.Loyalty.Group.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {

        private readonly IInventoryBussiness inventoryBussiness;
        public InventoryController(IInventoryBussiness inventoryBussiness)
        {
            this.inventoryBussiness = inventoryBussiness;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] InventoryRequest request)
        {
            var result = await this.inventoryBussiness.Create(request);

            return Ok(result);
        }

        [HttpGet("ReadAll")]
        public async Task<ActionResult<List<InventoryResponse>>> ReadAll()
        {
            var result = await this.inventoryBussiness.ReadAll();

            return Ok(result);
        }


        [HttpPost("Update")]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] InventoryRequest request)
        {
            var result = await this.inventoryBussiness.Update(request);

            return Ok(result);
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<BaseResponse>> Delete([FromBody] int branchId)
        {
            var result = await this.inventoryBussiness.Delete(branchId);

            return Ok(result);
        }
    }
}
