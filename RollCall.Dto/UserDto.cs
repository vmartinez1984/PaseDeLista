using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class UserDto
	{
		[Key]
		public int Id { get; set; }

		[Required]		
		public int EmployeeId { get; set; }
		public  EmployeeDto Employee { get; set; }

		[Required]
		[StringLength(50)]
		public string Email { get; set; }

		[Required]
		[StringLength(20)]
		public string Password { get; set; }

		[Required]		
		public int RolId { get; set; }
		public virtual Rol Rol { get; set; }
	}
}