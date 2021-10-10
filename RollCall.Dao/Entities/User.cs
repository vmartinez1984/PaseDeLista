using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Persistence.Entities
{
	public class User
	{
		[Key]
		public int Id { get; set; }

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
		public virtual Rol Rol { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public DateTime? DischargeDate { get; set; }
		public DateTime RegistrationDate { get; internal set; }
	}
}