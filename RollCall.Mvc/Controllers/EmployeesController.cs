using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class EmployeesController : Controller
	{
		public async Task<IActionResult> Index(SearchEmployeeDto searchEmployee)
		{
			try
			{
				ListEmployeeDto list;

				list = await EmployeeBl.GetAllAsync(searchEmployee);
				list.SearchEmployee = searchEmployee;
				ViewBag.IsMaximun = await EmployeeBl.IsMaximum();

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
				ViewBag.RolList = await RolBl.GetAllAsync();

				return View();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IActionResult> Details(int id)
		{
			try
			{
				EmployeeDto dto;

				dto = await EmployeeBl.GetAsync(id);

				return View(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create(EmployeeDto dto,List<SecurityQuestionDto> securityQuestions)
		{
			try
			{
				dto.ListSecurityQuestions = securityQuestions;
				if (ModelState.IsValid)
				{					
					dto.Id = await EmployeeBl.AddAsync(dto);

					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.AreaList = await AreaBl.GetAllAsync();
					ViewBag.ScheduleList = await ScheduleBl.GetAllAsync();
					ViewBag.RolList = await RolBl.GetAllAsync();
					
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
				EmployeeDto dto;

				ViewBag.AreaList = await AreaBl.GetAllAsync();
				ViewBag.ScheduleList = await ScheduleBl.GetAllAsync();
				dto = await EmployeeBl.GetAsync(id);

				return View(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EmployeeDto dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await EmployeeBl.UpdateAsync(dto);

					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.AreaList = await AreaBl.GetAllAsync();
					ViewBag.ScheduleList = await ScheduleBl.GetAllAsync();
					ViewBag.RolList = await RolBl.GetAllAsync();

					return View();
				}
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
				EmployeeDto dto;

				dto = await EmployeeBl.GetAsync(id);

				return View(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(EmployeeDto dto)
		{
			try
			{
				await EmployeeBl.DeleteAsync(dto);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}