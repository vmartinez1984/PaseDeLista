using Microsoft.EntityFrameworkCore;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
	public class AssitenceSearchDao
	{
		private List<EmployeeEntity> ListEmployee { get; set; }
		private List<AssistanceLog> ListAssistances { get; set; }
		private int CountRegister { get; set; }
		private SearchAssitence SearchAssistence { get; set; }
		private List<int> ListEmployeesId;

		public AssitenceSearchDao(SearchAssitence searchAssitence)
		{
			this.SearchAssistence = searchAssitence;
		}

		public async Task GetAllAsync()
		{
			try
			{
				this.ListEmployeesId = await GetListEmployeeIds();
				this.ListEmployee = await GetLisEmployeeAsync();
				this.ListAssistances = await GetListAssistencesAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private async Task<List<int>> GetListEmployeeIds()
		{
			try
			{
				List<int> listEmployeesId;

				using (var db = new AppDbContext())
				{
					IQueryable<AssistanceLog> assistances = db.AssistanceLog
							.Include(x => x.Employee);
					if (!string.IsNullOrEmpty(this.SearchAssistence.EmployeeNumber))
					{
						assistances = assistances.Where(x => x.Employee.EmployeeNumber == this.SearchAssistence.EmployeeNumber);
					}
					if (this.SearchAssistence.AreaId is not null && this.SearchAssistence.AreaId != 0)
					{
						assistances = assistances.Where(x => x.Employee.AreaId == this.SearchAssistence.AreaId).AsQueryable();
					}
					if (this.SearchAssistence.ScheduleId is not null && this.SearchAssistence.ScheduleId != 0)
					{
						assistances = assistances.Where(x => x.Employee.ScheduleId == this.SearchAssistence.ScheduleId);
					}
					if (this.SearchAssistence.DateStart is not null && this.SearchAssistence.DateStop is null)
					{
						assistances = assistances.Where(
							x => x.RegistrationDate.Day == ((DateTime)this.SearchAssistence.DateStart).Day
							&&
							x.RegistrationDate.Month == ((DateTime)this.SearchAssistence.DateStart).Month
							&&
							x.RegistrationDate.Year == ((DateTime)this.SearchAssistence.DateStart).Year
						);
					}
					if (this.SearchAssistence.DateStart is not null && this.SearchAssistence.DateStop is not null)
					{
						assistances = assistances.Where(x => x.RegistrationDate >= this.SearchAssistence.DateStart && x.RegistrationDate <= ((DateTime)this.SearchAssistence.DateStop).AddDays(1));
					}
					var query = assistances.ToQueryString();
					listEmployeesId = await assistances
					.Where(x => x.RegistrationDate >= this.SearchAssistence.DateStart && x.RegistrationDate < ((DateTime)this.SearchAssistence.DateStop).AddDays(1))
					.Select(x => x.EmployeeId)
					.Distinct()
					.ToListAsync();
				}

				return listEmployeesId;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private async Task<List<AssistanceLog>> GetListAssistencesAsync()
		{
			try
			{
				List<AssistanceLog> entities;

				entities = new List<AssistanceLog>();
				using (var db = new AppDbContext())
				{
					entities = await db.AssistanceLog
						.Skip((this.SearchAssistence.Page - 1) * this.SearchAssistence.NumberOfRecordsPerPage)
						.Take(this.SearchAssistence.NumberOfRecordsPerPage)
						.ToListAsync();
					this.CountRegister = await db.AssistanceLog.Where(x => ListEmployeesId.Contains(x.Id)).CountAsync();
				}

				return entities;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public List<AssistanceLog> GetLisAssistences()
		{
			return this.ListAssistances;
		}

		private async Task<List<EmployeeEntity>> GetLisEmployeeAsync()
		{
			List<EmployeeEntity> list;

			using (var db = new AppDbContext())
			{
				list = await db.Employee
					.Include(x=> x.Schedule)
					.Where(x => ListEmployeesId.Contains(x.Id))					
					.ToListAsync();				
			}

			return list;
		}

		public int Count()
		{
			return this.CountRegister;
		}

		public List<EmployeeEntity> GetListEmployees()
		{
			return this.ListEmployee;
		}
	}
}