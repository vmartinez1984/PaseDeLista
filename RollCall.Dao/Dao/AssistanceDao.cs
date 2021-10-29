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
		public static async Task<List<Assistance>> GetAllAsync()
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance.ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<Assistance>> GetAllNowAsync()
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance.Where(x => x.RegistrationDate.Date == DateTime.Now.Date).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<Assistance>> GetAllByDate(DateTime date)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance.Where(x => x.RegistrationDate.Date >= date.Date).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<Assistance>> GetAllByDates(DateTime startDate, DateTime stopDate)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance.Where(x =>
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

		public static Task<int> GetTotalOfRecordsAsync()
		{
			throw new NotImplementedException();
		}

		public static async Task<int> GetTotalOfRecords()
		{
			try
			{
				int totalOfRecords;

				using(var db = new AppDbContext())
				{
					totalOfRecords = await db.Assistance.CountAsync();
				}

				return totalOfRecords;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<Assistance>> GetAllAsync(string name, string lastName)
		{
			List<Assistance> list;

			using (var db = new AppDbContext())
			{
				list = await db.Assistance
					.Include(x => x.Employee)
					.Where(x => x.Employee.Name.Contains(name) && x.Employee.LastName.Contains(lastName))
					.ToListAsync();
			}

			return list;
		}

		public static async Task<List<Assistance>> GetAllAsync(int page, int numberOfRecordPerPage)
		{
			try
			{
				List<Assistance> entities;

				using (var db = new AppDbContext())
				{
					entities = await db.Assistance.OrderBy(x=> x.Id)
						.Skip((page - 1) * numberOfRecordPerPage)
						.Take(numberOfRecordPerPage).ToListAsync();
				}

				return entities;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<Assistance>> GetAll(int month, int year)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance.Where(x =>
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

		public static async Task<List<Assistance>> GetAllAsync(int userId, int month, int year)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance.Where(x =>
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

		public static async Task<List<Assistance>> GetAllByAreaId(int areaId, int month, int year)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance
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

		public static async Task<List<Assistance>> GetAllByScheduleId(int scheduleId, int month, int year)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance
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

		public static async Task<List<Assistance>> GetAllByAreaIdAndSheduleId(int areaId, int scheduleId, int month, int year)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance
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

		public static async Task<List<Assistance>> GetAllAsync(int userId)
		{
			try
			{
				List<Assistance> list;

				using (var db = new AppDbContext())
				{
					list = await db.Assistance.Where(x => x.EmployeeId == userId).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> AddAsync(Assistance item)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Assistance.Add(item);
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