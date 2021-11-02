using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class EmployeeSearchDao
	{
		private int CountRegister { get; set; }
		private SearchEmployee SearchEmployee { get; set; }

		public EmployeeSearchDao(SearchEmployee searchEmployee)
		{
			this.SearchEmployee = searchEmployee;
		}

		public async Task<List<EmployeeEntity>> GetAllAsync()
		{
			try
			{
				List<EmployeeEntity> entities;

				entities = new List<EmployeeEntity>();
				using (var db = new AppDbContext())
				{
					if (string.IsNullOrEmpty(this.SearchEmployee.Name) && string.IsNullOrEmpty(this.SearchEmployee.LastName) && this.SearchEmployee.DateStart is null && this.SearchEmployee.DateStop is null)
					{
						entities = await db.Employee.Include(x=>x.Schedule).Include(x=>x.Area)
							.Where(x => x.IsActive == this.SearchEmployee.IsActive)
							.OrderBy(x => x.Id)
							.Skip((this.SearchEmployee.Page - 1) * this.SearchEmployee.NumberOfRecordsPerPage)
							.Take(this.SearchEmployee.NumberOfRecordsPerPage)
							.ToListAsync();
						this.CountRegister = await db.Employee
							.Where(x => x.IsActive == this.SearchEmployee.IsActive).CountAsync();
					}
					else if (string.IsNullOrEmpty(this.SearchEmployee.Name) && string.IsNullOrEmpty(this.SearchEmployee.LastName) && this.SearchEmployee.DateStart != null && this.SearchEmployee.DateStop != null)
					{
						entities = await db.Employee.Include(x => x.Schedule).Include(x => x.Area)
							.Where(x => x.IsActive == this.SearchEmployee.IsActive)
							.Where(x=> x.RegistrationDate >= this.SearchEmployee.DateStart && x.RegistrationDate <= ((DateTime)this.SearchEmployee.DateStop).AddDays(1))
							.OrderBy(x => x.Id)
							.Skip((this.SearchEmployee.Page - 1) * this.SearchEmployee.NumberOfRecordsPerPage)
							.Take(this.SearchEmployee.NumberOfRecordsPerPage)
							.ToListAsync();
						this.CountRegister = await db.Employee
							.Where(x => x.IsActive == this.SearchEmployee.IsActive)
							.Where(x => x.RegistrationDate >= this.SearchEmployee.DateStart && x.RegistrationDate <= ((DateTime)this.SearchEmployee.DateStop).AddDays(1))
							.CountAsync();
					}
					else if ((!string.IsNullOrEmpty(this.SearchEmployee.Name) || !string.IsNullOrEmpty(this.SearchEmployee.LastName)) && (this.SearchEmployee.DateStart != null && this.SearchEmployee.DateStop != null))
					{
						entities = await db.Employee.Include(x => x.Schedule).Include(x => x.Area)
							.Where(x => x.IsActive == this.SearchEmployee.IsActive)
							.Where(x => x.RegistrationDate >= this.SearchEmployee.DateStart && x.RegistrationDate < ((DateTime)this.SearchEmployee.DateStop).AddDays(1))
							.Where(x => x.Name.Contains(this.SearchEmployee.Name) || x.LastName.Contains(this.SearchEmployee.LastName))
							.OrderBy(x => x.Id)
							.Skip((this.SearchEmployee.Page - 1) * this.SearchEmployee.NumberOfRecordsPerPage)
							.Take(this.SearchEmployee.NumberOfRecordsPerPage)
							.ToListAsync();
						this.CountRegister = await db.Employee
							.Where(x => x.IsActive == this.SearchEmployee.IsActive)
							.Where(x => x.RegistrationDate >= this.SearchEmployee.DateStart && x.RegistrationDate < ((DateTime)this.SearchEmployee.DateStop).AddDays(1))
							.Where(x => x.Name.Contains(this.SearchEmployee.Name) || x.LastName.Contains(this.SearchEmployee.LastName))
							.CountAsync();
					}
					else if (!string.IsNullOrEmpty(this.SearchEmployee.Name) || !string.IsNullOrEmpty(this.SearchEmployee.LastName))
                    {
						entities = await db.Employee.Include(x => x.Schedule).Include(x => x.Area)
							.Where(
								x => x.IsActive == this.SearchEmployee.IsActive &&
							    (x.Name.Contains(this.SearchEmployee.Name) || x.LastName.Contains(this.SearchEmployee.LastName))
							)
							.OrderBy(x => x.Id)
							.Skip((this.SearchEmployee.Page - 1) * this.SearchEmployee.NumberOfRecordsPerPage)
							.Take(this.SearchEmployee.NumberOfRecordsPerPage)
							.ToListAsync();
						this.CountRegister = await db.Employee
							.Where(
								x => x.IsActive == this.SearchEmployee.IsActive &&
								(x.Name.Contains(this.SearchEmployee.Name) || x.LastName.Contains(this.SearchEmployee.LastName))
							)
							.CountAsync();
					}
				}

				return entities;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public int Count()
		{
			return this.CountRegister;
		}
	}
}
