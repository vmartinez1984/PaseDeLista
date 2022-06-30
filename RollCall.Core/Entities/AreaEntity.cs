using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Core.Entities
{
    public class AreaEntity: Base01Entity
    {
		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[StringLength(150)]
		public string Description { get; set; }
    }
}