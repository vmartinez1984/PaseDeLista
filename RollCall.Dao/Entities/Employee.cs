﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Persistence.Entities
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		[StringLength(8)]
		public string EmployeeNumber { get; set; }

		[Required]
		[StringLength(150)]
		public string Name { get; set; }

		[Required]
		[StringLength(150)]
		public string LastName { get; set; }

		public string PhotoInBase64 { get; set; }

		public DateTime RegistrationDate { get; set; }

		[ForeignKey(nameof(Area))]
		public int? AreaId { get; set; }
		public virtual Area Area { get; set; }

		[ForeignKey(nameof(Schedule))]
		public int? ScheduleId { get; set; }
		public virtual Schedule Schedule { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public DateTime? DischargeDate { get; set; }

		public virtual List<SecurityQuestion> ListSecurityQuestions { get; set; }
	}
}