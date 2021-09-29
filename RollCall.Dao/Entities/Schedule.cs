using System;

namespace RollCall.Persistence.Entities
{
	public class Schedule
	{
		public int Id { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime StopTime { get; set; }
		public DateTime  RegistrationDate { get; set; }
		public bool IsActive { get; set; }
	}
}