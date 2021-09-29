using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class UsersController : Controller
	{
		public async Task<IActionResult> Index()
		{
			try
			{
				List<UserDto> list;

				list = await UserBl.GetAllAsync();

				return View(list);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			try
			{
				ViewBag.AreaList = await AreaBl.GetAllAsync();
				ViewBag.ScheduleList = await ScheduleBl.GetAllAsync();

				return View();
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserDto dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await UserBl.AddAsync(dto);
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.AreaList = await AreaBl.GetAllAsync();
					ViewBag.ScheduleList = await ScheduleBl.GetAllAsync();

					return View();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}