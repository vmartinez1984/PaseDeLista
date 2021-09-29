using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class UserLoginDto
	{
		[Required]
		[StringLength(50)]
		[Display(Name = "Correo")]
		public string Email { get; set; }

		[Required]
		[StringLength(20)]
		[Display(Name = "Contraseña")]
		public string Password { get; set; }
	}
}