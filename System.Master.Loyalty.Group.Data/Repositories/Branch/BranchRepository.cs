
using Microsoft.EntityFrameworkCore;

namespace System.Master.Loyalty.Group.Data.Repositories.Branch
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DbDataContext db;
        public BranchRepository(DbDataContext dataContext)
        {
            db = dataContext;
        }
        public async Task<bool> Create(BranchData data)
        {
            try
            {
                db.Branchs.Add(data);
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
                var item = await db.Branchs.FindAsync(dataId);

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

        public async Task<List<BranchData>> ReadAll()
        {
            var result = await db.Branchs.Where(element => element.Status != Enums.Status.Delete).ToListAsync();

            return result;
        }

        public async Task<bool> Update(BranchData data)
        {
            try
            {
                data.Status = Enums.Status.Update;
                data.LastModifiedDate = DateTime.Now;
                db.Branchs.Update(data);
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
