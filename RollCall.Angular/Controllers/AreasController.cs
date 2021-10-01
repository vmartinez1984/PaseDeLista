using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Angular.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AreasController : ControllerBase
	{
		// GET: api/<UsersController>
		[HttpGet]
		public async Task<IActionResult> Get(bool isActive = true)
		{
			try
			{
				List<AreaDto> list;

				list = await AreaBl.GetAllAsync(isActive);

				return Ok(list);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
