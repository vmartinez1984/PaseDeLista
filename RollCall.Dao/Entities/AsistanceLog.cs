using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Persistence.Entities
{
	public class AssistanceLog
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public int EmployeeId { get; set; }
		public virtual EmployeeEntity Employee { get; set; }

		[Required]
		public DateTime RegistrationDate { get; set; }

		[Required]
		[ForeignKey(nameof(AssistenceStatus))]
		public int AssistenceStatusId { get; set; }
		public virtual AssistenceStatus AssistenceStatus { get; set; }
	}
}