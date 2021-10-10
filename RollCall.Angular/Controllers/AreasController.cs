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
				return StatusCode(500);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				AreaDto dto;

				dto = await AreaBl.GetAsync(id);

				return Ok(dto);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(AreaDto areaDto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await AreaBl.AddAsync(areaDto);

					return Created($"Areas/{areaDto.Id}", new { Id = areaDto.Id });
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
		public async Task<IActionResult> Put(AreaDto areaDto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await AreaBl.UpdateAsync(areaDto);

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

		[HttpDelete("{areaId}")]
		public async Task<IActionResult> Delete(int areaId)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await AreaBl.DeleteAsync(areaId);

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