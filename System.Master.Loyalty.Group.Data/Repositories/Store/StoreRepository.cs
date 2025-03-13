using Microsoft.EntityFrameworkCore;

namespace System.Master.Loyalty.Group.Data.Repositories.Store
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DbDataContext db;
        public StoreRepository(DbDataContext dataContext)
        {
            db = dataContext;
        }
        public async Task<bool> Create(StoreData data)
        {
            try
            {
                db.Stores.Add(data);
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
                var item = await db.Stores.FindAsync(dataId);

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

        public async Task<List<StoreData>> ReadAll()
        {
            var result = await db.Stores.
                Where(element => element.Status != Enums.Status.Delete)
                .Include(element => element.Branch)
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(StoreData data)
        {
            try
            {
                data.Status = Enums.Status.Update;
                data.LastModifiedDate = DateTime.Now;
                db.Stores.Update(data);
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
