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
	}
}
