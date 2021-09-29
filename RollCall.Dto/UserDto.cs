using System;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class UserDto
	{
		public int Id { get; set; }

		[Required]
		[StringLength(150)]
		[Display(Name = "Nombre")]
		public string Name { get; set; }

		[Required]
		[StringLength(150)]
		[Display(Name = "Apellidos")]
		public string LastName { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "Correo")]
		public string Email { get; set; }

		[Required]
		[StringLength(20)]
		[Display(Name = "Contraseña")]
		public string Password { get; set; }

		public string PhotoInBase64 { get; set; }

		[Display(Name ="Fecha de registro")]
		public DateTime RegistrationDate { get; set; }
		
		[Required]
		[Display(Name ="Área")]
		public int AreaId { get; set; }
		//public virtual AreaDto Area { get; set; }

		[Required]
		[Display(Name = "Área")]
		public int ScheduleId { get; set; }
		//public virtual Schedule Schedule { get; set; }

		//[Required]
		//public bool IsActive { get; set; }

		[Display(Name = "Fecha de baja")]
		public DateTime? DischargeDate { get; set; }
	}
}
