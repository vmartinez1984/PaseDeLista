using Microsoft.AspNetCore.Mvc;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecurityQuestionsController : ControllerBase
	{
		// [HttpGet("{employeeId}")]
		// [Route("/api/SecurityQuestions/Employee/{employeeId}/RandomSecurityQuestion")]
		// public async Task<IActionResult> Get(int employeeId)
		// {
		// 	try
		// 	{
		// 		List<SecurityQuestionDto> list;
		// 		Random random;
		// 		int index;

		// 		list = await SecurityQuestionBl.GetAllAsync(employeeId);
		// 		random = new Random();
		// 		index = random.Next(0, list.Count);
		// 		list[index].Answer = string.Empty;

		// 		return Ok(list[index]);
		// 	}
		// 	catch (Exception)
		// 	{
		// 		return StatusCode(500);
		// 	}
		// }

		// [HttpPost]
		// public async Task<ActionResult> Post(SecurityQuestionDto securityQuestion)
		// {
		// 	try
		// 	{
		// 		if (ModelState.IsValid)
		// 		{
		// 			securityQuestion.Id = await SecurityQuestionBl.AddAsync(securityQuestion);

		// 			return Ok(new { Id = securityQuestion.Id });
		// 		}
		// 		else
		// 		{
		// 			return BadRequest();
		// 		}
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		return StatusCode(500, ex);
		// 	}
		// }

		// // PUT: SecurityQuestionsController/Edit/5
		// [HttpPut]
		// public async Task<ActionResult> Put(SecurityQuestionDto item)
		// {
		// 	try
		// 	{
		// 		if (ModelState.IsValid)
		// 		{
		// 			await SecurityQuestionBl.UpdateAsync(item);

		// 			return NoContent();
		// 		}
		// 		else
		// 		{
		// 			return BadRequest();
		// 		}
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		return StatusCode(500, ex);
		// 	}
		// }

		// // DELETE: SecurityQuestions/Delete/5
		// [HttpDelete("{id}")]
		// public async Task<ActionResult> Delete(int id)
		// {
		// 	try
		// 	{
		// 		await SecurityQuestionBl.DeleteAsync(id);

		// 		return NoContent();
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		return StatusCode(500, ex);
		// 	}
		// }
	}
}