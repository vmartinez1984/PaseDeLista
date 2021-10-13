using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class EmployeeDao
	{
		public static List<Employee> GetAll()
		{
			try
			{
				List<Employee> list;

				using (var db = new AppDbContext())
				{
					list = db.Employee.Where(x => x.IsActive == true).ToList();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static Task<Employee> GetAllAsync(string employeeNumber)
		{
			throw new NotImplementedException();
		}

		public static async Task<Employee> GetAllAsync(int employeeId, string employeeNumber)
		{
			try
			{
				Employee item;

				using (var db = new AppDbContext())
				{
					item = await db.Employee
						.Where(x => x.EmployeeNumber == employeeNumber)
						.Where(x => x.IsActive == true)
						.FirstOrDefaultAsync();
				}

				return item;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<Employee>> GetAllAsync(bool isActive)
		{
			try
			{
				List<Employee> list;

				using (var db = new AppDbContext())
				{
					list = await db.Employee
						.Include(x => x.ListSecurityQuestions)
						.Include(x => x.Area)
						.Include(x=> x.Schedule)
						.Where(x => x.IsActive == isActive && x.Id != 1).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<Employee> GetAsync(int id)
		{
			try
			{
				Employee item;

				using (var db = new AppDbContext())
				{
					item = await db.Employee
						.Include(x=> x.ListSecurityQuestions)
						.Where(x => x.Id == id).FirstOrDefaultAsync();
				}

				return item;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> AddAsync(Employee entity)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					entity.IsActive = true;
					entity.RegistrationDate = DateTime.Now;
					db.Employee.Add(entity);
					await db.SaveChangesAsync();
				}

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(Employee entity)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Entry<Employee>(entity).State = EntityState.Modified;
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