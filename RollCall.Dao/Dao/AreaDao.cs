using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
    public class AreaDao : IAreaRepository
	{

		public async Task<List<AreaEntity>> GetAsync()
		{
			try
			{
				List<AreaEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.Area.Where(x => x.IsActive == true).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<AreaEntity> GetAsync(int id)
		{
			try
			{
				AreaEntity item;

				using (var db = new AppDbContext())
				{
					item = await db.Area.Where(x => x.Id == id).FirstOrDefaultAsync();
				}

				return item;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<int> AddAsync(AreaEntity item)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Area.Add(item);
					await db.SaveChangesAsync();
				}

				return item.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task UpdateAsync(AreaEntity item)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Entry<AreaEntity>(item).State = EntityState.Modified;
					await db.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
