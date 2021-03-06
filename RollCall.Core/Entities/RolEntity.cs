using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Entities
{
	public	class RolEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
				
		[StringLength(150)]
		public string Description { get; set; }

		[Required]
		public bool IsActive { get; set; }
	}
}