using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class ScheduleDao
	{
		public static async Task<List<Schedule>> GetAllAsync(bool isActive)
		{
			try
			{
				List<Schedule> list;

				using (var db = new AppDbContext())
				{
					list = await db.Schedule.Where(x => x.IsActive == isActive).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<Schedule> GetAsync(int id)
		{
			try
			{
				Schedule item;

				using (var db = new AppDbContext())
				{
					item = await db.Schedule.Where(x => x.Id == id).FirstOrDefaultAsync();
				}

				return item;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> AddAsync(Schedule item)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Schedule.Add(item);
					await db.SaveChangesAsync();
				}

				return item.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static void Update(Schedule item)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Entry<Schedule>(item).State = EntityState.Modified;
					db.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
