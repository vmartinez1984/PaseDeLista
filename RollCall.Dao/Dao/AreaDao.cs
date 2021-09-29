using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class AreaDao
	{

		public static async Task<List<Area>> GetAllAsync(bool isActive)
		{
			try
			{
				List<Area> list;

				using (var db = new AppDbContext())
				{
					list = await db.Area.Where(x => x.IsActive == isActive).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<Area> GetAsync(int id)
		{
			try
			{
				Area item;

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

		public static async Task<int> AddAsync(Area item)
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

		public static async Task Update(Area item)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Entry<Area>(item).State = EntityState.Modified;
					await db.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
