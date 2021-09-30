using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Areas.Employees.Controllers
{
	[Area("Employees")]
	public class EmployeeAssistanceController : Controller
	{
		// GET: AsistencesController
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetInt32("userId") is null)
				return RedirectToAction("Index", "Login");

			List<AssistanceDto> list;
			int rolId;
			int userId;

			userId = (int)HttpContext.Session.GetInt32("userId");
			rolId = (int)HttpContext.Session.GetInt32("userRolId");
			switch (rolId)
			{
				case Rol.Administrador:
					list = await AssistanceBl.GetAllAsync();
					break;
				case Rol.Empleado:
					list = await AssistanceBl.GetAllAsync(userId, DateTime.Now.Month);
					break;
				default:
					list = new List<AssistanceDto>();
					break;
			}

			//return View("~/Views/EmployeeAssistance/Index.cshtml", list);
			return View(list);
		}
		
	}//end class
}