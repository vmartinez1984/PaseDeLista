using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class AreasController : Controller
	{
		public async Task<IActionResult> Index(bool isActive = true)
		{

			List<AreaDto> list;

			list = await AreaBl.GetAllAsync(isActive);

			return View(list);
		}

		[HttpGet]
		public IActionResult Create()
		{
			try
			{
				return View();
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create(AreaDto area)
		{
			try
			{
				await AreaBl.AddAsync(area);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				AreaDto dto;

				dto = await AreaBl.GetAsync(id);

				return View(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AreaDto dto)
		{
			try
			{
				await AreaBl.UpdateAsync(dto);

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
				AreaDto dto;

				dto = await AreaBl.GetAsync(id);

				return View(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(AreaDto dto)
		{
			try
			{
				await AreaBl.DeleteAsync(dto.Id);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
