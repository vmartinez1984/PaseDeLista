using System;
using System.Collections.Generic;

namespace RollCall.Dto
{
	public class ListEmployeeDto : ListPagerDto
	{
		public List<EmployeeDto> ListEmployee { get; set; }

		public SearchEmployeeDto SearchEmployee { get; set; }
	}
}