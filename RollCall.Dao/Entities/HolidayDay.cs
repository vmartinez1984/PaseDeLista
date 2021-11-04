using System;

namespace RollCall.Persistence.Entities
{
	public class HolidayDay
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
	}
}