using Microsoft.EntityFrameworkCore;

namespace System.Master.Loyalty.Group.Data.Repositories.Article
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbDataContext db;
        public ArticleRepository(DbDataContext dataContext)
        {
            db = dataContext;
        }
        public async Task<bool> Create(ArticleData data)
        {
            try
            {
                db.Articles.Add(data);
                await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int dataId)
        {
            try
            {
                var item = await db.Articles.FindAsync(dataId);

                if (item != null)
                {
                    item.Status = Enums.Status.Delete;
                    await db.SaveChangesAsync();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<List<ArticleData>> ReadAll()
        {
            var result = await db.Articles.Where(element => element.Status != Enums.Status.Delete).ToListAsync();

            return result;
        }

        public async Task<bool> Update(ArticleData data)
        {
            try
            {
                data.Status = Enums.Status.Update;
                data.LastModifiedDate = DateTime.Now;
                db.Articles.Update(data);
                await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
