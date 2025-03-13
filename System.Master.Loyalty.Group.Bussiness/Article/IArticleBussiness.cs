using System.Master.Loyalty.Group.Entities.Branch;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Article;

namespace System.Master.Loyalty.Group.Bussiness.Article
{
    public interface IArticleBussiness
    {
        Task<List<ArticleResponse>> ReadAll();

        Task<BaseResponse> Create(ArticleRequest request);

        Task<BaseResponse> Update(ArticleRequest request);

        Task<BaseResponse> Delete(int branchId);
    }
}
