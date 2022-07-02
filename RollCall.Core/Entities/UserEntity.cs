using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Core.Entities
{
    public class UserEntity: Base02Entity
	{
		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
		[StringLength(50)]
		public string Email { get; set; }

		[Required]
		[StringLength(20)]
		public string Password { get; set; }

		[Required]
		[ForeignKey(nameof(Rol))]
		public int RolId { get; set; }
		public virtual RolEntity Rol { get; set; }

		public DateTime? DischargeDate { get; set; }
	}
}