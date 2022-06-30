using System;
using System.Collections.Generic;

namespace RollCall.Core.Dtos.Outputs
{
	public class ListAssitenceDto: ListPagerDto
	{
		public List<DateTime> ListDates { get; set; }
		public List<AssistanceDto> ListAssistances {  get; set; }		
	}
}