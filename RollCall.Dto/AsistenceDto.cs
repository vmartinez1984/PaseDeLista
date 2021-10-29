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

		[Display(Name = "Nombre")]
		public string Name { get; set; }

		[Display(Name = "Apellidos")]
		public string LastName { get; set; }

		[Display(Name = "Fecha de registro")]
		[DataType(DataType.DateTime)]
		public DateTime RegistrationDate { get; set; }
	}
}