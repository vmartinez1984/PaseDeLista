using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RollCall.Angular.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecurityQuestionsController : ControllerBase
	{
		// GET: api/<SecurityQuestionsController>
		[HttpGet]
		[Route("/Api/SecurityQuestions/Employee/{employeeId}")]
		public async Task<IActionResult> Get(int employeeId)
		{
			try
			{
				List<SecurityQuestionDto> list;

				list = await SecurityQuestionBl.GetAllAsync(employeeId);

				return Ok(list);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		// GET api/<SecurityQuestionsController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		// POST api/<SecurityQuestionsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<SecurityQuestionsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<SecurityQuestionsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
