using Microsoft.EntityFrameworkCore;

namespace System.Master.Loyalty.Group.Data.Repositories.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {

        private readonly DbDataContext db;
        public InventoryRepository(DbDataContext dataContext)
        {
            db = dataContext;
        }

        public async Task<bool> Create(InventoryData data)
        {
            try
            {
                db.Inventories.Add(data);
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
                var item = await db.Inventories.FindAsync(dataId);

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

        public async Task<List<InventoryData>> ReadAll()
        {
            var result = await db.Inventories.Where(element => element.Status != Enums.Status.Delete)
                .Include(e => e.Article)
                .Include(e => e.Store).ThenInclude(element => element.Branch)
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(InventoryData data)
        {
            try
            {
                data.Status = Enums.Status.Update;
                data.LastModifiedDate = DateTime.Now;
                db.Inventories.Update(data);
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
