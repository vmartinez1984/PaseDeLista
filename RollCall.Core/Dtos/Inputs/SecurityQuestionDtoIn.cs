using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Core.Dtos.Inputs
{
    public class SecurityQuestionDtoIn
    {        
        public int EmployeeId { get; set; }

        [Required]
		[StringLength(150)]
		[Display(Name = "Pregunta")]
		public string Question { get; set; }

		[Required]
		[StringLength(150)]
		[Display(Name = "Respuesta")]
		public string Answer { get; set; }
    }
}