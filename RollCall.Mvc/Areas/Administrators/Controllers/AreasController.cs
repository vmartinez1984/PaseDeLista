using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Areas.Administrators.Controllers
{
	[Area("Administrators")]
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
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("Name,Description")]AreaDto area)
		public async Task<IActionResult> Create(IFormCollection formCollection)
		{
			try
			{
				AreaDto areaDto = new AreaDto()
				{
					Name = formCollection["Name"],
					Description = formCollection["Description"]
				};				
				if (ModelState.IsValid)
				{
					await AreaBl.AddAsync(areaDto);

					return RedirectToAction(nameof(Index));
				}
				else
				{
					return View();
				}
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
