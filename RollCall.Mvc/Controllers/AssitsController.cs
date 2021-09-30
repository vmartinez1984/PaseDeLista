using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class AssitsController : Controller
	{
		// GET: AsistencesController
		public async Task<ActionResult> Index()
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

			return View(list);
		}

		// GET: AsistencesController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AsistencesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(AssistanceDto dto)
		{
			try
			{
				dto.RegistrationDate = DateTime.Now;
				await AssistanceBl.AddAsync(dto);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AsistencesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: AsistencesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AsistencesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: AsistencesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
