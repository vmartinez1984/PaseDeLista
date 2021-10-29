using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.WsApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecurityQuestionsController : ControllerBase
	{
		[HttpGet]
		[Route("/apiSecurityQuestions/Employee/{employeeId}/RandomSecurityQuestion")]
		public async Task<IActionResult> Get(int employeeId)
		{
			try
			{
				List<SecurityQuestionDto> list;
				Random random;
				int index;

				list = await SecurityQuestionBl.GetAllAsync(employeeId);
				random	= new Random();
				index = random.Next(0, list.Count);
				list[index].Answer = string.Empty;

				return Ok(list[index]);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}		
	}
}