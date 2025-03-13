using Microsoft.AspNetCore.Mvc;
using System.Master.Loyalty.Group.Bussiness.Order;
using System.Master.Loyalty.Group.Entities.Store;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Order;

namespace System.Master.Loyalty.Group.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {

        private readonly IOrderBussiness orderBussiness;
        public OrderController(IOrderBussiness orderBussiness)
        {
            this.orderBussiness = orderBussiness;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<OrderResponse>> Create([FromBody] OrderRequest request)
        {
            var result = await this.orderBussiness.CreateOrder(request);

            return Ok(result);
        }


        [HttpPost("ValidateQuiantityToProduct")]
        public async Task<ActionResult<BaseResponse>> ValidateQuiantityToProduct([FromBody] OrderValidateRequest request)
        {
            var result = await this.orderBussiness.ValidateQuiantityToProduct(request);

            return Ok(result);
        }
    }
}
