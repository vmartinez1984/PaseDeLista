using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos.Inputs
{
	public class UserLoginDto
	{
		[Required]
		[StringLength(50)]
		[Display(Name = "Correo")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[StringLength(20)]
		[Display(Name = "Contraseña")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}