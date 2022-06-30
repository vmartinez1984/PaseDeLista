using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos.Outputs
{
	public class RolDto
	{
		public int Id { get; set; }

		[Display(Name = "Rol")]
		public string Name { get; set; }
	}
}