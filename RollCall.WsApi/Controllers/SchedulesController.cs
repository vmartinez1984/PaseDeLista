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
	public class SchedulesController : ControllerBase
	{
		// GET: api/<UsersController>
		[HttpGet]
		public async Task<IActionResult> Get(bool isActive = true)
		{
			try
			{
				List<ScheduleDto> list;

				list = await ScheduleBl.GetAllAsync(isActive);

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
				ScheduleDto dto;

				dto = await ScheduleBl.GetAsync(id);

				return Ok(dto);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(ScheduleDto ScheduleDto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await ScheduleBl.AddAsync(ScheduleDto);

					return Created($"Schedules/{ScheduleDto.Id}", new { Id = ScheduleDto.Id });
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
		public async Task<IActionResult> Put(ScheduleDto ScheduleDto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await ScheduleBl.UpdateAsync(ScheduleDto);

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

		[HttpDelete("{ScheduleId}")]
		public async Task<IActionResult> Delete(int ScheduleId)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await ScheduleBl.DeleteAsync(ScheduleId);

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
