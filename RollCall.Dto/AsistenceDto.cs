using System;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class AssistanceDto
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Usuario")]
		public int UserId { get; set; }

		[Display(Name = "Fecha de registro")]
		public DateTime RegistrationDate { get; set; }
	}
}
