using System;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class SearchEmployeeDto
	{
		[Display(Name = "Nombre")]
		[MaxLength(150)]
		public string Name { get; set; }

		[Display(Name = "Apellidos")]
		[MaxLength(150)]
		public string LastName { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Fecha inicio")]
		public DateTime? DateBegin { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Fecha fin")]
		public DateTime? DateEnd { get; set; }
	}
}