using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos.Outputs
{
    public class EmployeeDto
	{
		public EmployeeDto()
		{
			//this.ListSecurityQuestions = new List<SecurityQuestionDtoOut>();
		}
		public int Id { get; set; }

		[StringLength(8)]
		public string EmployeeNumber { get; set; }

		[Required]
		[StringLength(150)]
		[Display(Name = "Nombre")]
		public string Name { get; set; }

		[Required]
		[StringLength(150)]
		[Display(Name = "Apellidos")]
		public string LastName { get; set; }

		public string PhotoInBase64 { get; set; }

		[Display(Name = "Fecha de registro")]
		public DateTime RegistrationDate { get; set; }

		[Required]
		[Display(Name = "Área")]
		public int AreaId { get; set; }
		public virtual AreaDtoOut Area { get; set; }

		[Required]
		[Display(Name = "Horario")]
		public int ScheduleId { get; set; }
		public virtual ScheduleDto Schedule { get; set; }

        [Display(Name = "Fecha de baja")]
		public DateTime? DischargeDate { get; set; }

		public List<SecurityQuestionDtoOut> ListSecurityQuestions {  get; set; }

		public int AssistanceStatusId { get; set; }
	}
}