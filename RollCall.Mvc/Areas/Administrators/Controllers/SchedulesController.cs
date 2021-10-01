using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Mvc.Areas.Administrators.Controllers
{
	[Area("Administrators")]
	public class SchedulesController : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<ScheduleDto> list;

			list = await ScheduleBl.GetAllAsync();

			return View(list);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ScheduleDto dto)
		{
			try
			{
				await ScheduleBl.AddAsync(dto);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				ScheduleDto dto;

				dto = await ScheduleBl.GetAsync(id);

				return View(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ScheduleDto dto)
		{
			try
			{
				await ScheduleBl.UpdateAsync(dto);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				ScheduleDto dto;

				dto = await ScheduleBl.GetAsync(id);

				return View(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(ScheduleDto dto)
		{
			try
			{
				await ScheduleBl.DeleteAsync(dto);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{

				throw;
			}
		}

	}//end class
}