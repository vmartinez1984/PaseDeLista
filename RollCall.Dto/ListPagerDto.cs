using System;

namespace RollCall.Dto
{
	public class ListPagerDto
	{
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
	}
}