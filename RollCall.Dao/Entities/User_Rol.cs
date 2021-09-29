using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Persistence.Entities
{
	public class User_Rol
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }
		public virtual User User { get; set; }

		[Required]
		[ForeignKey(nameof(Rol))]
		public int RolId { get; set; }
		public virtual Rol Rol { get; set; }

		public DateTime RegistrationDate { get; set; }

		public bool IsActive { get; set; }
	}
}