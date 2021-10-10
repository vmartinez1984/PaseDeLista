using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class SecurityQuestionDao
	{
		public static async Task AddAsync(SecurityQuestion entity)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.SecurityQuestions.Add(entity);
					await db.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<SecurityQuestion> GetAsync(int id)
		{
			try
			{
				SecurityQuestion entity;

				using (var db = new AppDbContext())
				{
					entity = await db.SecurityQuestions.FindAsync(id);
				}

				return entity;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(SecurityQuestion entity)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Entry(entity).State = EntityState.Modified;
					await db.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<SecurityQuestion>> GetAllAsync(int employeeId, bool isActive = true)
		{
			try
			{
				List<SecurityQuestion> list;

				using (var db = new AppDbContext())
				{
					list = await db.SecurityQuestions.Where(x => x.IsActive == isActive && x.EmployeeId == employeeId).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
