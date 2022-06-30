using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Core.Entities
{
    public class EmployeeEntity : Base02Entity
	{
		[StringLength(8)]
		public string EmployeeNumber { get; set; }

		[Required]
		[StringLength(150)]
		public string Name { get; set; }

		[Required]
		[StringLength(150)]
		public string LastName { get; set; }

		public string PhotoInBase64 { get; set; }	

		[ForeignKey(nameof(Area))]
		public int? AreaId { get; set; }
		public virtual AreaEntity Area { get; set; }

		[ForeignKey(nameof(Schedule))]
		public int? ScheduleId { get; set; }
		public virtual ScheduleEntity Schedule { get; set; }	

		public DateTime? DischargeDate { get; set; }

		public virtual List<SecurityQuestionEntity> ListSecurityQuestions { get; set; }

		public bool Monday { get; set; }
		public bool Tuesday { get; set; }
		public bool Wednesday { get; set; }
		public bool Thursday { get; set; }
		public bool Friday { get; set; }
		public bool Saturday { get; set; }
		public bool Sunday { get; set; }
	}
}