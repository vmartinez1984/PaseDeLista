using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.WsApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		// GET: api/<UsersController>
		[HttpGet]
		[Route("Users/{isActive}")]
		public async Task<IActionResult> Get(bool isActive = true)
		{
			try
			{
				List<UserDto> list;

				list = await UserBl.GetAllAsync(isActive);

				return Ok(list);
			}
			catch (Exception)
			{

				throw;
			}
		}

		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				UserDto userDto;

				userDto = await UserBl.GetAsync(id);
				if (userDto is null)
					return NotFound();
				else
					return Ok(userDto);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
