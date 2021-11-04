using System;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class SearchAssistenceDto : SearchDto
	{
		[Display(Name = "Número de empleado")]
		public string EmployeeNumber { get; set; }

		[Display(Name = "Nombre")]
		public string Name { get; set; }

		[Display(Name = "Apellido")]
		public string LastName { get; set; }

		[Display(Name = "Area")]
		public int AreaId { get; set; }

		[Display(Name = "Horario")]
		public int ScheduleId { get; set; }

		public bool IsActive { get; set; }

		[Display(Name = "Fecha incio")]
		[DataType(DataType.Date)]
		public DateTime DateStart { get; set; }

		[Display(Name = "Fecha fin")]
		[DataType(DataType.Date)]
		public DateTime DateStop { get; set; }

		public SearchAssistenceDto()
		{
			this.Page = 1;
			this.IsActive = true;
			this.NumberOfRecordsPerPage = 25;
			InitDates();
		}

		private void InitDates()
		{
			DateTime dateTime;

			dateTime = DateTime.Now;
			DateStart = new DateTime(dateTime.Year, dateTime.Month, 1);
			DateStop = DateStart;
			DateStop = DateStop.AddMonths(1);
			DateStop = DateStop.AddDays(-1);
		}
	}
}