using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class AssistanceDao
	{
		public static async Task<List<AssistanceLog>> GetAllAsync()
		{
			try
			{
				List<AssistanceLog> list;

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

		public static async Task<List<AssistanceLog>> GetAllNowAsync()
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x => x.RegistrationDate.Date == DateTime.Now.Date).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAllByDate(DateTime date)
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x => x.RegistrationDate.Date >= date.Date).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAllByDates(DateTime startDate, DateTime stopDate)
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x =>
					x.RegistrationDate.Date >= startDate.Date
					&&
					x.RegistrationDate.Date <= stopDate.Date
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAll(int month, int year)
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x =>
					x.RegistrationDate.Month == month
					&&
					x.RegistrationDate.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAllAsync(int userId, int month, int year)
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog.Where(x =>
					x.EmployeeId == userId
					&&
					x.RegistrationDate.Month == month
					&&
					x.RegistrationDate.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAllByAreaId(int areaId, int month, int year)
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog
					.Include(x => x.Employee)
					.Where(x =>
					x.Employee.AreaId == areaId
					&&
					x.RegistrationDate.Month == month
					&&
					x.RegistrationDate.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAllByScheduleId(int scheduleId, int month, int year)
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog
					.Include(x => x.Employee)
					.Where(x =>
					x.Employee.ScheduleId == scheduleId
					&&
					x.RegistrationDate.Month == month
					&&
					x.RegistrationDate.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAllByAreaIdAndSheduleId(int areaId, int scheduleId, int month, int year)
		{
			try
			{
				List<AssistanceLog> list;

				using (var db = new AppDbContext())
				{
					list = await db.AssistanceLog
					.Include(x => x.Employee)
					.Where(x =>
					x.Employee.AreaId == areaId && x.Employee.ScheduleId == scheduleId
					&&
					x.RegistrationDate.Month == month
					&&
					x.RegistrationDate.Year == year
					).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceLog>> GetAllAsync(int userId)
		{
			try
			{
				List<AssistanceLog> list;

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

		public static async Task<int> AddAsync(AssistanceLog item)
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