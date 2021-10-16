using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Angular.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		// GET: api/<UsersController>
		[HttpGet]
		public async Task<IActionResult> Get(bool isActive = true)
		
		{
			try
			{
				List<EmployeeDto> list;

				list = await EmployeeBl.GetAllAsync(isActive);
			
				return Ok(list);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				EmployeeDto dto;

				dto = await EmployeeBl.GetAsync(id);

				return Ok(dto);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(EmployeeDto EmployeeDto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await EmployeeBl.AddAsync(EmployeeDto);

					return Created($"Employees/{EmployeeDto.Id}", new { Id = EmployeeDto.Id });
				}
				else
				{
					return BadRequest(ModelState);
				}
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put(EmployeeDto EmployeeDto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await EmployeeBl.UpdateAsync(EmployeeDto);

					return NoContent();
				}
				else
				{
					return BadRequest(ModelState);
				}
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpDelete("{EmployeeId}")]
		public async Task<IActionResult> Delete(int EmployeeId)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await EmployeeBl.DeleteAsync(EmployeeId);

					return NoContent();
				}
				else
				{
					return BadRequest(ModelState);
				}
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}
	}
}
