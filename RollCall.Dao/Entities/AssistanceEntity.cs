using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Persistence.Entities
{
	public class AssistanceEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(EmployeeEntity))]
		public int EmployeeId { get; set; }
		public virtual EmployeeEntity Employee { get; set; }

		public DateTime RegistrationDate { get; set; }

		public DateTime? Entry { get; set; }

		public DateTime? LunchTimeDeparture { get; set; }

		public DateTime? LunchTimeReturn { get; set; }

		public DateTime? Exit { get; set; }

		[Required]
		[ForeignKey(nameof(AssistenceStatus))]
		public int AssistenceStatusId { get; set; }
		public virtual AssistenceStatus AssistenceStatus { get; set; }
	}
}