using System;
using System.Collections.Generic;

namespace RollCall.Dto
{
	public class ListAssitenceDto
	{
		public List<AssistanceDto> ListAssistances {  get; set; }
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