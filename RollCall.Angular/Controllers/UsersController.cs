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
	public class UsersController : ControllerBase
	{
		// GET: api/<UsersController>
		[HttpGet]
		[Route("Users/{isActive}")]
		public async Task<IActionResult> Get(bool isActive= true)
		{
			try
			{
				List<EmployeeDto> list;

				//list = await UserBl.GetAllAsync(isActive);
				list = new List<EmployeeDto>();

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

				userDto= await UserBl.GetAsync(id);
				if(userDto is null)
					return NotFound();
				else
					return Ok(userDto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		// POST api/<UsersController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
