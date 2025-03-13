namespace System.Master.Loyalty.Group.Data.Repositories.Article
{
    public interface IArticleRepository
    {
        Task<List<ArticleData>> ReadAll();

        Task<bool> Update(ArticleData data);

        Task<bool> Create(ArticleData data);

        Task<bool> Delete(int dataId);
    }
}
