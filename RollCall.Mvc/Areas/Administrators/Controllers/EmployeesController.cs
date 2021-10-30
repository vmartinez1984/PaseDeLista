using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Areas.Administrators.Controllers
{
	[Area("Administrators")]
	public class EmployeesController : Controller
	{
		public async Task<IActionResult> Index(SearchEmployeeDto searchEmployee)
		{
			try
			{
				ListEmployeeDto list;

				list = await EmployeeBl.GetAllAsync(searchEmployee);
				list.SearchEmployee = searchEmployee;

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
		public async Task<IActionResult> Create([Bind("Name, LastName, PhotoInBase64, AreaId, ScheduleId, ListSecurityQuestions[]")] EmployeeDto dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					dto.ListSecurityQuestions.Add(new SecurityQuestionDto
					{
						Question = this.Request.Form["ListSecurityQuestions[0].Question"].ToString(),
						Answer = this.Request.Form["ListSecurityQuestions[0].Answer"].ToString()
					});
					dto.ListSecurityQuestions.Add(new SecurityQuestionDto
					{
						Question = this.Request.Form["ListSecurityQuestions[1].Question"].ToString(),
						Answer = this.Request.Form["ListSecurityQuestions[1].Answer"].ToString()
					});
					dto.ListSecurityQuestions.Add(new SecurityQuestionDto
					{
						Question = this.Request.Form["ListSecurityQuestions[2].Question"].ToString(),
						Answer = this.Request.Form["ListSecurityQuestions[2].Answer"].ToString()
					});
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
					await EmployeeBl.AddAsync(dto);

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