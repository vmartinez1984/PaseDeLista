using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class RolDto
	{
		public int Id { get; set; }

		[Display(Name = "Rol")]
		public string Name { get; set; }
	}
}