using System;
using System.Collections.Generic;

namespace RollCall.Core.Dtos.Outputs
{
	public class ListEmployeeDto : ListPagerDto
	{
		public List<EmployeeDto> ListEmployee { get; set; }

		public SearchEmployeeDto SearchEmployee { get; set; }
	}
}