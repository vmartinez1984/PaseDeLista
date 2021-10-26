using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Persistence.Entities
{
	public class Assistance
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }
		public virtual EmployeeEntity User { get; set; }

		[Required]
		public DateTime RegistrationDate { get; set; }
	}
}