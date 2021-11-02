using System;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class SearchAssistenceDto
	{
		[Display(Name = "Número de empleado")]
		public string NumberEmployee { get; set; }

		[Display(Name = "Nombre")]
		public string Name { get; set; }

		[Display(Name = "Apellido")]
		public string LastName { get; set; }

		[Display(Name = "Area")]
		public int AreaId { get; set; }

		[Display(Name = "Horario")]
		public int ScheduleId { get; set; }

		public int Page { get; set; }

		public bool IsActive { get; set; }

		public int NumberOfRecordsPerPage { get; set; }

		[Display(Name = "Fecha incio")]
		[DataType(DataType.Date)]
		public DateTime? DateStart { get; set; }

		[Display(Name = "Fecha fin")]
		[DataType(DataType.Date)]
		public DateTime? DateStop { get; set; }

		public SearchAssistenceDto()
		{
			this.Page = 1;
			this.IsActive = true;
			this.NumberOfRecordsPerPage = 25;
		}
	}
}