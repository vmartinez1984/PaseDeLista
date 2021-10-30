using System;

namespace RollCall.Persistence.Entities
{
	public class SearchEmployee
	{		
		public int Page { get; set; }
		public int NumberOfRecordsPerPage { get; set; }
		public bool IsActive { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateStop { get; set; }

		public SearchEmployee()
		{			
			this.IsActive = true;
			this.Page = 1;
			this.NumberOfRecordsPerPage = 10;
		}
	}
}
