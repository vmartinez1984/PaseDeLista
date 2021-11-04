using System;
using System.Collections.Generic;

namespace RollCall.Dto
{
	public class ListAssitenceDto: ListPagerDto
	{
		public List<AssistanceDto> ListAssistances {  get; set; }		
	}
}