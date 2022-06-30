using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Core.Entities
{
    public class AssistanceLogEntity : Base02Entity
	{
		[Required]
		[ForeignKey(nameof(UserEntity))]
		public int EmployeeId { get; set; }
		public virtual EmployeeEntity Employee { get; set; }

		[Required]
		[ForeignKey(nameof(AssistenceStatus))]
		public int AssistenceStatusId { get; set; }
		public virtual AssistenceStatus AssistenceStatus { get; set; }
	}
}