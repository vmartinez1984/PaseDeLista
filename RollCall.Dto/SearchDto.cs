using System;

namespace RollCall.Dto
{
	public class SearchDto
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public int? AreaId { get; set; }
		public int? HorarioId { get; set; }
		public DateTime? Date { get; set; }
		public int PageNumber { get; set; }
	}
}