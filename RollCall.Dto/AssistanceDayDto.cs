﻿using System;

namespace RollCall.Dto
{
	public class AssistanceDayDto
	{
		public DateTime Date { get; set; }
		public string AssitanceStatus { get; set; }
		public DateTime? Entry { get; set; }
	}
}