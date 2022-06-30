using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Entities
{
	public class AssistenceStatus
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }
	}
}