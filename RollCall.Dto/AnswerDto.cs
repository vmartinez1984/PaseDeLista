using System.ComponentModel.DataAnnotations;

namespace RollCall.Dto
{
	public class AnswerDto
	{
		[Required]
		public int SecurityQuestionId { get; set; }

		[Required]
		[MaxLength(150)]
		public string Answer { get; set; }
	}
}
