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
		private int CountRegister { get; set; }
		private SearchAssitence SearchAssistence { get; set; }

		public AssitenceSearchDao(SearchAssitence searchAssitence)
		{
			this.SearchAssistence = searchAssitence;
		}

		public async Task<List<Assistance>> GetAllAsync()
		{
			try
			{
				List<Assistance> entities;

				entities = new List<Assistance>();
				using (var db = new AppDbContext())
				{
					var assistances = db.Assistance
							.Include(x => x.Employee);
							
					if (this.SearchAssistence.AreaId is null)
					{
						
					}
					if (this.SearchAssistence.AreaId is not null)
					{
						assistances.Where(x => x.Employee.AreaId == this.SearchAssistence.AreaId);					
					}
					if(this.SearchAssistence.ScheduleId is not null)
					{
						assistances.Where(x => x.Employee.ScheduleId == this.SearchAssistence.ScheduleId);
					}
					if(this.SearchAssistence.DateStart is not null && this.SearchAssistence.DateStop is null)
					{

					}
					this.CountRegister = await assistances.CountAsync();
					entities = await assistances
						.Skip((this.SearchAssistence.Page - 1) * this.SearchAssistence.NumberOfRecordsPerPage)
						.Take(this.SearchAssistence.NumberOfRecordsPerPage)
						.ToListAsync();

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
