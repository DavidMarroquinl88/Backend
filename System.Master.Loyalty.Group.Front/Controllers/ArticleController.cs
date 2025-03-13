using Microsoft.AspNetCore.Mvc;
using System.Master.Loyalty.Group.Bussiness.Branch;
using System.Master.Loyalty.Group.Entities.Branch;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Article;
using System.Master.Loyalty.Group.Bussiness.Article;

namespace System.Master.Loyalty.Group.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IArticleBussiness articleBussiness;
        public ArticleController(IArticleBussiness articleBussiness)
        {
            this.articleBussiness = articleBussiness;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse>> Create([FromForm] ArticleRequest request)
        {
            var result = await this.articleBussiness.Create(request);

            return Ok(result);
        }

        [HttpGet("ReadAll")]
        public async Task<ActionResult<List<ArticleResponse>>> ReadAll()
        {
            var result = await this.articleBussiness.ReadAll();

            return Ok(result);
        }


        [HttpPost("Update")]
        public async Task<ActionResult<BaseResponse>> Update([FromForm] ArticleRequest request)
        {
            var result = await this.articleBussiness.Update(request);

            return Ok(result);
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<BaseResponse>> Delete([FromBody] int branchId)
        {
            var result = await this.articleBussiness.Delete(branchId);

            return Ok(result);
        }
    }
}
