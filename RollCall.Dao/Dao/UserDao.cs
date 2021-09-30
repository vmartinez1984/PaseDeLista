using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class UserDao
	{
		public static List<User> GetAll()
		{
			try
			{
				List<User> list;

				using (var db = new AppDbContext())
				{
					list = db.User.Where(x => x.IsActive == true).ToList();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<User>> GetAllAsync(bool isActive)
		{
			try
			{
				List<User> list;

				using (var db = new AppDbContext())
				{
					list = await db.User.Where(x => x.IsActive == isActive && x.Id != 1).ToListAsync();
				}

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<User> GetAsync(int id)
		{
			try
			{
				User item;

				using (var db = new AppDbContext())
				{
					item = await db.User.Where(x => x.Id == id).FirstOrDefaultAsync();
				}

				return item;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> AddAsync(User user)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					user.IsActive = true;
					user.RegistrationDate = DateTime.Now;
					db.User.Add(user);
					await db.SaveChangesAsync();
				}

				return user.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(User user)
		{
			try
			{
				using (var db = new AppDbContext())
				{
					db.Entry<User>(user).State = EntityState.Modified;
					await db.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<User> Login(string email, string password)
		{
			try
			{
				User item;

				using (var db = new AppDbContext())
				{
					//item = await db.User.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
					item = db.User.Where(x => x.Email == email && x.Password == password && x.IsActive == true).FirstOrDefault();
				}

				return item;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}//end class
}