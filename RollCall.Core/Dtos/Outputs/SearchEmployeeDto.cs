using System;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos.Outputs
{
	public class SearchEmployeeDto: SearchDto
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

        public bool IsActive { get; set; }

        public SearchEmployeeDto()
        {
			this.IsActive = true;
			this.Page = 1;
			this.NumberOfRecordsPerPage = 6;
        }
    }
}