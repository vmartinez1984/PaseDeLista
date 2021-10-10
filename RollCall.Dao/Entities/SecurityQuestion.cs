using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Persistence.Entities
{
	public class SecurityQuestion
	{
		public int Id { get; set; }

		[ForeignKey(nameof(Employee))]
		public int EmployeeId { get; set; }
		public virtual Employee Employee { get; set; }

		[StringLength(150)]
		[Display(Name = "Pregunta")]
		public string Question { get; set; }

		[StringLength(150)]
		[Display(Name = "Respuesta")]
		public string Answer { get; set; }

		public bool IsActive { get; set; }

		public DateTime RegistrationDate { get; set; }
	}
}