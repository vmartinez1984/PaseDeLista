using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class AssistanceDao
	{
		public static async Task<List<AssistanceLogEntity>> GetAllAsync()
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllNowAsync()
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x => x.DateRegistration.Date == DateTime.Now.Date).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllByDate(DateTime date)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x => x.DateRegistration.Date >= date.Date).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllByDates(DateTime startDate, DateTime stopDate)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x =>
					x.DateRegistration.Date >= startDate.Date
					&&
					x.DateRegistration.Date <= stopDate.Date
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAll(int month, int year)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x =>
					x.DateRegistration.Month == month
					&&
					x.DateRegistration.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllAsync(int userId, int month, int year)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x =>
					x.EmployeeId == userId
					&&
					x.DateRegistration.Month == month
					&&
					x.DateRegistration.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllByAreaId(int areaId, int month, int year)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog
					.Include(x => x.Employee)
					.Where(x =>
					x.Employee.AreaId == areaId
					&&
					x.DateRegistration.Month == month
					&&
					x.DateRegistration.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllByScheduleId(int scheduleId, int month, int year)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog
					.Include(x => x.Employee)
					.Where(x =>
					x.Employee.ScheduleId == scheduleId
					&&
					x.DateRegistration.Month == month
					&&
					x.DateRegistration.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllByAreaIdAndSheduleId(int areaId, int scheduleId, int month, int year)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog
					.Include(x => x.Employee)
					.Where(x =>
					x.Employee.AreaId == areaId && x.Employee.ScheduleId == scheduleId
					&&
					x.DateRegistration.Month == month
					&&
					x.DateRegistration.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLogEntity>> GetAllAsync(int userId)
		{
			try
			{
				List<AssistanceLogEntity> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x => x.EmployeeId == userId).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> AddAsync(AssistanceLogEntity item)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.AssistanceLog.Add(item);
					await db.SaveChangesAsync();
				}

				return item.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}