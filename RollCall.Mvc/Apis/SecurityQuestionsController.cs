using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Threading.Tasks;

namespace RollCall.Mvc.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecurityQuestionsController : ControllerBase
	{
		//[HttpGet("{id}")]
		//public async Task<IActionResult> Get(int id)
		//{

		//}

		[HttpPost]
		public async Task<ActionResult> Post(SecurityQuestionDto securityQuestion)
		{
			try
			{
				if (ModelState.IsValid)
				{
					securityQuestion.Id = await SecurityQuestionBl.AddAsync(securityQuestion);

					return Ok(new { Id = securityQuestion.Id });
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}

		// PUT: SecurityQuestionsController/Edit/5
		[HttpPut]
		public async Task<ActionResult> Put(SecurityQuestionDto item)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await SecurityQuestionBl.UpdateAsync(item);

					return NoContent();
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}

		// DELETE: SecurityQuestions/Delete/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				await SecurityQuestionBl.DeleteAsync(id);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}
	}
}