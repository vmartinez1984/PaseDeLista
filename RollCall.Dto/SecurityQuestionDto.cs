using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class SecurityQuestionDto
	{
		public int Id { get; set; }
				
		public int EmployeeId { get; set; }

		[Required]
		[StringLength(150)]
		[Display(Name = "Pregunta")]
		public string Question { get; set; }

		[Required]
		[StringLength(150)]
		[Display(Name = "Respuesta")]
		public string Answer { get; set; }
	}
}