using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Threading.Tasks;

namespace RollCall.Mvc.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class AsistancesController : ControllerBase
	{
		[HttpPost("{answer}")]
		[Route("api/Asistances/Register")]
		public async Task<IActionResult> Post(AnswerDto answer)
		{
			try
			{
				if (ModelState.IsValid)
				{
					bool isValid;

					isValid = await AssistanceBl.RegisterAsync(answer);

					return Ok(new { isRegister = isValid });
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
