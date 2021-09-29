using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public 	class AreaDto
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Nombre")]
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(150)]
		[Display(Name = "Descripción")]
		public string Description { get; set; }
	}
}