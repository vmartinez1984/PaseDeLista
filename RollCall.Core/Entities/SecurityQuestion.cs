using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Core.Entities
{
	public class SecurityQuestionEntity : Base02Entity
	{		
		[ForeignKey(nameof(Employee))]
		public int EmployeeId { get; set; }
		public virtual EmployeeEntity Employee { get; set; }

		[StringLength(150)]
		[Display(Name = "Pregunta")]
		public string Question { get; set; }

		[StringLength(150)]
		[Display(Name = "Respuesta")]
		public string Answer { get; set; }
	}
}