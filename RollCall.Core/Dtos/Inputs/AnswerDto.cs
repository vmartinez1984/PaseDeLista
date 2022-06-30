using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos.Inputs
{
	public class AnswerDto
	{
		[Required]
		public int SecurityQuestionId { get; set; }

		[Required]
		[MaxLength(150)]
		public string Answer { get; set; }

		[Required]
		public int AsistanceStatusId { get; set; }
	}
}