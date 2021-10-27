using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class UserDto
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name ="e-mail")]
		public string Email { get; set; }

		[Required]
		[StringLength(20)]
		[Display(Name ="Contraseña")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]		
		[Display(Name ="Rol")]
		public int RolId { get; set; }
		public virtual RolDto Rol { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name ="Nombre")]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name ="Apellidos")]
		public string LastName { get; set; }
	}
}