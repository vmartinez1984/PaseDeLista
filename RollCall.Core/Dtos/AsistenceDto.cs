using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Dtos
{
	public class AssistanceDto
	{		
		public string EmployeeNumber { get; set; }

		[Display(Name = "Nombre")]
		public string Name { get; set; }

		[Display(Name = "Apellidos")]
		public string LastName { get; set; }

		//[Display(Name = "Fecha de registro")]
		//[DataType(DataType.DateTime)]
		//[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		//public DateTime RegistrationDate { get; set; }

		//[Display(Name ="Entrada")]
		//[DataType(DataType.Time)]
		//public DateTime? Entry { get; set; }

		//[Display(Name = "Salida al Lonche")]
		//[DataType(DataType.Time)]
		//public DateTime? LunchTimeDeparture { get; set; }

		//[Display(Name = "Regreso del Lonche")]
		//[DataType(DataType.Time)]
		//public DateTime? LunchTimeReturn { get; set; }

		//[Display(Name = "Salida")]
		//[DataType(DataType.Time)]
		//public DateTime? Exit { get; set; }

		//[Display(Name = "Asistencia")]
		//public string Assitence { get; set; }

		//[Display(Name = "Minutos en el lonche")]
		//public int LunchMinutes { get; set; }

		public List<AssistanceDayDto> ListAssistanceDay { get; set; }
		public int EmployeeId { get; set; }
	}	
}