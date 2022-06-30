using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos.Outputs
{
    public class ScheduleDto
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Inicio de turno")]
		[DataType(DataType.Time)]
		public DateTime StartTime { get; set; }

		[Display(Name = "Fin de turno")]
		[DataType(DataType.Time)]
		public DateTime StopTime { get; set; }

		public string Schedule { get { return StartTime.ToShortTimeString() + " " + StopTime.ToShortTimeString(); } }
	}
}