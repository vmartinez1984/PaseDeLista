using System;
using System.Collections.Generic;

namespace RollCall.Dto
{
	public class ListEmployeeDto
	{
		public List<EmployeeDto> ListEmployee { get; set; }
		public int CurrentPage { get; set; }
		public int NumberOfRecordsPerPage { get; set; }
		public int TotalOfRecords { get; set; }
		public int CountPage
		{
			get
			{
				return (int)Math.Ceiling((double)TotalOfRecords / NumberOfRecordsPerPage);
			}
		}
		public SearchEmployeeDto SearchEmployee { get; set; }
	}
}