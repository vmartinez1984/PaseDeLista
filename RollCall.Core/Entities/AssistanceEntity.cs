using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Core.Entities
{
	public class AssistanceEntity: Base02Entity
	{	
		[Required]
		[ForeignKey(nameof(EmployeeEntity))]
		public int EmployeeId { get; set; }
		public virtual EmployeeEntity Employee { get; set; }		

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