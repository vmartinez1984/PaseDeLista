using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.Persistence.Entities
{
	public class SearchAssitence
	{
		public int Page { get; set; }
		public int NumberOfRecordsPerPage { get; set; }
		public bool IsActive { get; set; }
		public string EmployeeNumber { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateStop { get; set; }

		public int? AreaId { get; set; }
		public int? ScheduleId { get; set; }

		public SearchAssitence()
		{
			this.NumberOfRecordsPerPage = 25;
			this.Page = 1;
			this.IsActive = true;
		}
	}
}
